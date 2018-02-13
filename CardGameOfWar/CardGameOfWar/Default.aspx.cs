using System;
using System.Collections.Generic;
using GameOfWar;

public partial class _Default : System.Web.UI.Page
{
    DeckOfCards deck = new DeckOfCards();
    Dealer dealer = new Dealer();
    Player playerOne = new Player() { Name = "Player One" };
    Player playerTwo = new Player() { Name = "Player Two" };
    Card playerOneCard = new Card();
    Card playerTwoCard = new Card();


    Stack<Card> cardsOnTable = new Stack<Card>();
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

        DisplayGameWinner(DetermineWinner());
    }

    private void dealCards()
    {
        dealer.ShuffleCards(deck);
        dealer.DealEntireDeck(new Player[] { playerOne, playerTwo }, deck);
    }

    private Player BeginRound()
    {
        // Each player draws top card from hand
        PlayersDrawTopCard();
        AddCardsToPot();

        DisplayRound();
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
        playerOneCard = playerOne.PlayerHand.Dequeue();
        playerTwoCard = playerTwo.PlayerHand.Dequeue();
    }

    private void AddCardsToPot()
    {
        cardsOnTable.Push(playerOneCard);
        cardsOnTable.Push(playerTwoCard);
    }

    private void war()
    {
        var playerOneCards = new Card[3];
        var playerTwoCards = new Card[3];
        var winningPlayer = new Player();

        for (int i = 0; i < 3; i++)
        {
            playerOneCards[i] = playerOne.PlayerHand.Dequeue();
            cardsOnTable.Push(playerOneCards[i]);
            playerTwoCards[i] = playerOne.PlayerHand.Dequeue();
            cardsOnTable.Push(playerOneCards[i]);
        }
    }

    private void awardCards(Player winningPlayer)
    {
        foreach (var card in cardsOnTable) winningPlayer.PlayerHand.Enqueue(card);
        cardsOnTable.Clear();
    }

    private Player DetermineWinner()
    {
        if (playerOne.PlayerHand.Count > playerTwo.PlayerHand.Count) return playerOne;
        else if (playerOne.PlayerHand.Count < playerTwo.PlayerHand.Count) return playerTwo;
        else return null;
    }

    private string ConvertToRoyalNames(Card card)
    {
        switch (card.CardNumber)
        {
            case 11: return "Jack";
            case 12: return "Queen";
            case 13: return "King";
            case 14: return "Ace";
            default: return card.CardNumber.ToString();
        }
    }

    private void DisplayRound()
    {
        resultLabel.Text += String.Format("Player One draws a {0}, Player Two Draws a {1}. <br />",
            ConvertToRoyalNames(playerOneCard) + " of " + playerOneCard.Suit,
            ConvertToRoyalNames(playerTwoCard) + " of " + playerTwoCard.Suit);
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

    private void DisplayGameWinner(Player winningPlayer)
    {
        if (winningPlayer == null) DisplayGameTie();
        else
        {
            resultLabel.Text += String.Format("{0} wins with {1} cards!", winningPlayer.Name, winningPlayer.PlayerHand.Count); 
        }
    }

    private void DisplayGameTie()
    {
        resultLabel.Text += "The game is a tie!";
    }
}
