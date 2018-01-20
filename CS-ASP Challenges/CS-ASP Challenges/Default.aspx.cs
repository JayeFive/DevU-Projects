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

    protected void GetDateBtn_Click(object sender, EventArgs e)
    {
        ResultLabel.Text = MyCalendar.SelectedDate.ToShortDateString();
    }

    protected void SetDateBtn_Click(object sender, EventArgs e)
    {
        MyCalendar.SelectedDate = DateTime.Parse("4/3/2017");
    }

    protected void ShowDateBtn_Click(object sender, EventArgs e)
    {
        MyCalendar.VisibleDate = DateTime.Parse("4/3/1984");
    }

    protected void WeekBtn_Click(object sender, EventArgs e)
    {
        ResultLabel.Text = "Week of " + MyCalendar.SelectedDate.ToShortDateString();
    }

    protected void MyCalendar_SelectionChanged(object sender, EventArgs e)
    {
        ResultLabel.Text = MyCalendar.SelectedDate.ToLongDateString();
    }
}