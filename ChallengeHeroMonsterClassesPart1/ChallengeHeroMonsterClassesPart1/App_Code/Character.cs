using System;

namespace HeroMonster 
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMax { get; set; }
        public int AttackBonus { get; set; }
        public int InitiativeRoll { get; set; }
        public int Initiative { get; set; }

        internal void ApplyDamage(int damage)
        {
            this.Health -= damage;
            if (this.Health < 0) Health = 0;
        }
    }
}








