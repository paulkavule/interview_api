using System;
using Interview.Api.Entities;
using Interview.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService svc;

        public CountryController(ICountryService svc)
        {
            this.svc = svc;
        }

        [ActionName("get-cty")]
        [HttpGet]
        public async Task<IActionResult> GetCountries(string name)
        {
            var list = await svc.GetCountries(name);

            return StatusCode(StatusCodes.Status200OK, list);
        }
        [ActionName("post-cty")]
        [HttpPost]
        public async Task<IActionResult> PostCountry(Country cty)
        {
            var cnt = await svc.AddCountry(cty);

            return StatusCode(StatusCodes.Status200OK, cnt);
        }
    }

}

