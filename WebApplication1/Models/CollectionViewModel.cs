﻿using BerserkCollection.Domain.Entities;

namespace BerserkCollection.Models
{
    public class CollectionViewModel
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
        public string Properties { get; set; }
        public int Count { get; set; }

        public CollectionViewModel() { }

        public CollectionViewModel(Card card)
        {
            Id = card.Id;
            Name = card.Name;
            Image = card.Image;
            Number = card.Number;
            Element = card.Element;
            Currency = card.Currency;
            Rare = card.Rare;
            Set = card.Set;
            IsHorde = card.IsHorde;
            Properties = GetProperties(card);
            Count = 0;
        }

        private string GetProperties(Card card)
        {
            string props = "";

            if (card.IsHorde) { props += " ishorde"; }

            return props;
        }

        public static string GetAvailability (int count, bool isHorde)
        {
            string result = " set";

            if (count < 3 || (count < 5 && isHorde)) 
            {
                result = " less";
            }
            else if ((count > 3 && !isHorde) || (count > 5 && isHorde))
            {
                result = " more";
            }

            return result;
        }
    }
}
