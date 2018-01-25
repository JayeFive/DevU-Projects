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
        Random random = new Random();

        int heroHealth = 30;
        int monsterHealth = 30;

        string result = "";

        // Hero gets bonus attack first
        monsterHealth -= random.Next(1, 40);

        int round = 0;
        result += "<br /> Round: " + round;
        result += String.Format("<br />Hero attacks first, leaving monster with {0} health",
            monsterHealth);

        // Battle logic here

        /*
        while (heroHealth > 0 && monsterHealth > 0)
        {
            int heroDamage = random.Next(1, 10);
            int monsterDamage = random.Next(1, 20);

            monsterHealth -= heroDamage;
            heroHealth -= monsterDamage;

            result += "<br />Round: " + ++round;
            result += String.Format("<br />Hero causes {0} damage, leaving monster with {1} health.",
                heroDamage, monsterHealth);
            result += String.Format("<br />Monster causes {0} damage, leaving hero with {1} health.",
                monsterDamage, heroHealth);
        }
        */

        do
        {
            int heroDamage = random.Next(1, 10);
            int monsterDamage = random.Next(1, 20);

            monsterHealth -= heroDamage;
            heroHealth -= monsterDamage;

            result += "<br />Round: " + ++round;
            result += String.Format("<br />Hero causes {0} damage, leaving monster with {1} health.",
                heroDamage, monsterHealth);
            result += String.Format("<br />Monster causes {0} damage, leaving hero with {1} health.",
                monsterDamage, heroHealth);
        } while (heroHealth > 0 && monsterHealth > 0);


        if (heroHealth > 0)
        {
            result += "<br />Hero Wins!";
        }
        else
        {
            result += "<br />Monster Wins!";
        }

        ResultLabel.Text = result;
    }
}