using System;
using System.Collections.Generic;
using System.Linq;
using HeroMonster;



public partial class _Default : System.Web.UI.Page 
{
    const int numEnemiesToSpawn = 1;     // To be used later to spawn multiple enemies
    GameMaster gameMaster = new GameMaster();
    Dice dice = new Dice();
    Dictionary<String, String> DisplayLabelTextArgs = new Dictionary<String, String>();

    protected void Page_Load(object sender, EventArgs e)
    {
        MainGameSequence();
        gameMaster.ActiveCharacterTurnIndex = 0;
    }

    private void MainGameSequence()
    {
        DisplayTextInitializer();
        gameMaster.CreateEnemyList(numEnemiesToSpawn);
        gameMaster.PopulateCharacterTurnOrder();
        gameMaster.RollForInitiative();
        gameMaster.DetermineCharacterTurnOrder();
        EnterBattleLoop();
    }

    public void DisplayTextInitializer()
    {
        DisplayLabelTextArgs.Add("attackerName", "");
        DisplayLabelTextArgs.Add("defenderName", "");
        DisplayLabelTextArgs.Add("damage", "");
        DisplayLabelTextArgs.Add("healthRemaining", "");
    }

    public void EnterBattleLoop()
    {
        DetermineActiveCharacter();
        if (gameMaster.ActiveCharacter == gameMaster.Hero) HeroAttackSequence();
        else HeroDefendSequence();
    }

    private void DetermineActiveCharacter()
    {
        if (gameMaster.ActiveCharacterTurnIndex == gameMaster.characterTurnOrder.Count) ResetCharacterTurnIndex();
        SetActiveCharacterAndIterate();
    }

    private void SetActiveCharacterAndIterate()
    {
        gameMaster.ActiveCharacter = gameMaster.characterTurnOrder.ElementAt(gameMaster.ActiveCharacterTurnIndex);
        gameMaster.ActiveCharacterTurnIndex++;
    }

    private void ResetCharacterTurnIndex()
    {
        gameMaster.ActiveCharacterTurnIndex = 0;
    }

    private void HeroAttackSequence()
    {
        var damage = RollForAttack();
        SelectActiveTarget();
        gameMaster.ActiveTarget.ApplyDamage(damage);
        AddDisplayTextArg("damage", damage.ToString());
        AddDisplayTextArg("attackerName", gameMaster.Hero.Name);
        AddDisplayTextArg("defenderName", gameMaster.ActiveTarget.Name);
        AddDisplayTextArg("healthRemaining", gameMaster.ActiveTarget.Health.ToString());
        UpdateDisplayLabel();
        if (gameMaster.ActiveTarget.Health == 0) RemoveFromEnemyList();
        if (CheckForRemainingEnemies()) EnterBattleLoop();
        else return;
    }

    private void HeroDefendSequence()
    {
        var damage = RollForAttack();
        gameMaster.Hero.ApplyDamage(damage);
        AddDisplayTextArg("damage", damage.ToString());
        AddDisplayTextArg("attackerName", gameMaster.ActiveCharacter.Name);
        AddDisplayTextArg("defenderName", gameMaster.Hero.Name);
        AddDisplayTextArg("healthRemaining", gameMaster.Hero.Health.ToString());
        UpdateDisplayLabel();
        if (gameMaster.Hero.Health == 0) return;
        else EnterBattleLoop();
    }

    private void SelectActiveTarget()
    {
        gameMaster.ActiveTarget = gameMaster.enemyList.ElementAt(dice.Roll(0, gameMaster.enemyList.Count - 1));
    }

    public int RollForAttack()
    {
        return dice.RollForAttack(gameMaster.ActiveCharacter.DamageMax);

    }

    private void RemoveFromEnemyList()
    {
        gameMaster.enemyList.Remove(gameMaster.ActiveTarget);
    }

    private bool CheckForRemainingEnemies()
    {
        if (gameMaster.enemyList.Count != 0) return true;
        else return false;
    }

    private void AddDisplayTextArg(string key, string value)
    {
        DisplayLabelTextArgs[key] = value;
    }

    public void UpdateDisplayLabel()
    {
        DisplayAttackResult();
    }

    public void DisplayAttackResult()
    {
        ResultLabel.Text += String.Format("<p>{0} attacks {1} for {2} damage! {1} has {3} health left.</p>",
            DisplayLabelTextArgs["attackerName"],
            DisplayLabelTextArgs["defenderName"],
            DisplayLabelTextArgs["damage"],
            DisplayLabelTextArgs["healthRemaining"]);
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










