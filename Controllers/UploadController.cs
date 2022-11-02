using System;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Interview.Api.Services;

namespace Interview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IPhoneService svc;

        public UploadController(IPhoneService svc)
        {
            this.svc = svc;
        }

        [HttpPost]
        public async Task<ActionResult> UploadDocument([FromForm] IFormFile file)
        {

            long length = file.Length;
            if (length < 0)
                return BadRequest();

            var extension = Path.GetExtension(file.FileName);
            if (extension != ".csv")
                return StatusCode(StatusCodes.Status400BadRequest);

            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);

            var content = Encoding.UTF8.GetString(bytes);

            await svc.UploadNumbers(content);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}

