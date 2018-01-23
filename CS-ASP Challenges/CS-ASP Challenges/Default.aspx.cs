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
        if(!Page.IsPostBack)
        {
            double[] hours = new double[0];
            ViewState.Add("Hours", hours);
        }
    }

    protected void AddBtn_Click(object sender, EventArgs e)
    {
        double[] hours = (double[])ViewState["Hours"];

        Array.Resize(ref hours, hours.Length + 1);

        int newestItem = hours.GetUpperBound(0);
        hours[newestItem] = Double.Parse(TextBox1.Text);

        ViewState["Hours"] = hours;

        ResultLabel.Text = String.Format("Total Hours: {0} <br />" +
            "Most hours: {1} <br />" +
            "Least Hours: {2} <br />" +
            "Average: {3}",
            hours.Sum(), hours.Max(), hours.Min(), hours.Average());
    }
}