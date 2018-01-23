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



    protected void okBtn_Click(object sender, EventArgs e)
    {
        // var result = String.Format("Thank you, {0}, for your business", NameBox.Text);

        uint SocialSecurityNumber = uint.Parse(SocialBox.Text);
        ulong PhoneNumber = ulong.Parse(PhoneBox.Text);
        double salary = double.Parse(SalaryBox.Text);
        var result = String.Format("Thank you, {0}, for your business. <br />" +
            "Your social security number is: {1:000-00-0000} <br />" +
            "Your phone number is: {2: (000) 000-0000}. <br />" +
            "The loan date is {3: ddd -- d, M, y} <br />" +
            "Salary: {4:C}",
            NameBox.Text,
            SocialSecurityNumber,
            PhoneNumber,
            LoanCalendar.SelectedDate,
            salary);

        ResultLabel.Text = result;
    }
}