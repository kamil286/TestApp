using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppClient.Infrastructure.DTO;

namespace TestAppClient.Infrastructure.Services.Interfaces
{
    public interface ICardService : IService
    {
        Task<CardDto> GetAsync(Guid cardId);
        Task<IEnumerable<CardDto>> BrowseAsync();
        Task RegisterAsync(
            Guid cardId,
            string title,
            string content
        );
        Task UpdateAsync(
            Guid cardId,
            string title,
            string content
        );
        Task DeleteAsync(Guid cardId);
    }
}
