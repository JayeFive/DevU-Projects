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

    }

    protected void OkBtn_Click(object sender, EventArgs e)
    {
        DateTime myValue = DateTime.Now;
        // ResultLabel.Text = myValue.ToString();
        // ResultLabel.Text = myValue.ToLongDateString();
        // ResultLabel.Text = myValue.ToLongTimeString();
        // ResultLabel.Text = myValue.ToShortDateString();
        // ResultLabel.Text = myValue.ToShortTimeString();

        // Do math to DateTime
        // ResultLabel.Text = myValue.AddDays(2).ToString();
        // ResultLabel.Text = myValue.AddMonths(-2).ToString();
        // ResultLabel.Text = myValue.Month.ToString();
        // ResultLabel.Text = myValue.DayOfYear.ToString();

        // More ways to initialize DateTime
        DateTime anotherDate = DateTime.Parse("4/3/1984");
        // ResultLabel.Text = anotherDate.ToLongDateString();

        DateTime moreDate = new DateTime(1984, 4, 3);
        ResultLabel.Text = anotherDate.ToLongDateString();
    }
}