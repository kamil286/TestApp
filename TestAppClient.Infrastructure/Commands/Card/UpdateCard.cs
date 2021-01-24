using System;

namespace TestAppClient.Infrastructure.Commands.Card
{
    public class UpdateCard : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
