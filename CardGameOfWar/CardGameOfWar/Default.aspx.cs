using System;
using System.Collections.Generic;
using GameOfWar;

public partial class _Default : System.Web.UI.Page
{
    DeckOfCards deck = new DeckOfCards();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void playButton_Click(object sender, EventArgs e)
    {
        foreach(var card in deck.StandardDeck)
        {
            resultLabel.Text += String.Format("<p>{0} of {1}</p>", card.CardNumber, card.Suit);
        }
    }
}
