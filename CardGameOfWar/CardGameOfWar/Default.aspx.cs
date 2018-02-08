using System;
using System.Collections.Generic;
using GameOfWar;

public partial class _Default : System.Web.UI.Page
{
    DeckOfCards deck = new DeckOfCards();
    Dealer dealer = new Dealer();
    Player playerOne = new Player();
    Player playerTwo = new Player();
    const int numberOfRoundsToPlay = 10;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void playButton_Click(object sender, EventArgs e)
    {
        dealCards();
        for (int i = 0; i < numberOfRoundsToPlay; i++) 
        {
            BeginRound();
        }

        resultLabel.Text += "<h2>Player One's Cards: </h2> <br />";
        foreach(var card in playerOne.PlayerHand)
        {
            resultLabel.Text += String.Format("<p>{0} of {1}</p>", card.CardNumber, card.Suit);
        }

        resultLabel.Text += "<h2>Player Two's Cards: </h2> <br />";
        foreach (var card in playerTwo.PlayerHand)
        {
            resultLabel.Text += String.Format("<p>{0} of {1}</p>", card.CardNumber, card.Suit);
        }
    }

    private void dealCards()
    {
        dealer.ShuffleCards(deck);
        dealer.DealEntireDeck(new Player[] { playerOne, playerTwo }, deck);
    }

    private void BeginRound()
    {
        // Each player draws top card from hand
        var playerOneCard = playerOne.PlayerHand.Dequeue();
        var PlayerTwoCard = playerTwo.PlayerHand.Dequeue();
        // Evaluate winner
        if (playerOneCard.CardNumber > PlayerTwoCard.CardNumber)
        {

        }
        

            // if tied, WAR
            // else, winning card holder gets both cards which goto the bottom of the hand
    }
}
