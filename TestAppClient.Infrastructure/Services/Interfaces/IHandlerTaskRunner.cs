using System;
using System.Threading.Tasks;

namespace TestAppClient.Infrastructure.Services
{
    public interface IHandlerTaskRunner
    {
        IHandlerTask Run(Func<Task> runAsync);
    }
}
