using System;
using Darts;

public partial class _Default : System.Web.UI.Page
{
    Player PlayerOne = new Player();
    Player PlayerTwo = new Player();
    Player ActivePlayer;
    const int NumberOfThrowsPerTurn = 3;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PlayDartsButton_Click(object sender, EventArgs e)
    {
        SetPlayerOneAsActive();
        MainLoop();
    }

    private void MainLoop()
    {
        // Begin player turn loop
        PlayerTurn();

        // Player throws 3 times
        // Each time the score first determined 
        // Check to see if total score > 301
            // if so, players turn is over
        // Check to see if total score == 301
            // if so, player wins
        // Add throw to total score
        //Switch active player
    }

    private void SetPlayerOneAsActive()
    {
        ActivePlayer = PlayerOne;
    }


    private void PlayerTurn()
    {
        Dart dart = new Dart();

        for (var i = 0; i < NumberOfThrowsPerTurn; i++)
        {
            dart.Throw();
            int throwScore = GetThrowScore(dart);

            if ((ActivePlayer.Score + throwScore) > 301) break;
            else if ((ActivePlayer.Score + throwScore) == 301)
            {
                ActivePlayer.Score += throwScore;
                DisplayWinResults();
                return;
            }
            else ActivePlayer.Score += throwScore;
            dart.ResetDart();
        }

        EndTurn();
        
    }

    private int GetThrowScore(Dart dart)
    {
        if (dart.IsBullseye) return 25;
        else if (dart.IsDoubleBullseye) return 50;
        else if (dart.IsOuterRing) return (dart.NumberLandedOn * 2);
        else if (dart.IsInnerRing) return (dart.NumberLandedOn * 3);
        else return dart.NumberLandedOn;
    }

    private void EndTurn()
    {
        SwitchActivePlayer();
        MainLoop();
    }

    private void SwitchActivePlayer()
    {
        if (ActivePlayer == PlayerOne) ActivePlayer = PlayerTwo;
        else ActivePlayer = PlayerOne;
    }

    private void DisplayWinResults()
    {
        ResultLabel.Text = String.Format(
            "Player One Score: {0} /r/n" +
            "Player Two Score: {1} /r/n" +
            "{2} wins!", 
            PlayerOne.Score.ToString(), PlayerTwo.Score.ToString(), ActivePlayer.ToString());
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