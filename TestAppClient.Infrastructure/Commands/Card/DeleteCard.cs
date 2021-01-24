using System;

namespace TestAppClient.Infrastructure.Commands.Card
{
    public class DeleteCard : ICommand
    {
        public Guid Id { get; set; }
    }
}
