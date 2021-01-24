using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TestAppClient.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ApiControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ILogger<CardsController> _logger;

        public CardsController(
            ILogger<CardsController> logger,
            ICardService cardService,
            ICommandDispatcher commandDispatcher
        ) : base(commandDispatcher)
        {
            _logger = logger;
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cards = await _cardService.BrowseAsync();
            return Json(cards);
        }

        [HttpGet("{cardId}")]
        public async Task<IActionResult> Get(Guid cardId)
        {
            var card = await _cardService.GetAsync(cardId);
            if (card == null)
            {
                return NotFound();
            }

            return Json(card);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCard command)
        {
            await DispatchAsync(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCard command)
        {
            await DispatchAsync(command);

            return Created($"cards/{command.Id}", new object());
        }

        [HttpDelete("del")]
        public async Task<IActionResult> Delete()
        {
            await DispatchAsync(new DeleteCard());

            return NoContent();
        }
    }
}
