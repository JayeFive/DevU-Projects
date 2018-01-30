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

    // ***************************** //
    // ******** Game Events ******** //
    private void MainGameSequence()
    {
        var heroIsIncapacitated = false;
        var enemyList = gameMaster.CreateEnemyList(numEnemiesToSpawn);
        var characterTurnOrder = InitializeCombat();

        while (!heroIsIncapacitated)
        {
            PerformCombatRound(dice, characterTurnOrder, enemyList, out heroIsIncapacitated);
        }
    }

    private List<Character> InitializeCombat()
    {
        hero.Initiative = dice.RollForInitiative(hero.InitiativeRoll);
        return gameMaster.CreateCharacterTurnOrder(dice, hero);
    }

    private void PerformCombatRound(Dice dice, List<Character> characterTurnOrder, List<Character> enemyList, out bool heroIsIncapacitated)
    {
        heroIsIncapacitated = false;
        foreach(var character in characterTurnOrder)
        {
            if (character == hero) PerformAttack(dice, enemyList);
            else PerformAttack(dice, character, out heroIsIncapacitated);
        }
    }

    private void PerformAttack(Dice dice, List<Character> enemyList)    // Hero Attack
    {
        var enemy = enemyList.ElementAt(dice.Roll(0, enemyList.Count - 1));
        var damage = gameMaster.ApplyDamage(enemy, dice.RollForAttack(hero.DamageMax));
        DisplayAttackResult(hero.Name, enemy.Name, damage, enemy.Health);
        CheckForIncapacitation(enemyList);
    }
    
    private void PerformAttack(Dice dice, Character enemy, out bool heroIsIncapacitated)          // Enemy attack
    {
        var damage = gameMaster.ApplyDamage(hero, dice.RollForAttack(enemy.DamageMax));
        DisplayAttackResult(enemy.Name, hero.Name, damage, enemy.Health);
        CheckForIncapacitation(hero, out heroIsIncapacitated);
    }

    private void CheckForIncapacitation(List<Character> enemyList)
    {
        foreach (var enemy in enemyList)
        {
            if (enemy.Health == 0)
            {
                DisplayCharacterIncapacitation(enemy.Name);
                enemyList.Remove(enemy);
            }
        }
    }

    private void CheckForIncapacitation(Character hero, out bool heroIsIncapacitated)
    {
        if (hero.Health == 0)
        {
            DisplayCharacterIncapacitation(hero.Name);
            heroIsIncapacitated = true;
        }
        else heroIsIncapacitated = false;
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

    private void DisplayCharacterIncapacitation(string defenderName)
    {
        ResultLabel.Text = String.Format("<p>{0} has been slain!</p>", defenderName);
    }
}

// ********************************* //
// ********** All classes ********** //
class GameMaster
{
    List<Character> enemyList = new List<Character>();
    List<Character> characterTurnOrder = new List<Character>();

    public List<Character> CreateEnemyList(int numEnemiesToSpawn)
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

        return enemyList;
    }

    public List<Character> CreateCharacterTurnOrder(Dice dice, Character hero)
    {
        characterTurnOrder.Add(hero);
        RollForNPCInitiative(dice);
        foreach (var enemy in enemyList) characterTurnOrder.Add(enemy);
        characterTurnOrder.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));

        return characterTurnOrder;
    }

    private void RollForNPCInitiative(Dice dice)
    {
        foreach (var enemy in enemyList)
        {
            enemy.Initiative = dice.RollForInitiative(enemy.InitiativeRoll);
        }
    }

    public int ApplyDamage(Character defender, int damage)
    {
        defender.Health -= damage;
        if (defender.Health < 0) defender.Health = 0;

        return damage;
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
}
// *********** //


