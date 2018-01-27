using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Character hero = new Character
        {
            Name = "Johnny",
            Health = 100,
            DamageMax = 20,
            AttackBonus = 3
        };

        Character monster = new Character
        {
            Name = "Ogre",
            Health = 120,
            DamageMax = 15,
            AttackBonus = 6
        };

        Dice dice = new Dice();

        // This is the main battle sequence call that sends the control through the program
        // Hero attacks first, ofcourse!
        MainBattleSequence(hero, monster, dice);
    }

    // Single attack sequence
    private bool AttackSequence(Character attacker, Character defender, Dice dice)
    {
        dice.numSides = attacker.DamageMax;     // Set dice size
        defender.Defend(attacker.Attack(dice, out int damage), out int healthRemaining);    // Fight
        DisplayAttackSequenceStats(attacker.Name, defender.Name, damage, healthRemaining);  // Display results

        if (defender.Health <= 0) return false;      // return false to stop main sequence
        else return true;                            // or true to keep the fight going
    }

    // Main battle sequence -- runs until either Character is dead
    private void MainBattleSequence(Character attacker, Character defender, Dice dice)
    {
        while (AttackSequence(attacker, defender, dice) && AttackSequence(defender, attacker, dice)) ;

        DisplayVictoryText(attacker, defender);     // while loop breaks when defender dies
    }

    // Display the attack result and health remaining of defending character
    private void DisplayAttackSequenceStats(string attackerName, string defenderName, int damage, int health)
    {
        ResultLabel.Text += String.Format("<p>{0} attacks {1} for {2} damage! {1} has {3} health left.</p>",
            attackerName, defenderName, damage, health);
    }

    private void DisplayVictoryText(Character winner, Character loser)
    {
        ResultLabel.Text += String.Format("{0} has slain {1}!", winner.Name, loser.Name);
    }
}

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int DamageMax { get; set; }
    public int AttackBonus { get; set; }

    public int Attack(Dice dice, out int damage)
    {
        damage = dice.roll();
        return damage;
    }

    public void Defend(int damage, out int healthRemaining)
    {
        healthRemaining = Health - damage;
        Health = healthRemaining;
    }
}

class Dice
{
    Random random = new Random();

    public int numSides { get; set; }

    public int roll()
    {
        return random.Next(1, this.numSides);
    }
}
