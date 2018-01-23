using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    double[,] priceGrid;

    protected void Page_Load(object sender, EventArgs e)
    {
        // double[,] priceGrid = new double[3, 3];
        // 0 - Chicago
        // 1 - New York
        // 2 - London

        priceGrid = new double[3, 3];
        priceGrid[0, 1] = 350d;
        priceGrid[0, 2] = 750d;
        priceGrid[1, 0] = 400d;
        priceGrid[1, 2] = 700d;
        priceGrid[2, 0] = 800d;
        priceGrid[2, 1] = 805d;

        // ResultLabel.Text = String.Format("{0:C}", priceGrid[1, 2]);
    }


    protected void OkBtn_Click(object sender, EventArgs e)
    {
        int fromCity, 
            toCity;

        if (RadioButton1.Checked) fromCity = 0;
        else if (RadioButton2.Checked) fromCity = 1;
        else fromCity = 2;

        if (RadioButton4.Checked) toCity = 0;
        else if (RadioButton5.Checked) toCity = 1;
        else toCity = 2;

        if (fromCity == toCity)
        {
            ResultLabel.Text = "Cannot travel to origin";
        }
        else
        {
            ResultLabel.Text = String.Format("{0:C}", priceGrid[fromCity, toCity]);
        }
    }
}