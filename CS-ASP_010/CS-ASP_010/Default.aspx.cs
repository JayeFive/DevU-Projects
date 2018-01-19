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
        int myInt = 505;
        double myDouble = 3.234;
        int output = int.Parse(myDouble);
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        double num1 = double.Parse(firstValueText.Text);
        double num2 = double.Parse(secondValueText.Text);
        double result = num1 + num2;
        resultLabel.Text = result.ToString();
    }

    protected void btnSubtract_Click(object sender, EventArgs e)
    {
        double num1 = double.Parse(firstValueText.Text);
        double num2 = double.Parse(secondValueText.Text);
        double result = num1 - num2;
        resultLabel.Text = result.ToString();
    }

    protected void btnMultiply_Click(object sender, EventArgs e)
    {
        double num1 = double.Parse(firstValueText.Text);
        double num2 = double.Parse(secondValueText.Text);
        double result = num1 * num2;
        resultLabel.Text = result.ToString();
    }

    protected void btnDivide_Click(object sender, EventArgs e)
    {
        double num1 = double.Parse(firstValueText.Text);
        double num2 = double.Parse(secondValueText.Text);
        double result = num1 / num2;
        resultLabel.Text = result.ToString();
    }
}