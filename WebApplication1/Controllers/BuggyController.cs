using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    public class BuggyController(DataContext context) : BaseApiController
    {
        [HttpGet("auth")]
        public ActionResult<string> GetAuth ()
        {
            return "secret text";
        }

        [HttpGet("notFound")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = context.Users.Find(-1);
            if (thing == null) return NotFound();
            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError()
        {
            var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing happened!! :( ");
            return thing;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this was not a good request!");
        }
    }
}
