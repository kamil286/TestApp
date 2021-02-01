using System;
using System.Threading.Tasks;
using TestAppClient.Infrastructure.Commands;
using TestAppClient.Infrastructure.Commands.Card;
using TestAppClient.Infrastructure.Services.Interfaces;

namespace TestAppClient.Infrastructure.Handlers
{
    public class CreateCardHandler : ICommandHandler<CreateCard>
    {
        private readonly ICardService _cardService;

        public CreateCardHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task HandleAsync(CreateCard command)
        {
            await _cardService.RegisterAsync(
                Guid.NewGuid(),
                command.Title,
                command.Content
            );
        }
    }
}
