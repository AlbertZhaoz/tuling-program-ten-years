using Microsoft.AspNetCore.Mvc;

namespace Albert.MicroService.TeamService.Controllers
{
    [Route("HealthCheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        // GET: api/Teams
        [HttpGet]
        public ActionResult GetHealthCheck()
        {
            return Ok("连接正常");
        }
    }
}