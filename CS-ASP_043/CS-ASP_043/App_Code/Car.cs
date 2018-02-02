
namespace CS_ASP_043
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car()
        {
            this.Make = "undefined";
            this.Model = "undefined";
            this.Year = 1980;
            this.Color = "undefined";
        }

        // Overloaded constructor

        public Car(string make, string model, int year, string color)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Color = color;
        }

        public string FormatStringForDisplay()
        {
            return string.Format("Make: {0} Model: {1} Year: {2} Color: {3}", this.Make, this.Model, this.Year, this.Color);
        }
    }
}
