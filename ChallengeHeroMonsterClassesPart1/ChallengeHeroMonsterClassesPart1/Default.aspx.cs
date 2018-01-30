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

    const int numEnemiesToSpawn = 1;     // To be used later for multiple enemies
    Dice dice = new Dice();
    GameMaster gameMaster = new GameMaster();

    Character hero = new Character
    {
        Name = "Johnny",
        Health = 100,
        DamageMax = 20,
        AttackBonus = 15,
        InitiativeRoll = 10
    };

    // Generic checks //
    private bool DetermineIncapacitation(int health)
    {
        if (health == 0) return true;
        else return false;
    }

    // ***************************** //
    // ******** Game Events ******** //
    private void MainGameSequence()
    {
        var enemyList = gameMaster.CreateEnemyList(numEnemiesToSpawn);
        var turnOrder = InitializeCombat();
        PerformCombatRound(dice, turnOrder, enemyList);
    }

    private Character[] InitializeCombat()
    {
        hero.Initiative = dice.RollForInitiative(hero.InitiativeRoll);
        return gameMaster.DetermineTurnOrder(dice, hero);
    }

    private void PerformCombatRound(Dice dice, Character[] turnOrder, Character[] enemyList)
    {
        for (var i = 0; i < turnOrder.Length; i++)
        {
            if (turnOrder[i] == hero) PerformAttack(dice, enemyList);
            else PerformAttack(dice, turnOrder[i]);
        }
    }

    private void PerformAttack(Dice dice, Character[] enemyList)
    {
        var enemyToAttack = dice.GenerateRandomNumber(1, enemyList.Length);
        gameMaster.ApplyDamage(enemyList[enemyToAttack], dice.RollForAttack(hero.DamageMax)); 
    }
    
    private void PerformAttack(Dice dice, Character enemy)
    {
        gameMaster.ApplyDamage(hero, dice.RollForAttack(enemy.DamageMax));
    }



    // ************************************************* //
    // These methods display results to the result label //
    private void DisplayAttackResult(string attackerName, string defenderName, int damage, int health)
    {
        ResultLabel.Text += String.Format("<p>{0} attacks {1} for {2} damage! {1} has {3} health left.</p>",
            attackerName, defenderName, damage, health);
    }

    private void DisplayExtraAttackSequenceStats(string attackerName, string defenderName, int damage, int health)
    {
        ResultLabel.Text += String.Format("<p>{0} gains an extra attack for {2} damage! {1} has {3} health left.</p>",
            attackerName, defenderName, damage, health);
    }

    //private void DisplayVictoryText(Character winner, Character loser)
    //{
    //    ResultLabel.Text += String.Format("{0} has slain {1}!", winner.Name, loser.Name);
    //}
    // ************************************************* //
}

// ********************************* //
// ********** All classes ********** //
class GameMaster
{
    List<Character> enemyList = new List<Character>();
    List<Character> turnOrder = new List<Character>();

    public Character[] CreateEnemyList(int numEnemiesToSpawn)
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

        return enemyList.ToArray();
    }

    public Character[] DetermineTurnOrder(Dice dice, Character hero)
    {
        turnOrder.Add(hero);
        RollForNPCInitiative(dice);
        turnOrder.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));

        return turnOrder.ToArray();
    }

    private void RollForNPCInitiative(Dice dice)
    {
        foreach (var enemy in enemyList)
        {
            enemy.Initiative = dice.RollForInitiative(enemy.InitiativeRoll);
        }
    }

    public void ApplyDamage(Character defender, int damageDone)
    {
        defender.Health -= damageDone;
        if (defender.Health < 0) defender.Health = 0;
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

    public int GenerateRandomNumber(int min, int max)
    {
        return random.Next(min, max);
    }
}
// *********** //


