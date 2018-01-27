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
        int damage;
        int healthRemaining;

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

        monster.Defend(hero.Attack(out damage), out healthRemaining);
        LabelDisplayGenerator(hero.Name, monster.Name, damage, healthRemaining);
        hero.Defend(monster.Attack(out damage), out healthRemaining);
        LabelDisplayGenerator(monster.Name, hero.Name, damage, healthRemaining);
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

    public int Attack(out int damage)
    {
        damage = random.Next(0, DamageMax);
        return damage;
    }

    public void Defend(int damage, out int healthRemaining)
    {
        healthRemaining = Health - damage;
        Health = healthRemaining;
    }
}