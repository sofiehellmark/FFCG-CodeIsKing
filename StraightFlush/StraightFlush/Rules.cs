using System;
using System.Collections.Generic;
using System.Linq;

namespace StraightFlush.Program
{

    public class FlushRule : IRule
    {
        // Test one correct hand and one incorrect
        public bool CheckRule(Hand hand)
        {
            var thisHand = hand.showHand();
            var ThisSuit = thisHand[0].Suit;

            foreach (Card card in hand.showHand())
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
            var thisHand = hand.showHand();
            var values = thisHand.Select(card => card.Value).ToList();

            List<List<int>> valuesList = new List<List<int>>
            {
                values
            };


            if (values.Contains(1))
            {
                List<int> values2 = new List<int>(values);
                values2.Remove(1);
                values2.Add(14);
                valuesList.Add(values2);

            }
            // Here only needs to be correct in one of them
            var hand_ok = new List<bool>();
            foreach (List<int> v in valuesList)
            {
                var diff = v.Max() - v.Min();
                if (diff != 4)
                {
                    hand_ok.Add(false);
                    continue;

                }

                if (v.Distinct().Count() != v.Count())
                {
                    hand_ok.Add(false);
                    continue;


                }

                hand_ok.Add(true);

            }


            return hand_ok.Contains(true);
        }
    }
}
