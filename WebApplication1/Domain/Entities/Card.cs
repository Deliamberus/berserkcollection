namespace BerserkCollection.Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? Number { get; set; }
        public string? Element { get; set; }
        public string? Currency { get; set; }
        public string? Rare { get; set; }
        public string? Set { get; set; }
        public bool IsHorde { get; set; }
        public int? ExpDef { get; set; }
        public int? ExpAtack { get; set; }
        public int? ExpShot { get; set; }
        public bool IsDefFly { get; set; }
        public bool IsDefPoison { get; set; }
        public bool IsDefShot { get; set; }
        public bool IsDefSpell { get; set; }
        public bool IsDefMagic { get; set; }
        public bool IsDefStrike { get; set; }
        public bool IsDefThrow { get; set; }
        public int? Armor { get; set; }
        public bool IsTarget { get; set; }
        public int? Regen { get; set; }
        public bool IsStamina { get; set; }
        public Card() { }
    }
}
