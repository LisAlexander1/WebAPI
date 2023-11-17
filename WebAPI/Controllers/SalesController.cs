using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers;

[ApiController]
[Route("/sales")]
public class SalesController : Controller
{
    private SalesRepository SalesRepository { get; }

    public SalesController(SalesRepository salesRepository)
    {
        SalesRepository = salesRepository;

    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> FindAll()
    {
        return Ok(await SalesRepository.GetAll());
    }
    
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> FindOne(Guid id)
    {
        var sale = await SalesRepository.Get(id);
        if (sale == null)
            return NotFound();
        
        return Ok(sale);
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var sale = await SalesRepository.Delete(id);
        if (sale == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Sale sale)
    {
        if (sale == null)
        {
            return BadRequest();
        }
        await SalesRepository.Add(sale);
        return CreatedAtAction("FindOne", new {id = sale.Id}, sale);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] Sale sale)
    {
        if (sale == null)
        {
            return BadRequest();
        }

        var updatedSale = await SalesRepository.Update(sale);
        return Ok(updatedSale);
    }
}