using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class Card : IComparable<Card>
    {
        public Card(Suit s, Value v)
        {
            CardSuit = s;
            CardValue = v;
        }
        public Suit CardSuit { get; set; }
        public Value CardValue { get; set; }

        public int CompareTo(Card other)
        {
            return CardValue.CompareTo(other.CardValue);
        }

        public override string ToString()
        {
            return CardValue.ToString() + " of " + CardSuit.ToString();
        }

    }
}
