using System;
using NUnit.Framework;
using Poker.Logic;
using Logic.Enums;
using FluentAssertions;
using System.Collections.Generic;

namespace Test
{
    /// <summary>
    /// Using 3rd Parties Library NUnit and Fluent Assertions
    /// </summary>
    [TestFixture]
    public class WhenOnePairDeckOfCards
    {
        protected IHandEvaluator Sut;
        protected IPlayer PlayerJoe = new Player("Joe");
        protected IPlayer PlayerJen = new Player("Jen");
        protected IPlayer PlayerBob = new Player("Bob");
        protected Hand PokerHandResult;
        protected IDeck deck;
        protected List<IPlayer> Players = new List<IPlayer>();
        protected IPlayer Winner;
        
        [OneTimeSetUp]
        public void Arrange()
        {
            deck = new Deck();
            deck.Setup();
            Sut = new HandEvaluator();
            PlayerJen.Hands.Add(new Card(Suit.Clubs, Value.Seven));
            PlayerJen.Hands.Add(new Card(Suit.Spades, Value.Seven));

            for (int i = 0; i < 3; i++)
            {
                PlayerJen.Received(deck.Pull());
            }

            Players.Add(PlayerJen);
        }

        [SetUp]
        public void Act()
        {
           Winner = Sut.Winner(Players);
        }


        [Test]
        public void Assert()
        {
            Winner.PokerHandResult.Should().Be(Hand.OnePair, "Flush is in the poker hands of a player.");
        }

    }
}
