using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    Dice dice = new Dice();
    GameMaster gameMaster = new GameMaster();

    PlayerCharacter hero = new PlayerCharacter
    {
        Name = "Johnny",
        Health = 100,
        DamageMax = 20,
        AttackBonus = 15,
        Initiative = 10
    };

    // ***************************** //
    // ******** Roll Events ******** //
    private int RollForInitiative(Dice dice, int initiative)
    {
        return dice.Roll(1, initiative);
    }

    private int RollForAttack(Dice dice, int damageMax)
    {
        return dice.Roll(1, damageMax);
    }

    private bool RollForExtraAttackChance(Dice dice, int attackBonus)
    {
        if (dice.Roll(1, 100) <= attackBonus) return true;
        else return false;
    }

    // Generic checks //
    private bool DetermineIncapacitation(int health)
    {
        if (health == 0) return true;
        else return false;
    }

    // ***************************** //
    // ******** Game Events ******** //


    private void StartCombat()
    {
        gameMaster.DetermineTurnOrder(RollForInitiative(dice, hero.Initiative));
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

    private void DisplayVictoryText(Character winner, Character loser)
    {
        ResultLabel.Text += String.Format("{0} has slain {1}!", winner.Name, loser.Name);
    }
    // ************************************************* //
}

// *********** //
// All classes //
class GameMaster
{
    object activeCharacter;
    const int numOfEnemiesToSpawn = 1; // To be used later for spawning multple enemies
    int numOfEnemies = 0;
    object[] turnOrder;

    List<NonPlayerCharacter> enemyList = new List<NonPlayerCharacter>();

    public int createEnemies()
    {
        for (var i = 0; i < numOfEnemiesToSpawn; i++)
        {
            enemyList.Add(new NonPlayerCharacter
            {
                Name = "Ogre" + (i + 1),
                Health = 120,
                DamageMax = 15,
                AttackBonus = 4,
                Initiative = 2
            });

            numOfEnemies++;
        }

        return numOfEnemies;
    }


    public object[] DetermineTurnOrder(int playerInitiative)
    {
        
    }

    public void DetermineActiveCharacter ()
    {

    }

    private void ApplyDamage(NonPlayerCharacter defender, int damageDone)
    {
        defender.Health -= damageDone;
        if (defender.Health < 0) defender.Health = 0;
    }

}

class PlayerCharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int DamageMax { get; set; }
    public int AttackBonus { get; set; }
    public int Initiative { get; set; }

    private void ApplyDamage(int damageDone)
    {
        this.Health -= damageDone;
        if (this.Health < 0) this.Health = 0;
    }
}

class NonPlayerCharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int DamageMax { get; set; }
    public int AttackBonus { get; set; }
    public int Initiative { get; set; }
}


class Dice
{
    Random random = new Random();

    public int NumSides { get; set; }

    public int Roll(int minRoll, int maxRoll)
    {
        return random.Next(minRoll, maxRoll);
    }
}
// *********** //


