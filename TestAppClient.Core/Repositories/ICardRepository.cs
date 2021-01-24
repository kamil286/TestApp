using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppClient.Core.Domian;

namespace TestAppClient.Core.Repositories
{
    public interface ICardRepository
    {
        Task<Card> GetAsync(Guid cardId);
        Task<IEnumerable<Card>> GetAllAsync();
        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(Guid cardId);
    }
}
