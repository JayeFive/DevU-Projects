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

        public void DealEntireDeck(Player[] players, DeckOfCards deck)
        {
            while (deck.StandardDeck.Count > 0)
            {
                foreach(var player in players)
                {
                    player.PlayerHand.Push(deck.StandardDeck[0]);
                    deck.StandardDeck.Remove(deck.StandardDeck[0]);
                }
            }
        }

        public Card DealCard(DeckOfCards deck)
        {

            Card cardToBeDealt = deck.StandardDeck[random.Next(0, deck.StandardDeck.Count)];
            //deck.StandardDeck.Remove(cardToBeDealt);
            return cardToBeDealt;
        }
    }
}
