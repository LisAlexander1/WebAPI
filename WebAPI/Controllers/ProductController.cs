using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers;

[ApiController]
[Route("products")]
public class ProductController : Controller
{
    private ProductsRepository ProductsRepository { get; }

    public ProductController(ProductsRepository productsRepository)
    {
        this.ProductsRepository = productsRepository;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await ProductsRepository.GetAll());
    }
    
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await ProductsRepository.Get(id);
        if (product == null)
            return NotFound();
        
        return Ok(product);
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await ProductsRepository.Delete(id);
        if (product == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        var createdProduct = await ProductsRepository.Add(product);
        return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        var updatedProduct = await ProductsRepository.Update(product);
        return Ok(updatedProduct);
    }
}