using System;
using Darts;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Player Player1 = new Player();
        Player Player2 = new Player();
    }

    protected void PlayDartsButton_Click(object sender, EventArgs e)
    {
        Dart.
    }
}

class Player
{
    public int Score { get; set; }

    public Player()
    {
        Score = 0;
    }
}