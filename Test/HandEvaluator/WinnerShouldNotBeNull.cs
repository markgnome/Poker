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
    public class WinnerShouldNotBeNull
    {
        protected IHandEvaluator Sut;
        protected IPlayer PlayerJoe = new Player("Joe");
        protected IPlayer PlayerJen = new Player("Jen");
        protected IPlayer PlayerBob = new Player("Bob");
        protected Hand PokerHandResult;
        protected IDeck Deck;
        protected List<IPlayer> Players = new List<IPlayer>();
        protected IPlayer Winner;
        
        [OneTimeSetUp]
        public void Arrange()
        {
            Deck = new Deck();
            Deck.Setup();
            Sut = new HandEvaluator();
            for (int i = 0; i < 5; i++)
            {
                PlayerJen.Received(Deck.Pull());
                PlayerJoe.Received(Deck.Pull());
                PlayerBob.Received(Deck.Pull());
            }

            Players.Add(PlayerJoe);
            Players.Add(PlayerJen);
            Players.Add(PlayerBob);

        }

        [SetUp]
        public void Act()
        {
           Winner = Sut.Winner(Players);
        }


        [Test]
        public void Assert()
        {
            Winner.Should().NotBeNull();
        }

    }
}
