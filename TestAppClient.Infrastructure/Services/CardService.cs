using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppClient.Core.Domian;
using TestAppClient.Core.Repositories;
using TestAppClient.Infrastructure.DTO;
using TestAppClient.Infrastructure.Services.Interfaces;

namespace TestAppClient.Infrastructure.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardDto>> BrowseAsync()
        {
            var cards = await _cardRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Card>, IEnumerable<CardDto>>(cards);
        }

        public async Task<CardDto> GetAsync(Guid cardId)
        {
            var card = await _cardRepository.GetAsync(cardId);

            return _mapper.Map<Card, CardDto>(card);
        }

        public async Task RegisterAsync(
            Guid cardId,
            string title,
            string content
        )
        {
            var card = new Card(cardId, title, content);

            await _cardRepository.AddAsync(card);
        }

        public async Task UpdateAsync(
            Guid cardId,
            string title,
            string content)
        {
            var card = await _cardRepository.GetAsync(cardId);

            await _cardRepository.UpdateAsync(card);
        }

        public async Task DeleteAsync(Guid cardId)
        {
            await _cardRepository.DeleteAsync(cardId);
        }
    }
}
