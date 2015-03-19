using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentDbRepositories;
using DocumentDbRepositories.Implementation;
using Microsoft.AspNet.Mvc;
using ScampApi.Infrastructure;
using ScampApi.ViewModels;

namespace ScampApi.Controllers
{
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private ILinkHelper _linkHelper;
        private RepositoryFactory _repositoryFacgtory;

        public GroupsController(ILinkHelper linkHelper, RepositoryFactory repositoryFactory)
        {
            _linkHelper = linkHelper;
            _repositoryFacgtory = repositoryFactory; // TODO - revisit this. would be nice to inject repository here
        }
        [HttpGet(Name = "Groups.GetAll")]
        public async Task<IEnumerable<GroupSummary>> Get()
        {
            var repository = await _repositoryFacgtory.GetGroupRepositoryAsync();
            var groups = await repository.GetGroups();
            return groups.Select(MapToSummary);
        }
        private GroupSummary MapToSummary(ScampResourceGroup docDbGroup)
        {
            return new GroupSummary
            {
                GroupId = docDbGroup.Id,
                Name = docDbGroup.Name,
                Links = { new Link { Rel = "group", Href = _linkHelper.Group(groupId: docDbGroup.Id) } }
            };
        }

        [HttpGet("{groupId}", Name = "Groups.GetSingle")]
        public Group Get(string groupId)
        {
            return new Group
            {
                GroupId = groupId,
                Name = "Group" + groupId,
                Resources = new[]
                {
                    new GroupResourceSummary { GroupId = groupId, ResourceId = 1, Name = "GroupResource1", Links = { new Link { Rel = "groupResource", Href =  _linkHelper.GroupResource(groupId: groupId, resourceId: 1) } } }
                },
                Templates = new[]
                {
                    new GroupTemplateSummary { GroupId = groupId, TemplateId = 1, Name = "GroupTemplate1", Links = { new Link { Rel = "groupTemplate", Href  = _linkHelper.GroupTemplate(groupId: groupId, templateId: 1) } } }
                },
                Users = new[]
                {
                    new UserSummary { UserId = 1, Name = "User1", Links =
                        {
                            new Link {Rel="user", Href = _linkHelper.User(userId: 1) } ,
                            new Link {Rel="groupUser", Href = _linkHelper.GroupUser(groupId: groupId, userId: 1) }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public void Post([FromBody]Group group)
        {
            // TODO implement adding a group
            throw new NotImplementedException();
        }

        [HttpPut("{groupId}")]
        public void Put(int groupId, [FromBody]Group value)
        {
            // TODO implement updating a group
            throw new NotImplementedException();
        }

        [HttpDelete("{groupId}")]
        public void Delete(int groupId)
        {
            // TODO implement deleting a group
            throw new NotImplementedException();
        }
    }
}
