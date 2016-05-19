using Logic.Enums;
using System.Collections.Generic;

namespace Poker.Logic
{
    public interface IPlayer
    {
        List<Card> Hands { get; set; }
        Card HighCard { get; }
        string Name { get; set; }
        void Received(Card c);
        Card this[int index] { get; }
        Hand PokerHandResult { get; set; }
    }
}