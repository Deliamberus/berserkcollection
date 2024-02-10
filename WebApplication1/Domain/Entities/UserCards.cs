namespace BerserkCollection.Domain.Entities
{
    public class UserCards
    {
        public int Id { get; set; }
        public UserAccount User { get; set; }
        public Card Card { get; set; }
        public int Count { get; set; }

        public UserCards(UserAccount user, Card card, int count)
        {
            User = user;
            Card = card;
            Count = count;
        }

        public UserCards() { }
    }
}