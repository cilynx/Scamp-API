using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using ScampApi.Infrastructure;
using ScampApi.ViewModels;

namespace ScampApi.Controllers
{
    [Route("api/groups/{groupId}/resources/{resourceId}/users")]
    public class GroupResourceUsersController : Controller
    {
        private ILinkHelper _linkHelper;

        public GroupResourceUsersController(ILinkHelper linkHelper)
        {
            _linkHelper = linkHelper;
        }

        [HttpGet]
        public IEnumerable<UserSummary> GetAll(string groupId, int resourceId)
        {
            return new[]
                {
                    new UserSummary { UserId = 1, Name = "User1", Links =
                        {
                            new Link {Rel="user", Href = _linkHelper.User(userId: 1) } ,
                            new Link {Rel="groupResourceUser", Href = _linkHelper.GroupResourceUser(groupId: groupId, resourceId:resourceId, userId: 1) }
                        }
                    }
                };
        }
        [HttpGet("{userId}", Name = "GroupResourceUsers.GetSingle")]
        public UserSummary Get(string groupId, int resourceId, int userId)
        {
            return new UserSummary
            {
                UserId = 1,
                Name = "User1",
                Links =
                        {
                            new Link {Rel="user", Href = _linkHelper.User(userId: userId) } ,
                            new Link {Rel="groupResourceUser", Href = _linkHelper.GroupResourceUser(groupId: groupId, resourceId:resourceId, userId: userId) }
                        }
            };
        }

        [HttpPost]
        public void Post(string groupId, int resourceId, [FromBody]int userId)
        {
            // TODO implement adding a user to a group resource
            throw new NotImplementedException();
        }

        [HttpDelete("{userId}")]
        public void Delete(string groupId, int resourceId, int userId)
        {
            // TODO implement removing a user from a group resource
            throw new NotImplementedException();
        }
    }
}