using System;
using System.Collections.Generic;

namespace HeroMonster
{
    public class GameMaster
    {
        public GameMaster()
        {

        }
        public Character ActiveCharacter { get; set; }
        public int ActiveCharacterTurnIndex { get; set; }
        public Character ActiveTarget { get; set; }
        public List<Character> characterTurnOrder = new List<Character>();
        public List<Character> enemyList = new List<Character>();
        Dice dice = new Dice();

        public Character Hero = new Character
        {
            Name = "Johnny",
            Health = 100,
            DamageMax = 20,
            AttackBonus = 15,
            InitiativeRoll = 10
        };

        public void CreateEnemyList(int numEnemiesToSpawn)
        {
            for (var i = 0; i < numEnemiesToSpawn; i++)
            {
                enemyList.Add(new Character
                {
                    Name = "Ogre" + (i + 1),
                    Health = 120,
                    DamageMax = 15,
                    AttackBonus = 4,
                    InitiativeRoll = 2
                });
            }
        }

        public void PopulateCharacterTurnOrder()
        {
            characterTurnOrder.Add(Hero);
            foreach (var enemy in enemyList) characterTurnOrder.Add(enemy);
        }

        public void RollForInitiative()
        {
            foreach (var participant in characterTurnOrder) participant.Initiative = dice.RollForInitiative(participant.InitiativeRoll);
        }

        public void DetermineCharacterTurnOrder()
        {
            characterTurnOrder.Sort((x, y) => y.Initiative.CompareTo(x.Initiative));
        }


    }
}










