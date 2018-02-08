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

    private Player BeginRound()
    {
        // Each player draws top card from hand
        var playerOneCard = playerOne.PlayerHand.Dequeue();
        var PlayerTwoCard = playerTwo.PlayerHand.Dequeue();
        // Evaluate winner
        if (playerOneCard.CardNumber > PlayerTwoCard.CardNumber)
        {
            playerOne.PlayerHand.Enqueue(playerOneCard);
            playerOne.PlayerHand.Enqueue(PlayerTwoCard);
            return playerOne;
        }
            // if tied, WAR
        else if (playerOneCard.CardNumber == PlayerTwoCard.CardNumber) war(new List<Card> { playerOneCard, PlayerTwoCard });
            // else, winning card holder gets both cards which goto the bottom of the hand
        else 
        {
            playerTwo.PlayerHand.Enqueue(playerOneCard);
            playerTwo.PlayerHand.Enqueue(PlayerTwoCard);
            return playerTwo;
        }

        return null;
    }

    private void war(List<Card> cards)
    {
        for (int i = 0; i < 3; i++)
        {
            cards.Add(playerOne.PlayerHand.Dequeue());
            cards.Add(playerTwo.PlayerHand.Dequeue());
        }

        var playerOneCard = playerOne.PlayerHand.Dequeue();
        var playerTwoCard = playerTwo.PlayerHand.Dequeue();
        var winningPlayer = BeginRound();
        foreach (var card in cards) winningPlayer.PlayerHand.Enqueue(card);
    }
}
