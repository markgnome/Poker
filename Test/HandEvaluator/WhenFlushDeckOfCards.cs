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
    public class WhenFlushDeckOfCards
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
            for (int i = 0; i < 5; i++)
            {
                var q = false;
                while (!q)
                {
                    var card = deck.Pull();
                    if (card.CardSuit == Suit.Clubs)
                    {
                        PlayerJen.Received(card);
                        q = true;
                    }
                    else { q = false; }
                }
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
            Winner.PokerHandResult.Should().Be(Hand.Flush, "Flush is in the poker hands of a player.");
        }

    }
}
