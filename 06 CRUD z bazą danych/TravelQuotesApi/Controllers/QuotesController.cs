//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TravelQuotesApi.Data;
using TravelQuotesApi.Interfaces;
using TravelQuotesApi.Models;

[Route("api/[controller]")]
[ApiController]
public class QuotesController : ControllerBase
{
    private readonly IRepository<Quote> _quoteRepository;

    public QuotesController(IRepository<Quote> quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }

    // GET: api/Quotes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
    {
        var quotes = await _quoteRepository.GetAllAsync();
        return Ok(quotes);
    }

    // GET: api/Quotes/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Quote>> GetQuote(int id)
    {
        var quote = await _quoteRepository.GetByIdAsync(id);

        if (quote == null)
        {
            return NotFound();
        }

        return Ok(quote);
    }


    // POST: api/Quotes
    [HttpPost]
    public async Task<ActionResult<Quote>> PostQuote(Quote quote)
    {
        await _quoteRepository.CreateAsync(quote);
        return CreatedAtAction(nameof(GetQuote), new { id = quote.Id }, quote);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuote(int id, Quote quote)
    {
        if (id != quote.Id)
        {
            return BadRequest();
        }

        var existingQuote = await _quoteRepository.GetByIdAsync(id);

        if (existingQuote == null)
        {
            return NotFound();
        }

        existingQuote.Author = quote.Author;
        existingQuote.Message = quote.Message;

        await _quoteRepository.UpdateAsync(quote);
        return NoContent();
    }

    // DELETE: api/Quotes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuote(int id)
    {
        var existingQuote = await _quoteRepository.GetByIdAsync(id);

        if (existingQuote == null)
        {
            return NotFound();
        }

        await _quoteRepository.DeleteAsync(id);
        return NoContent();
    }
}
