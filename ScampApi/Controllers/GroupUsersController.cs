using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using ScampApi.Infrastructure;
using ScampApi.ViewModels;

namespace ScampApi.Controllers
{
    [Route("api/groups/{groupId}/users")]
    public class GroupUsersController : Controller
    {
        private ILinkHelper _linkHelper;

        public GroupUsersController(ILinkHelper linkHelper)
        {
            _linkHelper = linkHelper;
        }
        [HttpGet]
        public IEnumerable<UserSummary> Get(int groupId)
        {
            return new[]
                {
                    new UserSummary { UserId = 1, Name = "User1", Links =
                        {
                            new Link {Rel="user", Href = _linkHelper.User(userId: 1) } ,
                            new Link {Rel="groupUser", Href = _linkHelper.GroupUser(groupId: groupId, userId: 1) }
                        }
                    }
                };
        }

        [HttpGet("{userId}", Name="GroupUsers.GetSingle")]
        public UserSummary Get(int groupId, int userId)
        {
            return new UserSummary
            {
                UserId = userId,
                Name = "User" + userId,
                Links =
                        {
                            new Link {Rel="user", Href = _linkHelper.User(userId: userId) } ,
                            new Link {Rel="groupUser", Href = _linkHelper.GroupUser(groupId: groupId, userId: userId) }
                        }
            };
        }

        [HttpPost]
        public void Post(int groupId, [FromBody]int userId)
        {
            // TODO implement adding a user to a group
            throw new NotImplementedException();
        }

        [HttpDelete("{userId}")]
        public void Delete(int groupId, int userId)
        {
            // TODO implement removing a user from a group
            throw new NotImplementedException();
        }
    }
}