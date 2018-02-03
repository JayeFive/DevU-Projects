using System;
using Darts;

public partial class _Default : System.Web.UI.Page
{
    Player Player1 = new Player();
    Player Player2 = new Player();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PlayDartsButton_Click(object sender, EventArgs e)
    {
        Player[] activePlayer = new Player[] { Player1, Player2 };
        StartGame();
    }

    //void StartGame()
    //{
    //    if (activeTurnCounter != 1)
    //    {
    //        active
    //    }
    //}

    private void PlayersTurn(Player activePlayer)
    {
        Dart dart = new Dart();
        var throwScore = 0;
        for (var i = 1; i < 3; i++)     // Each player get three throws
        {
            throwScore = dart.Throw();
            if (throwScore + activePlayer.Score > 301) return;  // return omitting last throw score
            else if (throwScore + activePlayer.Score == 301) return; // win condition
            else activePlayer.Score += throwScore;
        }
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