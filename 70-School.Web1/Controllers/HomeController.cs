using Microsoft.AspNetCore.Mvc;

namespace _70_School.Web1.Controllers
{
    public class HomeController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class HomeController : ControllerBase
        {
            [HttpGet]
            public ActionResult<string> GetHomeMessage() => "70-School is running...";
        }
    }
}
