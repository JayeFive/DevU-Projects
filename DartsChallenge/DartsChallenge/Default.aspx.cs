using System;
using Darts;

public partial class _Default : System.Web.UI.Page
{
    Player PlayerOne = new Player();
    Player PlayerTwo = new Player();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PlayDartsButton_Click(object sender, EventArgs e)
    {
        bool PlayerOneActive = true;
        MainLoop(PlayerOneActive);
    }

    private void MainLoop(bool PlayerOneActive)
    {
        if (PlayerOneActive)
        {
            PlayersTurn(PlayerOne);
            PlayerOneActive = false;
        }
        else
        {
            PlayersTurn(PlayerTwo);
            PlayerOneActive = true;
        }
        
    }

    private void PlayersTurn(Player activePlayer)
    {

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