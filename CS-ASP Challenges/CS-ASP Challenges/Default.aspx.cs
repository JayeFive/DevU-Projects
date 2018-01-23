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

    protected void AddBtn_Click(object sender, EventArgs e)
    {
        TextBox[] textBoxes = { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5 };

        string[] values = new string[5];

        for (var i = 0; i < textBoxes.Length; i++)
        {
            values[i] = textBoxes[i].Text;
        }

        ViewState.Add("TextBoxValues", values);  
    }

    protected void RetrieveBtn_Click(object sender, EventArgs e)
    {
        TextBox[] textBoxes = { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5 };
        string[] values = (string[])ViewState["TextBoxValues"];

        for (var i = 0; i < textBoxes.Length; i++)
        {
            textBoxes[i].Text = values[i] + " me too";
        }
    }
}