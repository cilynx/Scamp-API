using System;
using System.Threading.Tasks;
using DocumentDbRepositories;
using DocumentDbRepositories.Implementation;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ScampApi.Controllers
{
    [Route("sampledata")]
    public class SampleDataController : Controller
    {
        private readonly RepositoryFactory _repositoryFactory;

        public SampleDataController(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> Index_Post()
        {
            var groupRepo = await _repositoryFactory.GetGroupRepositoryAsync();
            await groupRepo.CreateGroup(new ScampResourceGroup
            {
                Id = Guid.NewGuid().ToString("d"),
                Name = "My sample group",
            });
            return Content("Done!");
        }
    }
}
