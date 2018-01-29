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
            AttackBonus = 15
        };

        Character monster = new Character
        {
            Name = "Ogre",
            Health = 120,
            DamageMax = 15,
            AttackBonus = 4
        };

        Dice dice = new Dice();
        GameMaster gameMaster = new GameMaster();

        // This is the main battle sequence call that sends the control through the program
        // Hero attacks first, ofcourse!
        MainBattleSequence(hero, monster, dice);
    }






    // ************************************************* //
    // These methods display results to the result label //
    private void DisplayAttackResult(string attackerName, string defenderName, int damage, int health)
    {
        ResultLabel.Text += String.Format("<p>{0} attacks {1} for {2} damage! {1} has {3} health left.</p>",
            attackerName, defenderName, damage, Math.Max(health, 0));
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

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int DamageMax { get; set; }
    public int AttackBonus { get; set; }

    public int Attack(Dice dice, out int damage)
    {
        damage = dice.Roll();
        return damage;
    }

    public void Defend(int damage, out int health)
    {
        health = this.Health - damage;
    }
}

class Dice
{
    Random random = new Random();

    public int NumSides { get; set; }

    public int Roll(int minRoll, int maxRoll)
    {
        return random.Next(minRoll, maxRoll);
    }

    public bool RollForExtraAttack(Character attacker)
    {
        if (random.Next(1, 100) <= attacker.AttackBonus) return true;
        else return false;
    }
}

class GameMaster
{
    public int RollForAttack(int damageMax, Dice dice)
    {
        return dice.Roll(1, damageMax);
    }

    public void ApplyDamage(Character defender, int damageDone)
    {
        defender.Health -= damageDone;
    }

    public bool RollForExtraAttackChance(int attackBonus, Dice dice)
    {
        if (dice.Roll(1, 100) <= attackBonus) return true;
        else return false;
    }
}
