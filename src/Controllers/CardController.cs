using MagicTheGatheringApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace MagicTheGatheringApi.Controllers;

public class CardController : ApiControllerBase
{
    private readonly MagicTheGatheringContext _context;

    public CardController()
    {
        _context = new MagicTheGatheringContext();
    }

    [HttpGet("{number}")]
    public IActionResult GetByNumber(string number)
    {
        try
        {
            var card = _context.Cards.FirstOrDefault(card => card.Number == number);

            if (card == null)
                return NotFound();

            return Ok(card);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public IActionResult GetBySearchTerms([FromBody] string[] searchTerms)
    {
        try
        {
            var cards = _context.Cards
                .Where(card => searchTerms.Any(term => card.Name.ToLower().Contains(term.ToLower())))
                .ToList();

            if (cards.Count > default(int))
            {
                return Ok(cards);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception)
        {

            return StatusCode(500);
        }
    }
}