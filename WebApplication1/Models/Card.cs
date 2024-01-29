namespace BerserkCollection.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? Number { get; set; }
        public int? Count { get; set; }
        public string? Element {  get; set; }
        public string? Currency { get; set; }
        public string? Rare { get; set; }
        public string? Set { get; set; }
        public Card() { }
    }
}
