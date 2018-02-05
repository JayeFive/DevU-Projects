using System;
using Darts;

public partial class _Default : System.Web.UI.Page
{
    Player PlayerOne = new Player();
    Player PlayerTwo = new Player();
    Player ActivePlayer;
    Dart dart = new Dart();
    const int NumberOfThrowsPerTurn = 3;
    

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PlayDartsButton_Click(object sender, EventArgs e)
    {
        PlayerOne.Name = "Player One";
        PlayerTwo.Name = "Player Two";
        SetPlayerOneAsActive();
        PlayerTurn();
    }

    private void SetPlayerOneAsActive()
    {
        ActivePlayer = PlayerOne;
    }

    private void PlayerTurn()
    {
        for (var i = 0; i < NumberOfThrowsPerTurn; i++)
        {
            dart.Throw();
            int throwScore = GetThrowScore(dart);

            if ((ActivePlayer.Score + throwScore) > 301)
            {
                dart.ResetDart();
                continue;
            }
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
        PlayerTurn();
    }

    private void SwitchActivePlayer()
    {
        if (ActivePlayer == PlayerOne) ActivePlayer = PlayerTwo;
        else ActivePlayer = PlayerOne;
    }

    private void DisplayWinResults()
    {
        ResultLabel.Text = String.Format(
            "<p>Player One Score: {0}</p>" +
            "<p>Player Two Score: {1}</p>" +
            "{2} wins!", 
            PlayerOne.Score.ToString(), PlayerTwo.Score.ToString(), ActivePlayer.Name);
    }
  
}

    


class Player
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Player()
    {
        Score = 0;
    }
}