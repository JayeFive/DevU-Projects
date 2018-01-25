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
    protected void cupsRadio_CheckedChanged(object sender, EventArgs e)
    {
        CalculateCups(1.0);
    }

    protected void fromPintsRadio_CheckedChanged(object sender, EventArgs e)
    {
        CalculateCups(2.0);
    }

    protected void fromQuartsRadio_CheckedChanged(object sender, EventArgs e)
    {
        CalculateCups(4.0);
    }

    protected void fromGallonsRadio_CheckedChanged(object sender, EventArgs e)
    {
        CalculateCups(16.0);
    }

    protected void quantityTextBox_TextChanged(object sender, EventArgs e)
    {
        // ?  Right now, this doens't work!
    }

    private void CalculateCups(double measureToCupRatio)
    {
        if (quantityTextBox.Text.Trim().Length == 0)
            return;

        if (!Double.TryParse(quantityTextBox.Text, out double quantity))
            return;

        resultLabel.Text = "The number of cups: " + (quantity * measureToCupRatio).ToString();
    }
}