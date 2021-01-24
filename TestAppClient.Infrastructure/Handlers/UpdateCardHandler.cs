using System;
using System.Threading.Tasks;
using TestAppClient.Infrastructure.Commands;
using TestAppClient.Infrastructure.Commands.Card;

namespace TestAppClient.Infrastructure.Handlers
{
    public class UpdateCardHandler : ICommandHandler<UpdateCard>
    {
        private readonly ICardService _cardService;

        public UpdateCardHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task HandleAsync(UpdateCard command)
        {
            await _cardService.UpdateAsync(
                Guid.NewGuid(),
                command.Title,
                command.Content
            );
        }
    }
}
