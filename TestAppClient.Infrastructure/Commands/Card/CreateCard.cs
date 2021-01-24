using System;

namespace TestAppClient.Infrastructure.Commands.Card
{
    public class CreateCard : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
