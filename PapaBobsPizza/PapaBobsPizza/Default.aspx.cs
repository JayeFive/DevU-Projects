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
        TotalPrice.Text = "$0.00";
    }

    protected void PurchaseButton_Click (object sender, EventArgs e)
    {
        double totalPrice = 0;

        // Add total price based on size
        if (size1.Checked)
        {
            totalPrice += 10;
        }
        else if (size2.Checked)
        {
            totalPrice += 13;
        }
        else if (size3.Checked)
        {
            totalPrice += 16;
        }
        else
        {
            TotalPrice.Text = "Please choose a size!";
        }

        // Add total price based on crust type

        if (crust1.Checked) { }
        else if (crust2.Checked)
        {
            totalPrice += 2;
        }
        else
        {
            TotalPrice.Text = "Please choose a crust!";
        }

        // Add toppings
        if (toppings1.Checked)
        {
            totalPrice += 1.5;
        }
        if (toppings2.Checked)
        {
            totalPrice += 0.75;
        }
        if (toppings3.Checked)
        {
            totalPrice += 0.50;
        }
        if (toppings4.Checked)
        {
            totalPrice += 0.75;
        }
        if (toppings5.Checked)
        {
            totalPrice += 2;
        }

        // Check for discounts
        if (toppings1.Checked && toppings3.Checked && toppings5.Checked)
        {
            totalPrice -= 2;
        }
        else if (toppings1.Checked && toppings2.Checked && toppings4.Checked)
        {
            totalPrice -= 2;
        }

        // Print the correct total
        TotalPrice.Text = "$" + totalPrice;
    }
}