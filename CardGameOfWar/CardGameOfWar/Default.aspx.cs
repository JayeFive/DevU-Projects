using System;
using System.Collections.Generic;
using GameOfWar;

public partial class _Default : System.Web.UI.Page
{
    DeckOfCards deck = new DeckOfCards();
    Dealer dealer = new Dealer();
    Player playerOne = new Player() { Name = "Player One" };
    Player playerTwo = new Player() { Name = "Player Two" };
    List<Card> cardsOnTable = new List<Card>();
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
        cardsOnTable.Add(playerOneCard);
        cardsOnTable.Add(playerTwoCard);

        DisplayRound(new Card[] { playerOneCard, playerTwoCard });
        // Evaluate winner
        if (playerOneCard.CardNumber > playerTwoCard.CardNumber)
        {
            awardCards(playerOne);
            DisplayWinner(playerOne);
            return playerOne;
        }
            // if tied, WAR
        else if (playerOneCard.CardNumber == playerTwoCard.CardNumber) war();
            // else, winning card holder gets both cards which goto the bottom of the hand
        else 
        {
            awardCards(playerTwo);
            DisplayWinner(playerTwo);
            return playerTwo;
        }
        return null;
    }

    private void PlayersDrawTopCard ()
    {

    }

    private void war()
    {
        var playerOneCards = new Card[3];
        var playerTwoCards = new Card[3];

        for (int i = 0; i < 3; i++)
        {
            playerOneCards[i] = playerOne.PlayerHand.Dequeue();
            cardsOnTable.Add(playerOneCards[i]);
            playerTwoCards[i] = playerOne.PlayerHand.Dequeue();
            cardsOnTable.Add(playerOneCards[i]);
        }

        DisplayWar(playerOneCards, playerTwoCards);
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

    private void DisplayWar(Card[] playerOneCards, Card[] playerTwoCards)
    {
        resultLabel.Text += "<h3>WAR!!</h3> <br />";
        resultLabel.Text += "Player One cards: <br />";
        foreach (var card in playerOneCards) resultLabel.Text += String.Format("{0} of {1}<br />", card.CardNumber, card.Suit);
        resultLabel.Text += "Player Two cards: <br />";
        foreach (var card in playerTwoCards) resultLabel.Text += String.Format("{0} of {1}<br />", card.CardNumber, card.Suit);
    }
}
