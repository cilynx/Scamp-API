using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using ScampApi.Infrastructure;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ScampApi.Controllers.Controllers
{
    [Route("api")]
    public class ApiHomeController : Controller
    {
        private ILinkHelper _linkHelper;

        public ApiHomeController(ILinkHelper linkHelper)
        {
            _linkHelper = linkHelper;
        }
        [HttpGet]
        public object Get()
        {
            return new
            {
                groupsUrl = _linkHelper.Groups(),
                currentUserUrl = _linkHelper.CurrentUser(),
                usersUrl = _linkHelper.Users()
            };
        }
    }
}
