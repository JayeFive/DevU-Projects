using System;
using System.Collections.Generic;

namespace GameOfWar 
{
    public class Dealer
    {
        Random random = new Random();

        public void ShuffleCards(DeckOfCards deck)
        {
            List<Card> tempStack = new List<Card>();

            while(deck.StandardDeck.Count > 0)
            {
                Card tempCard = new Card();

                tempCard = (deck.StandardDeck[random.Next(0, deck.StandardDeck.Count)]);
                deck.StandardDeck.Remove(tempCard);
                tempStack.Add(tempCard);
            }

            deck.StandardDeck = tempStack;

            //foreach (var card in tempStack)
            //{
            //    deck.StandardDeck.Add(card);
            //    tempStack.Remove(card);
            //}
            
        }


        public Card DealCard(DeckOfCards deck)
        {
            return null;
        }
    }
}
