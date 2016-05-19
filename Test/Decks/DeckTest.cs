using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Logic;

namespace Test
{
    /// <summary>
    /// Using VS Unit Testing
    /// </summary>
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void DeckPullCardShouldBeEqual()
        {
            //Arrange
            IDeck deck = new Deck();

            //Act
            deck.Setup();

            //Assert
            Assert.AreNotEqual(deck.Pull(), deck.Pull());
        }
    }
}
