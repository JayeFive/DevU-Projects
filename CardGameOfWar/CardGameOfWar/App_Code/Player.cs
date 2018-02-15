using System.Collections.Generic;

namespace GameOfWar
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Hand { get; set; }
        public Card TopCard { get; set; }

        public Player()
        {
            Hand = new Queue<Card>();
        }
    }
}
