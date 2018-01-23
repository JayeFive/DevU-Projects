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



    protected void okBtn_Click(object sender, EventArgs e)
    {
        var firstDate = firstCalendar.SelectedDate;
        var secondDate = secondCalendar.SelectedDate;
        TimeSpan resultSpan;

        if (firstDate > secondDate)
        {
            resultSpan = firstDate - secondDate;
        }
        else
        {
            resultSpan = secondDate - firstDate;
        }

        ResultLabel.Text = resultSpan.TotalDays.ToString() + " days";
    }
}