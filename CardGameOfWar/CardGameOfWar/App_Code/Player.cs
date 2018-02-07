using System.Collections.Generic;

namespace GameOfWar
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> PlayerHand { get; set; }

        public Player()
        {
            PlayerHand = new List<Card>();
        }
    }


}
