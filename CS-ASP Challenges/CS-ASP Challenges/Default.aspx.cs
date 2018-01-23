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
        if (!Page.IsPostBack)
        {
            ViewState.Add("MyValue", "");
        }
    }



    protected void okBtn_Click(object sender, EventArgs e)
    {
        var value = ViewState["MyValue"].ToString();
        value += ServerBox.Text + " ";
        ViewState["MyValue"] = value;
        ResultLabel.Text = value;

        ServerBox.Text = "";
    }
}