using System;
using Poker.Logic;
using Logic.Enums;
using System.Collections.Generic;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            IHandEvaluator evaluator = new HandEvaluator();
            IDeck deck = new Deck();

            deck.Setup();

            List<IPlayer> Players = new List<IPlayer>()
            {
                 new Player("Joe"),
                 new Player("Jen"),
                 new Player("Bob")
            };

            for (int i = 0; i < 5; i++)
            {
                foreach (var p in Players)
                {
                    p.Received(deck.Pull());
                }
            }

            var winner = evaluator.Winner(Players);

            foreach(var p in Players)
            {
                if(p == winner) { Console.ForegroundColor = ConsoleColor.Red; } else { Console.ResetColor(); }

                Console.WriteLine(string.Format("{0} has poker hands of {1} and has High Card of {2}", p.Name, p.PokerHandResult, p.HighCard));

                foreach (var h in p.Hands)
                {
                    Console.WriteLine(h.ToString());
                }
                Console.WriteLine();
            }

            Console.WriteLine("Given the following players and their hands, the winner is {0}.", winner.Name);

            Console.ReadLine();

        }
    }
}
