using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestAppClient.Infrastructure.Commands;

namespace TestAppClient.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher CommandDispatcher;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await CommandDispatcher.DispatchAsync(command);
        }
    }
}
