using System;

namespace TestAppClient.Core.Domian
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Card(Guid Id, string Title, string Content)
        {
        }

        protected Card()
        {

        }
    }
}
