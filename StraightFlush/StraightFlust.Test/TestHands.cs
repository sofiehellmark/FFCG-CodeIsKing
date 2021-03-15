using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StraightFlush.Program;
namespace StraightFlust.Test
{
    [TestClass]
    public class TestHands
    {



        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void FlushRuleGetsSameColors()
        {
            var rule = new FlushRule();
            var cardsInHand = new List<Card>(5);
            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(1, "Heart"));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void FlushRuleGetsDifferentColors()
        {
            var rule = new FlushRule();
            var cardsInHand = new List<Card>(5);
            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(1, "Diamond"));
            cardsInHand.Add(new Card(1, "Diamond"));
            cardsInHand.Add(new Card(1, "Diamond"));
            cardsInHand.Add(new Card(1, "Diamond"));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(false, result);

        }


        [TestMethod]
        public void CorrectStraight()
        {
            var rule = new StraightRule();
            var cardsInHand = new List<Card>(5);
           
            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(2, "Heart"));
            cardsInHand.Add(new Card(3, "Heart"));
            cardsInHand.Add(new Card(4, "Heart"));
            cardsInHand.Add(new Card(5, "Heart"));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CorrectStraightHigh()
        {
            var rule = new StraightRule();
            var cardsInHand = new List<Card>(5);

            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(11, "Heart"));
            cardsInHand.Add(new Card(12, "Heart"));
            cardsInHand.Add(new Card(13, "Heart"));
            cardsInHand.Add(new Card(10, "Heart"));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IncorrectStraight()
        {
            var rule = new StraightRule();
            var cardsInHand = new List<Card>(5);

            cardsInHand.Add(new Card(1, "Heart"));
            cardsInHand.Add(new Card(9, "Heart"));
            cardsInHand.Add(new Card(3, "Heart"));
            cardsInHand.Add(new Card(4, "Heart"));
            cardsInHand.Add(new Card(5, "Heart"));

            var hand = new Hand(cardsInHand);
            var result = rule.CheckRule(hand);
            Assert.AreEqual(false, result);
        }
    }
}
