using System;
using System.Collections.Generic;
using System.Linq;

namespace StraightFlush.Program
{

    public class FlushRule : IRule
    {
        public bool CheckRule(Hand hand)
        {
            var thisHand = hand.ShowHand();
            var ThisSuit = thisHand[0].Suit;

            foreach (Card card in hand.ShowHand())
            {
                if (ThisSuit != card.Suit)
                {
                    return false;
                }
            }
            return true;

        }

    }

    public class StraightRule : IRule
    {
        public bool CheckRule(Hand hand)
        {
            //TODO: clean up
            var thisHand = hand.ShowHand();
            var valuesInHand = thisHand.Select(card => card.Value).ToList();

            List<List<int>> valuesInHandList = new List<List<int>>
            {
                valuesInHand
            };


            if (valuesInHand.Contains(1)) // if ace must analyze two hands
            {
                List<int> valuesAceHigh = new List<int>(valuesInHand);
                valuesAceHigh.Remove(1);
                valuesAceHigh.Add(14);
                valuesInHandList.Add(valuesAceHigh);
            }

            var handIsOk = new List<bool>();

            foreach (List<int> values in valuesInHandList)
            {
                handIsOk.Add(CheckIfStraigh(values));
            }
            return handIsOk.Contains(true);
        }



        private bool CheckIfStraigh(List<int> valuesInHand)
        {
            var diff = valuesInHand.Max() - valuesInHand.Min();
            if (diff != 4)
            {
                return false;

            }

            if (valuesInHand.Distinct().Count() != valuesInHand.Count())
            {
                return false;

            }
            return true;


        }

      
    }

    public class RoyalRule : IRule
    {
        public bool CheckRule(Hand hand)
        {
            
            var thisHand = hand.ShowHand();
            var valuesInHand = thisHand.Select(card => card.Value).ToList();
            var straigh = new StraightRule(); 
            return (valuesInHand.Max() == 13 & valuesInHand.Min() == 1 & straigh.CheckRule(hand));

        }
    }
       

}
