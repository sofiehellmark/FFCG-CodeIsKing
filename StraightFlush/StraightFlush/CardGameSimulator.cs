using System;
using System.Collections.Generic;
using System.Linq;

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
            bool GameComplete = false;
            var tries = 0;

            while (!GameComplete)
            {
                tries++;
                deck.ShuffledDeck();
                Hand hand = new Hand(deck.DrawCards(5));
                GameComplete = CheckHand(hand);
            }
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
