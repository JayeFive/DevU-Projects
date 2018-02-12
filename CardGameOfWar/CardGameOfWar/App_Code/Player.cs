using System.Collections.Generic;

namespace GameOfWar
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> PlayerHand { get; set; }

        public Player()
        {
            PlayerHand = new Queue<Card>();
        }
    }
}
