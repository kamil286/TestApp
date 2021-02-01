using System;
using System.Threading.Tasks;
using TestAppClient.Infrastructure.Commands;
using TestAppClient.Infrastructure.Commands.Card;
using TestAppClient.Infrastructure.Services.Interfaces;

namespace TestAppClient.Infrastructure.Handlers
{
    public class DeleteCardHandler : ICommandHandler<DeleteCard>
    {
        private readonly ICardService _cardService;

        public DeleteCardHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task HandleAsync(DeleteCard command)
        {
            await _cardService.DeleteAsync(command.Id);
        }
    }
}
