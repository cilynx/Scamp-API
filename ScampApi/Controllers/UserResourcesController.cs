using System;
using System.Collections.Generic;
using System.Linq;
using AzureProvisioningLibrary;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.ConfigurationModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ScampApi.Controllers.Controllers
{
    [Route("api/user/resources/{resourceId}/")]
    public class UserResourcesController : Controller
    {


        IDictionary<string, string> settings = new Dictionary<string, string>();
        WebJobController _webJobController;

        public UserResourcesController(IConfiguration config)
        {

            var storageCstr = config.Get("StorageConnectionString");
            settings.Add("StorageConnectionString", storageCstr);

            _webJobController = new WebJobController(settings);
        }


        // POST /api/user/resources/{resourceId}/{actionname}
        [HttpPost("{actionname}")]
        public void Post(int resourceId, string actionname)
        {
            // Start, Stop a resource

            _webJobController.SubmitActionInQueue(resourceId, actionname);


        }

        // GET /api/user/resources/{resourceId}/connect
        [HttpGet("connect")]
        public string Get(int resourceId)
        {
            //return the RDP connection string
            return "rdpconnection 1";
        }

    }
}
