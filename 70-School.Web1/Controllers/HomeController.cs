using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace _70_School.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController:RESTFulController
    {
        [HttpGet]
        public ActionResult<string> GetHomeMessage() => "70-School is running...";
    }
}

