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

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        if (pencilRadio.Checked)
        {
            resultImage.ImageUrl = "./pencil.png";
        }
        else if (penRadio.Checked)
        {
            resultImage.ImageUrl = "./pen.png";
        }
        else if (phoneRadio.Checked)
        {
            resultImage.ImageUrl = "./phone.png";
        }
        else if (tabletRadio.Checked)
        {
            resultImage.ImageUrl = "./tablet.png";
        }
        else
        {
            resultLabel.Text = "Please select an option above";
        }
    }
}