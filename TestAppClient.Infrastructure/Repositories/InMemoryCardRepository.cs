using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppClient.Core.Domian;
using TestAppClient.Core.Repositories;

namespace TestAppClient.Infrastructure.Repositories
{
    public class InMemoryUserRepository : ICardRepository
	{
		private static readonly ISet<Card> _cards = new HashSet<Card>();

		public async Task<Card> GetAsync(Guid id)
			=> await Task.FromResult(_cards.SingleOrDefault(x => x.Id == id));

		public async Task<IEnumerable<Card>> GetAllAsync()
			=> await Task.FromResult(Card);

		public async Task AddAsync(Card card)
		{
			_cards.Add(card);
			await Task.CompletedTask;
		}

        public async Task UpdateAsync(Card card)
        {
			var cardToUpdate = _cards.FirstOrDefault(c => c.Id == card.Id);
			_cards.Remove(cardToUpdate);
			_cards.Add(cardToUpdate);
			await Task.CompletedTask;
		}

        public async Task DeleteAsync(Guid cardId)
        {
			var user = await GetAsync(cardId);
			_cards.Remove(user);
			await Task.CompletedTask;
		}
    }
}
