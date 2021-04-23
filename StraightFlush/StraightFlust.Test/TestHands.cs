using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StraightFlush.Program;
namespace StraightFlust.Test
{
    [TestClass]
    public class TestHands // One class to check flush and one to check straight 
    {



        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void CorrectFlush()
        {
            var rule = new FlushRule();
            var cardsInHand = new List<Card>
            {
                new Card(1, Suits.Heart),
                new Card(1, Suits.Heart),
                new Card(1, Suits.Heart),
                new Card(1, Suits.Heart),
                new Card(1, Suits.Heart),

            };

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);
            //result.Should().BeTrue(); 
        }

        [TestMethod]
        public void IncorrectFlush()
        {
            var rule = new FlushRule();
            var cardsInHand = new List<Card>(5);
            cardsInHand.Add(new Card(1, Suits.Heart));
            cardsInHand.Add(new Card(1, Suits.Diamonds));
            cardsInHand.Add(new Card(1, Suits.Diamonds));
            cardsInHand.Add(new Card(1, Suits.Diamonds));
            cardsInHand.Add(new Card(1, Suits.Diamonds));


            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(false, result);

        }
        [TestMethod]
        public void CorrectStraight()
        {
            var rule = new StraightRule();
            var cardsInHand = new List<Card>(5);

            cardsInHand.Add(new Card(2, Suits.Heart));
            cardsInHand.Add(new Card(3, Suits.Heart));
            cardsInHand.Add(new Card(4, Suits.Heart));
            cardsInHand.Add(new Card(5, Suits.Heart));
            cardsInHand.Add(new Card(6, Suits.Heart));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void CorrectStraightLowAce()
        {
            var rule = new StraightRule();
            var cardsInHand = new List<Card>(5);
           
            cardsInHand.Add(new Card(1, Suits.Heart));
            cardsInHand.Add(new Card(2, Suits.Heart));
            cardsInHand.Add(new Card(3, Suits.Heart));
            cardsInHand.Add(new Card(4, Suits.Heart));
            cardsInHand.Add(new Card(5, Suits.Heart));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CorrectStraightHighAce()
        {
            var rule = new StraightRule();
            var cardsInHand = new List<Card>(5);

            cardsInHand.Add(new Card(1, Suits.Heart));
            cardsInHand.Add(new Card(11, Suits.Heart));
            cardsInHand.Add(new Card(12, Suits.Heart));
            cardsInHand.Add(new Card(13, Suits.Heart));
            cardsInHand.Add(new Card(10, Suits.Heart));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IncorrectStraight()
        {
            var rule = new StraightRule();
            var cardsInHand = new List<Card>(5);

            cardsInHand.Add(new Card(1, Suits.Heart));
            cardsInHand.Add(new Card(9, Suits.Heart));
            cardsInHand.Add(new Card(3, Suits.Heart));
            cardsInHand.Add(new Card(4, Suits.Heart));
            cardsInHand.Add(new Card(5, Suits.Heart));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(false, result);
        }


        [TestMethod]
        public void CorrectRoyal()
        {
            var rule = new RoyalRule();
            var cardsInHand = new List<Card>(5);

            cardsInHand.Add(new Card(1, Suits.Heart));
            cardsInHand.Add(new Card(13, Suits.Heart));
            cardsInHand.Add(new Card(12, Suits.Heart));
            cardsInHand.Add(new Card(11, Suits.Heart));
            cardsInHand.Add(new Card(10, Suits.Heart));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);
        }
    }
}
