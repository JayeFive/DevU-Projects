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
        // Days.Hours:Minutes:Seconds.Milliseconds
        TimeSpan myTimeSpan = TimeSpan.Parse("1.2:3:30.5");

        DateTime myBirthday = DateTime.Parse("4/3/1984");
        TimeSpan myAge = DateTime.Now.Subtract(myBirthday);

        // ResultLabel.Text = myAge.TotalHours.ToString();
        ResultLabel.Text = myAge.TotalDays.ToString();
    }
}