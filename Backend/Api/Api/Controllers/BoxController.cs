using System.ComponentModel.DataAnnotations;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;
[ApiController]
public class BoxController: ControllerBase
{
    private readonly Service.Service _service;

    public BoxController(Service.Service service)
    {
        _service = service;
    }

    [HttpPost("/createBox")]
    public Box CreateBox([FromBody] Box box)
    {
        return _service.CreateBox(box);
    }

    [HttpGet]
    [Route("/products")]
    public IEnumerable<Box> GetAllProducts()
    {
        IEnumerable<Box> boxes = _service.GetAllProducts();

        return boxes;
    }

    [HttpGet]
    [Route("/products/{productID}")]
    public Box GetProductById([FromRoute] int productID)
    {
        return _service.GetBoxById(productID);
    }
    
    
        
    [HttpDelete]
    [Route("/api/products/{productID}")]
    public bool DeleteBox([FromRoute] int productID)
    {
        return _service.DeleteBox(productID);
    }
    
    [HttpPut]
    [Route("/api/products")]
    public Box UpdateBox([FromBody] Box box)
    {
        return _service.UpdateBox(box);
    }
}