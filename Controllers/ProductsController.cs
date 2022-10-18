using Interview.Api.Entities;
using Interview.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService service;

    public ProductsController(IProductService service)
    {
        this.service = service;
    }

    [ActionName("get-ptds")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await service.GetProductAsync();

        return StatusCode(StatusCodes.Status200OK, result);

        //return StatusCode(StatusCodes.Status200OK);
    }

    //[HttpPost]
    //public async Task<IActionResult> Post(Product product)
    //{
    //    var result = await service.AddProductAsync(product);

    //    return StatusCode(StatusCodes.Status200OK, result);
    //}
}

