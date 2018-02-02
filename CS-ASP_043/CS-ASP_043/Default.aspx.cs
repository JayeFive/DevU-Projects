using System;
using CS_ASP_043;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Car myCar = new Car();
        ResultLabel.Text = myCar.FormatStringForDisplay();
    }
}

