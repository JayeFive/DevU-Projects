using System;
using System.Collections.Generic;

namespace GameOfWar 
{
    public class Dealer
    {
        Random random = new Random();


        public void ShuffleCards<T>(this IList<T> list) 
        {
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = random.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }


        public Card DealCard(DeckOfCards deck)
        {
            return null;
        }
    }
}
