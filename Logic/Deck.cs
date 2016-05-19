using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class Deck : IDeck
    {
        const int numberOfCards = 52;
        private List<Card> CardDeck;
        private int currentCard = 0;

        public Deck()
        {
            CardDeck = new List<Card>(numberOfCards);
        }

        /// <summary>
        /// Get Card Deck
        /// </summary>
        public List<Card> GetCardDeck() {  
            return CardDeck;
        }

        /// <summary>
        /// Setup deck of cards initially
        /// </summary>
        public void Setup()
        {
            //var i = 0;
            foreach(Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach(Value v in Enum.GetValues(typeof(Value)))
                {
                    CardDeck.Add(new Card(s, v));
                }
            }
            Shuffle();
        }

        /// <summary>
        /// Pull next card
        /// </summary>
        /// <returns></returns>
        public Card Pull()
        {
            return CardDeck[currentCard++];
        }

        /// <summary>
        /// Peek card
        /// </summary>
        /// <returns></returns>
        public Card Peek()
        {
            return CardDeck[currentCard];
        }

        /// <summary>
        /// Swap card
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Swap(int i, int j)
        {
            Card tempCard = CardDeck[i];
            CardDeck[i] = CardDeck[j];
            CardDeck[j] = tempCard;
        }

        /// <summary>
        /// Shuffle the deck and reset the current card count to the start
        /// </summary>
        /// <param name="count"></param>
        public void Shuffle(int count)
        {
            var rand = new Random();
            currentCard = 0;
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < 52; ++j)
                {
                    int idx = rand.Next(52);
                    Swap(j, idx);
                }
            }
        }

        /// <summary>
        /// Shuffle the deck
        /// </summary>
        protected void Shuffle()
        {
            Shuffle(8);
        }

        /// <summary>
        /// Print deck of cards
        /// </summary>
        public void Print()
        {
            foreach (Card c in CardDeck) Console.WriteLine(c);
        }

    
    }
}
