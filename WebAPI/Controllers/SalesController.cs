using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("/sales")]
public class SalesController : Controller
{
    private SalesRepository SalesRepository { get; }

    public SalesController(SalesRepository salesRepository)
    {
        SalesRepository = salesRepository;

    }
    
    [HttpGet(Name = "GetAll")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await SalesRepository.GetAll());
    }
    
    [HttpGet("{id:guid}", Name = "Get")]
    [Authorize]
    public async Task<IActionResult> Get(Guid id)
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
        var createdSale = await SalesRepository.Add(sale);
        if (createdSale == null)
        {
            return BadRequest();
        }
        return CreatedAtAction("Get", new {id = createdSale.Id}, createdSale);
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
    
    [HttpGet("bydate/{date:datetime}",Name = "GetByDate")]
    [Authorize]
    public async Task<IActionResult> GetByDate(DateTime date)
    {
        // var dateTime = DateTime.ParseExact(date, "yyyy-MM-dd", null);
        var sales = await SalesRepository.GetByDate(date);
        if (sales.Count == 0)
        {
            return NotFound();
        }
        
        return Ok( new { Sales = sales, Sum = sales.Select(s => s.Sum).Sum()});
    }
}