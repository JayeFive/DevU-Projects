using System;

namespace HeroMonster
{
    public class Dice
    {
        public int NumSides { get; set; }

        Random random = new Random();

        public int Roll(int minRoll, int maxRoll)
        {
            return random.Next(minRoll, maxRoll);
        }

        public int RollForInitiative(int initiative)
        {
            return this.Roll(1, initiative);
        }

        public int RollForAttack(int damageMax)
        {
            return this.Roll(1, damageMax);
        }

        public bool RollForExtraAttackChance(int attackBonus)
        {
            if (this.Roll(1, 100) <= attackBonus) return true;
            else return false;
        }
    }
}









