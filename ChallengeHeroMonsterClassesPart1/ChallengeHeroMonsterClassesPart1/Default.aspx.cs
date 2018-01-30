using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MainGameSequence();
    }

    const int numEnemiesToSpawn = 1;     // To be used later to spawn multiple enemies
    GameMaster gameMaster = new GameMaster();

    private void MainGameSequence()
    {
        var resultLabel = ResultLabel;
        gameMaster.CreateEnemyList(numEnemiesToSpawn);
        gameMaster.PopulateCharacterTurnOrder();
        gameMaster.RollForInitiative();
        gameMaster.DetermineCharacterTurnOrder();
        gameMaster.EnterBattleLoop();
    }


    //private void DisplayAttackResult(string attackerName, string defenderName, int damage, int health)
    //{
    //    ResultLabel.Text += String.Format("<p>{0} attacks {1} for {2} damage! {1} has {3} health left.</p>",
    //        attackerName, defenderName, damage, health);
    //}

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


class GameMaster
{
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
        characterTurnOrder.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));
    }

    public void EnterBattleLoop()
    {
        SelectActiveCharacter();
        if (activeCharacter == hero) HeroAttackSequence();
        else HeroDefendSequence();
    }

    private void SelectActiveCharacter()
    {
        if (activeCharacterTurnIndex < characterTurnOrder.Count)
        {
            activeCharacter = characterTurnOrder.ElementAt(activeCharacterTurnIndex);
            activeCharacterTurnIndex++;
        }
        else
        {
            activeCharacterTurnIndex = 0;
            activeCharacter = characterTurnOrder.ElementAt(activeCharacterTurnIndex);
        }
    }

    private void HeroAttackSequence()
    {
        SelectActiveTarget();
        activeTarget.ApplyDamage(RollForAttack());
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
}

class Character
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

class Dice
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








