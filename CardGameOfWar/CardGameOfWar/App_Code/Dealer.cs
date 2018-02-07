using System;
using System.Collections.Generic;

namespace GameOfWar 
{
    public class Dealer
    {
        Random random = new Random();

        public void ShuffleCards(DeckOfCards deck)
        {
            const int numberTimesToShuffle = 7;

            for (int i = 0; i < (deck.StandardDeck.Count * numberTimesToShuffle); i++)
            {
                Card shuffleCard = new Card();
                shuffleCard = deck.StandardDeck[random.Next(0, deck.StandardDeck.Count)];
                deck.StandardDeck.Remove(shuffleCard);
                deck.StandardDeck.Add(shuffleCard);
            }
        }

        public Card DealCard(DeckOfCards deck)
        {
            return null;
        }
    }
}
