using System;
using System.Collections.Generic;

namespace StraightFlush.Program
{
    public class CardGameSimulator
    {
        private List<IRule> _rules;
        

        public CardGameSimulator(List<IRule> rules)
        {
            _rules = rules; 
        }

        public int RunGame()
        {
            Deck deck = new Deck();
            bool gameComplete = false;
            int tries = 0;
            Hand hand = new Hand(deck.DrawCards(5));
            while (!gameComplete)
            {
                tries++;
                deck.ShuffledDeck();
                hand = new Hand(deck.DrawCards(5));
                gameComplete = CheckHand(hand);
            }
            hand.PrintHand();

            return tries;
        }
        

        private bool CheckHand(Hand hand)
        {
            foreach (var rule in _rules)
            {
                if (!rule.CheckRule(hand))
                {
                    return false; 
                }
            }
            return true; 
        }

    }
}
