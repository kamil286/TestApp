using System;
using System.Threading.Tasks;
using TestAppClient.Core.Domian;
using TestAppClient.Core.Repositories;
using TestAppClient.Infrastructure.Exceptions;

namespace TestAppClient.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Card> GetOrFailAsync(this ICardRepository repository, Guid userId)
        {
            var card = await repository.GetAsync(userId);
            if (card == null)
            {
                throw new ServiceException(ErrorCodes.DoNotHaveAccess,
                    $"Driver with user id: '{card.Id}' was not found.");
            }

            return card;
        }
    }
}
