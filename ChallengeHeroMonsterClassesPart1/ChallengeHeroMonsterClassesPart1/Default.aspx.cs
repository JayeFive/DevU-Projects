using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

        NonPlayerCharacter monster = new NonPlayerCharacter
        {
            Name = "Ogre",
            Health = 120,
            DamageMax = 15,
            AttackBonus = 4,
            Initiative = 2
        };
    }


    // ***************************** //
    // Game logic and generic events //
    private int RollForInitiative(int initiative, Dice dice)
    {
        return dice.Roll(1, initiative);
    }

    private int RollForAttack(int damageMax, Dice dice)
    {
        return dice.Roll(1, damageMax);
    }

    private bool RollForExtraAttackChance(int attackBonus, Dice dice)
    {
        if (dice.Roll(1, 100) <= attackBonus) return true;
        else return false;
    }

    private bool DetermineIncapacitation(int health)
    {
        if (health <= 0) return true;
        else return false;
    }
    // ***************************** //










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
    object[] turnOrder;

    public object[] DetermineTurnOrder()
    {

    }

    public void DetermineActiveCharacter ()
    {

    }

    private void ApplyDamage(NonPlayerCharacter defender, int damageDone)
    {
        defender.Health -= damageDone;
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


