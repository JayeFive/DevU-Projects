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

        // Wolverine fewest battles
        // Pheonix most battles

        string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
        int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

        var topXman = "";
        var bottomXman = "";
        var top = 0;
        var bottom = 9999;
        

        for (var i = 0; i < names.Length; i++)
        {
            if (numbers[i] > top)
            {
                topXman = names[i];
                top = numbers[i];
            }

            if (numbers[i] < bottom)
            {
                bottomXman = names[i];
                bottom = numbers[i];
            }
        }


        // Your Code Here!


        ResultLabel.Text = "Most battles belong to: " + topXman + "(Value: " + top + ")";
        ResultLabel2.Text = "Least battles belong to: " + bottomXman + "(Value: " + bottom + ")";



    }
}