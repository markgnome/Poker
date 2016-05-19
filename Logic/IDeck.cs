using System.Collections.Generic;

namespace Poker.Logic
{
    public interface IDeck
    {
        List<Card> GetCardDeck();
        void Setup();
        Card Pull();
        Card Peek();
        void Shuffle(int count);
        void Print();
    }
}