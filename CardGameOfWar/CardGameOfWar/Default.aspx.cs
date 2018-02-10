using System;
using System.Collections.Generic;
using GameOfWar;

public partial class _Default : System.Web.UI.Page
{
    DeckOfCards deck = new DeckOfCards();
    Dealer dealer = new Dealer();
    Player playerOne = new Player() { Name = "Player One" };
    Player playerTwo = new Player() { Name = "Player Two" };
    Queue<Card> cardsOnTable = new Queue<Card>();
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

        //resultLabel.Text += "<h2>Player One's Cards: </h2> <br />";
        //foreach(var card in playerOne.PlayerHand)
        //{
        //    resultLabel.Text += String.Format("<p>{0} of {1}</p>", card.CardNumber, card.Suit);
        //}

        //resultLabel.Text += "<h2>Player Two's Cards: </h2> <br />";
        //foreach (var card in playerTwo.PlayerHand)
        //{
        //    resultLabel.Text += String.Format("<p>{0} of {1}</p>", card.CardNumber, card.Suit);
        //}
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
        var playerTwoCard = playerTwo.PlayerHand.Dequeue();
        cardsOnTable.Enqueue(playerOneCard);
        cardsOnTable.Enqueue(playerTwoCard);

        DisplayRound(new Card[] { playerOneCard, playerTwoCard });
        // Evaluate winner
        if (playerOneCard.CardNumber > playerTwoCard.CardNumber)
        {
            awardCards(playerOne);
            DisplayWinner(playerOne);
            return playerOne;
        }
            // if tied, WAR
        else if (playerOneCard.CardNumber == playerTwoCard.CardNumber) war(new List<Card> { playerOneCard, playerTwoCard });
            // else, winning card holder gets both cards which goto the bottom of the hand
        else 
        {
            awardCards(playerTwo);
            DisplayWinner(playerTwo);
            return playerTwo;
        }
        return null;
    }

    private void war(List<Card> cards)
    {
        for (int i = 0; i < 3; i++)
        {
            cardsOnTable.Enqueue(playerOne.PlayerHand.Dequeue());
            cardsOnTable.Enqueue(playerTwo.PlayerHand.Dequeue());
        }
    }

    private void awardCards(Player winningPlayer)
    {
        foreach (var card in cardsOnTable) winningPlayer.PlayerHand.Enqueue(card);
        cardsOnTable.Clear();
    }

    private void DisplayRound(Card[] cards)
    {
        resultLabel.Text += String.Format("Player One draws a {0}, Player Two Draws a {1}. <br />",
            cards[0].CardNumber.ToString() + " of " + cards[0].Suit,
            cards[1].CardNumber.ToString() + " of " + cards[1].Suit);
    }

    private void DisplayWinner(Player winningPlayer)
    {
        resultLabel.Text += String.Format("{0} wins the round. <br />", winningPlayer.Name);
        resultLabel.Text += String.Format("{0} has {1} cards. <br />", playerOne.Name, playerOne.PlayerHand.Count);
        resultLabel.Text += String.Format("{0} has {1} cards. <br />", playerTwo.Name, playerTwo.PlayerHand.Count);
    }

    private void DisplayWar()
    {

    }
}
