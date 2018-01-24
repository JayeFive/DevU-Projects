using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string[] assets;
    int[] electionsRigged;
    int[] subterfuges;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            assets = new string[0];
            electionsRigged = new int[0];
            subterfuges = new int[0];
            ViewState.Add("Assets", assets);
            ViewState.Add("Elections", electionsRigged);
            ViewState.Add("Subterfuges", subterfuges);
        }
    }

    protected void AddBtn_Click(object sender, EventArgs e)
    {
        // Gather arrays from ViewState
        string[] assets = (string[])ViewState["Assets"];
        int[] electionsRigged = (int[])ViewState["Elections"];
        int[] subterfuges = (int[])ViewState["Subterfuges"];

        // Give each array another element
        int newLength = assets.Length + 1;

        Array.Resize(ref assets, newLength);
        Array.Resize(ref electionsRigged, newLength);
        Array.Resize(ref subterfuges, newLength);

        // Add user input to ech array
        int newIndex = assets.GetUpperBound(0);

        assets[newIndex] = AssetName.Text;
        electionsRigged[newIndex] = int.Parse(NumElections.Text);
        subterfuges[newIndex] = int.Parse(NumSubterfuge.Text);

        // Update ViewStates
        ViewState["Assets"] = assets;
        ViewState["Elections"] = electionsRigged;
        ViewState["Subterfuges"] = subterfuges;

        // Print out the results
        ResultLabel.Text = String.Format(
            "Number of elections rigged: {0} <br />" +
            "Average number of subterfuge: {1} <br />" +
            "Last agent entered: {2}",
            electionsRigged.Sum(), subterfuges.Average(), assets[newIndex]);
    }
}