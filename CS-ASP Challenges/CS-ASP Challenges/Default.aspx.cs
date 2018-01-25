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

    // Ground shipping method
    protected void ShipGroundBtn_CheckedChanged(object sender, EventArgs e)
    {
        const double shippingModifier = 0.15;
        double packageVolume = 0;

        if (string.IsNullOrWhiteSpace(LengthText.Text))
        {
            packageVolume = CalculatePackageVolume(WidthText.Text, HeightText.Text);
        }
        else
        {
            packageVolume = CalculatePackageVolume(WidthText.Text, HeightText.Text, LengthText.Text);
        }

        CalculateShippingCost(packageVolume, shippingModifier);
    }

    // Air shipping method
    protected void ShipAirBtn_CheckedChanged(object sender, EventArgs e)
    {
        const double shippingModifier = 0.25;
        double packageVolume = 0;

        if (string.IsNullOrWhiteSpace(LengthText.Text))
        {
            packageVolume = CalculatePackageVolume(WidthText.Text, HeightText.Text);
        }
        else
        {
            packageVolume = CalculatePackageVolume(WidthText.Text, HeightText.Text, LengthText.Text);
        }

        CalculateShippingCost(packageVolume, shippingModifier);
    }

    // Next-Day shipping method
    protected void ShipNextDayBtn_CheckedChanged(object sender, EventArgs e)
    {
        const double shippingModifier = 0.45;
        double packageVolume = 0;

        if (string.IsNullOrWhiteSpace(LengthText.Text))
        {
            packageVolume = CalculatePackageVolume(WidthText.Text, HeightText.Text);
        }
        else
        {
            packageVolume = CalculatePackageVolume(WidthText.Text, HeightText.Text, LengthText.Text);
        }

        CalculateShippingCost(packageVolume, shippingModifier);
    }

    // Parse input strings and return numeric volume
    private double CalculatePackageVolume(string widthStr, string heightStr, string lengthStr = "1")
    {
        double.TryParse(widthStr, out double width);
        double.TryParse(heightStr, out double height);
        double.TryParse(lengthStr, out double length);

        return (width * height * length);
    }

    // Find and print out the final cost
    private void CalculateShippingCost(double packageVolume, double shippingModifier)
    {
        resultLabel.Text = (packageVolume * shippingModifier).ToString();
    }
}