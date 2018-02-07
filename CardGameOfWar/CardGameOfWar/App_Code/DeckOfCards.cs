﻿using System.Collections.Generic;

namespace GameOfWar
{
    public class DeckOfCards
    {
        public List<Card> StandardDeck { get; set; }

        public DeckOfCards()    // Constructor generates the deck
        {
            StandardDeck = new List<Card>();

            const int lowestCardNumber = 2;
            const int numberPerSuit = 14;
            string[] suits = new string[4] { "Clubs", "Spades", "Hearts", "Diamonds" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = lowestCardNumber; j <= numberPerSuit; j++)
                {
                    StandardDeck.Add(new Card { CardNumber = j, Suit = suits[i] });
                }
            }
        }
    }
}

public class Card
{
    public int CardNumber { get; set; }
    public string Suit { get; set; }
}