namespace BerserkCollection.Domain.Entities
{
    public class UserCards
    {
        public int Id { get; set; }
        public UserAccount User { get; set; }
        public Card Card { get; set; }
        public int Count { get; set; }
    }
}
