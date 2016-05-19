using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    /// <summary>
    /// Player class that play poker
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Name = name;
            Hands = new List<Card>();
        }

        /// <summary>
        /// Player cards
        /// </summary>
        public List<Card> Hands { get; set; }

        /// <summary>
        /// Poker hand result
        /// </summary>
        public Hand PokerHandResult { get; set; }

        /// <summary>
        /// Player name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Player accept card
        /// </summary>
        /// <param name="c"></param>
        public void Received(Card card)
        {
            Hands.Add(card);
        }

        /// <summary>
        /// Player accept list of cards
        /// </summary>
        /// <param name="cards"></param>
        public void Received(List<Card> cards)
        {
            Hands.AddRange(cards);
        }

        /// <summary>
        /// Index of player poker hand
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Card this[int index]
        {
            get { return Hands[index]; }
        }

        /// <summary>
        /// Get High Card Points
        /// </summary>
        public Card HighCard
        {
            get
            {
                var maxValue = Hands.Max(x => x.CardValue);
                return Hands.First(x => x.CardValue == maxValue);
            }
        }
    }
}
