using System;
using System.Linq;
using HeroMonster;


    public partial class _Default : System.Web.UI.Page
    {
        const int numEnemiesToSpawn = 1;     // To be used later to spawn multiple enemies
        GameMaster gameMaster = new GameMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            MainGameSequence();
        }

        private void MainGameSequence()
        {
            gameMaster.DisplayTextInitializer();
            gameMaster.CreateEnemyList(numEnemiesToSpawn);
            gameMaster.PopulateCharacterTurnOrder();
            gameMaster.RollForInitiative();
            gameMaster.DetermineCharacterTurnOrder();
            gameMaster.EnterBattleLoop();
        }

        public void DisplayAttackResult()
        {
            ResultLabel.Text += String.Format("<p>{0} attacks {1} for {2} damage! {1} has {3} health left.</p>",
                gameMaster.DisplayLabelTextArgs.TryGetValue("attackerName", out string attackerName),
                gameMaster.DisplayLabelTextArgs.TryGetValue("defenderName", out string defenderName),
                gameMaster.DisplayLabelTextArgs.TryGetValue("damage", out string damage),
                gameMaster.DisplayLabelTextArgs.TryGetValue("healthRemaining", out string healthRemaining));
        }




        //private void DisplayExtraAttackSequenceStats(string attackerName, string defenderName, int damage, int health)
        //{
        //    ResultLabel.Text += String.Format("<p>{0} gains an extra attack for {2} damage! {1} has {3} health left.</p>",
        //        attackerName, defenderName, damage, health);
        //}

        //public void DisplayCharacterIncapacitation(string defenderName)
        //{
        //    ResultLabel.Text = String.Format("<p>{0} has been slain!</p>", defenderName);
        //}
    }










