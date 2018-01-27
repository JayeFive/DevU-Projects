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
        Car myNewCar = new Car();

        myNewCar.Make = "Oldsmobile";
        myNewCar.Model = "Cutlass Supreme";
        myNewCar.Year = 1986;
        myNewCar.Color = "Silver";

        double marketValueOfCar = myNewCar.DetermineMarketValue(myNewCar);

        ResultLabel.Text = String.Format("{0} - {1} - {2} - {3} - {4:C}",
            myNewCar.Make, myNewCar.Model, myNewCar.Year, myNewCar.Color, marketValueOfCar);
    }
}
        

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

    public double DetermineMarketValue(Car car)
    {
        double carValue = 100.0;

        if (this.Year > 1990) carValue = 10000;
        else carValue = 2000;

        return carValue;
    }
}
