using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        //dice.numSides = hero.DamageMax;
        //monster.Defend(hero.Attack(dice, out int damage), out int healthRemaining);
        //LabelDisplayGenerator(hero.Name, monster.Name, damage, healthRemaining);

        //dice.numSides = monster.DamageMax;
        //hero.Defend(monster.Attack(dice, out damage), out healthRemaining);
        //LabelDisplayGenerator(monster.Name, hero.Name, damage, healthRemaining);

        AttackSequence(hero, monster, dice);
    }

    // Battle sequence
    private void AttackSequence(Character attacker, Character defender, Dice dice)
    {
        dice.numSides = attacker.DamageMax;
        defender.Defend(attacker.Attack(dice, out int damage), out int healthRemaining);
        LabelDisplayGenerator(attacker.Name, defender.Name, damage, healthRemaining);

    }

    // Display the attack and health remaining
    private void LabelDisplayGenerator(string attackerName, string defenderName, int damage, int health)
    {
        ResultLabel.Text += String.Format("{0} attacks {1} for {2} damage! {1} has {3} health left. <br />",
            attackerName, defenderName, damage, health);
    }
}

class Character
{
    Random random = new Random();

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
