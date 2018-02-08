using System;
using System.Collections.Generic;
using GameOfWar;

public partial class _Default : System.Web.UI.Page
{
    DeckOfCards deck = new DeckOfCards();
    Dealer dealer = new Dealer();
    Player playerOne = new Player();
    Player playerTwo = new Player();


    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void playButton_Click(object sender, EventArgs e)
    {
        dealer.ShuffleCards(deck);
        dealer.DealEntireDeck(new Player[] { playerOne, playerTwo }, deck);

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
}
