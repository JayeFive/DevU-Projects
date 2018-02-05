using System;
using Darts;

public partial class _Default : System.Web.UI.Page
{
    Player PlayerOne = new Player();
    Player PlayerTwo = new Player();
    Player ActivePlayer;

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

    private void SwitchActivePlayer()
    {
        if (ActivePlayer == PlayerOne) ActivePlayer = PlayerTwo;
        else ActivePlayer = PlayerOne;
    }

    private void PlayerTurn()
    {
        Dart dart = new Dart();
        int throwScore = 0;
        dart.Throw();
        if (dart.IsBullseye) throwScore = 25;
        else if (dart.IsDoubleBullseye) throwScore = 50;
        else if (dart.IsOuterRing) throwScore = dart.NumberLandedOn * 2;
        else if (dart.IsInnerRing) throwScore = dart.NumberLandedOn * 3;
        else throwScore = dart.NumberLandedOn;


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