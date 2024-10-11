using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;
using Talabat.Repository.Connections;

namespace Talabat.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly TalabatDBContext _talabatDBContext;

        public BuggyController(TalabatDBContext talabatDBContext)
        {
            _talabatDBContext = talabatDBContext;
        }

        [HttpGet("NotFound")]
        public ActionResult NotFoundRequest()
        {
            if (_talabatDBContext.products.Find(200) == null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok(_talabatDBContext.products.Find(200));
        }

        [HttpGet("ServerError")]
        public ActionResult ServerError()
        {
            return Ok(_talabatDBContext.products.Find(200).ToString());
        }

        [HttpGet("badRequest")]
        public ActionResult badRequest()
        {
            return BadRequest(new APIResponse(400));
        }

        [HttpGet("GetUnAuth")]
        public ActionResult GetUnAuth()
        {
            return Unauthorized(new APIResponse(401));
        }

        [HttpGet("badRequest/{id}")]
        public ActionResult ValidationError(int id)
        {
            return Ok();
        }
    }
}
