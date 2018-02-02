using System;
using System.Collections.Generic;

namespace HeroMonster
{
    public class GameMaster
    {
        public GameMaster()
        {
            DisplayLabelTextArgs = new Dictionary<String, String>();
        }
        public Dictionary<String, String> DisplayLabelTextArgs { get; set; }
        List<Character> enemyList = new List<Character>();
        List<Character> characterTurnOrder = new List<Character>();
        Dice dice = new Dice();
        Character activeCharacter;
        Character activeTarget;
        int activeCharacterTurnIndex = 0;

        Character hero = new Character
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
            characterTurnOrder.Add(hero);
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

        public void EnterBattleLoop()
        {
            DetermineActiveCharacter();
            if (activeCharacter == hero) HeroAttackSequence();
            else HeroDefendSequence();
        }

        private void DetermineActiveCharacter()
        {
            if (activeCharacterTurnIndex == characterTurnOrder.Count) ResetCharacterTurnIndex();
            SetActiveCharacterAndIterate();
        }

        private void SetActiveCharacterAndIterate()
        {
            activeCharacter = characterTurnOrder.ElementAt(activeCharacterTurnIndex);
            activeCharacterTurnIndex++;
        }

        private void ResetCharacterTurnIndex()
        {
            activeCharacterTurnIndex = 0;
        }

        private void HeroAttackSequence()
        {
            var damage = RollForAttack();
            SelectActiveTarget();
            activeTarget.ApplyDamage(damage);
            AddDisplayTextArg("damage", damage.ToString());
            AddDisplayTextArg("attackerName", hero.Name);
            AddDisplayTextArg("defenderName", activeTarget.Name);
            AddDisplayTextArg("healthRemaining", activeTarget.Health.ToString());
            UpdateDisplayLabel();
            if (activeTarget.Health == 0) RemoveFromEnemyList();
            if (CheckForRemainingEnemies()) EnterBattleLoop();
            else return;
        }

        private void HeroDefendSequence()
        {
            hero.ApplyDamage(RollForAttack());
            if (hero.Health == 0) return;
            else EnterBattleLoop();
        }

        private void SelectActiveTarget()
        {
            activeTarget = enemyList.ElementAt(dice.Roll(0, enemyList.Count - 1));
        }

        public int RollForAttack()
        {
            return dice.RollForAttack(activeCharacter.DamageMax);

        }

        private void RemoveFromEnemyList()
        {
            enemyList.Remove(activeTarget);
        }

        private bool CheckForRemainingEnemies()
        {
            if (enemyList.Count != 0) return true;
            else return false;
        }

        public void DisplayTextInitializer()
        {
            this.DisplayLabelTextArgs.Add("attackerName", "");
            this.DisplayLabelTextArgs.Add("defenderName", "");
            this.DisplayLabelTextArgs.Add("damage", "");
            this.DisplayLabelTextArgs.Add("healthRemaining", "");
        }

        private void AddDisplayTextArg(string key, string value)
        {
            DisplayLabelTextArgs[key] = value;
        }

        public void UpdateDisplayLabel()
        {
            DisplayAttackResult();
        }
    }
}










