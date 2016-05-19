using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class HandEvaluator : IHandEvaluator
    {
        private bool Flush(IPlayer h)
        {
            return h[0].CardSuit == h[1].CardSuit &&
                   h[1].CardSuit == h[2].CardSuit &&
                   h[2].CardSuit == h[3].CardSuit &&
                   h[3].CardSuit == h[4].CardSuit;
        }

        private bool ThreeKind(IPlayer h)
        {
            return h[0].CardValue == h[1].CardValue && h[0].CardValue == h[2].CardValue ||
                 h[1].CardValue == h[2].CardValue && h[1].CardValue == h[3].CardValue ||
                 h[2].CardValue == h[3].CardValue && h[2].CardValue == h[4].CardValue;
        }

        private bool OnePair(IPlayer h)
        {
            return h.Hands.GroupBy(p => new { p.CardValue }).Distinct().Count() < 5;
        }

        public Hand Evaluate(IPlayer h)
        {
            if (Flush(h))
            {
                return Hand.Flush;
            }
            else if (ThreeKind(h))
            {
                return Hand.ThreeKind;
            }
            else if (OnePair(h))
            {
                return Hand.OnePair;
            }
            else return Hand.HighCard;
        }

        public IPlayer Winner(List<IPlayer> players)
        {
            foreach(var p in players)
            {
                p.PokerHandResult = Evaluate(p);
            }

            //Flush brothers
            var flushPlayers = players.Where(p => p.PokerHandResult == Hand.Flush).ToList();
            var threeOfAKindPlayers = players.Where(p => p.PokerHandResult == Hand.ThreeKind).ToList();
            var onePairPlayers = players.Where(p => p.PokerHandResult == Hand.OnePair).ToList();
            if (flushPlayers.Any())
            {
                return CompareHands(flushPlayers);
            }
            else if (threeOfAKindPlayers.Any())
            {
                return CompareHands(threeOfAKindPlayers);
            }
            else if (onePairPlayers.Any())
            {
                return CompareHands(onePairPlayers);
            }
            else
            {
                return GetHighCard(players);
            }
        }

        private IPlayer CompareHands (List<IPlayer> players)
        {
            return players.Count() == 1 ? players.First() : GetHighCard(players);
        }

        private IPlayer GetHighCard(List<IPlayer> players)
        {

            var maxValue = players.Max(x => x.HighCard);
            return players.First(p => p.HighCard == maxValue);
        }

    }
}
