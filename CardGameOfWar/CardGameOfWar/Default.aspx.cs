using System;
using System.Collections.Generic;
using GameOfWar;

public partial class _Default : System.Web.UI.Page
{
    DeckOfCards deck = new DeckOfCards();
    Dealer dealer = new Dealer();
    List<Player> players = new List<Player>()
    {
        new Player() { Name = "Player One"}, 
        new Player() { Name = "Player Two" }
    };
    Stack<Card> cardsOnTable = new Stack<Card>();
    const int numberOfRoundsToPlay = 10;

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void playButton_Click(object sender, EventArgs e)
    {
        StartGameSequence();
    }

    private void StartGameSequence()
    {
        ShuffleAndDealCards();
        PlayGame();
        DisplayGameWinner(DetermineWinner());
    }

    private void ShuffleAndDealCards()
    {
        dealer.ShuffleCards(deck);
        dealer.DealEntireDeck(players, deck);
    }

    private void PlayGame()
    {
        for (int i = 0; i < numberOfRoundsToPlay; i++) BeginRound();
    }

    private Player BeginRound()
    {
        PlayersDrawTopCard();
        DisplayRound();
        
        return null;
    }

    private void PlayersDrawTopCard()
    {
        foreach (var player in players) cardsOnTable.Push(player.Hand.Dequeue());
    }

    private void CompareTopCards()
    {
        Card playerOneCard = cardsOnTable.Pop();
        Card playerTwoCard = cardsOnTable.Pop();

        if (playerOneCard.CardNumber > playerTwoCard.CardNumber)
        {
            awardCards(players[0]);
            DisplayWinner(players[0]);
        }
        else if (playerOneCard.CardNumber == playerTwoCard.CardNumber) war();
        else
        {
            awardCards(players[1]);
            DisplayWinner(players[1]);
        }
    }

    private void war()
    {
        DisplayWarHeading();
        foreach (var player in players)
        {
            for (int i = 0; i < 3; i++)
            {
                cardsOnTable.Push(player.Hand.Dequeue());
            }
        }
    }

    private void awardCards(Player winningPlayer)
    {
        foreach (var card in cardsOnTable) winningPlayer.Hand.Enqueue(card);
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
        foreach(var player in players)
        {
            resultLabel.Text += String.Format("{0} draws a(n) {1} of {2}<br />",
                player.Name,
                ConvertToRoyalNames(player.Hand.Peek()),
                player.Hand.Peek(), player.Hand.Peek().Suit);
        }
    }

    private void DisplayWinner(Player winningPlayer)
    {
        resultLabel.Text += String.Format("{0} wins the round. <br />", winningPlayer.Name);
        resultLabel.Text += String.Format("{0} has {1} cards. <br />", playerOne.Name, playerOne.PlayerHand.Count);
        resultLabel.Text += String.Format("{0} has {1} cards. <br />", playerTwo.Name, playerTwo.PlayerHand.Count);
    }

    private void DisplayWarHeading()
    {
        resultLabel.Text += "<h3>WAR!!</h3> <br />";
    }

    private void DisplayWarCard(Player player)
    {
        resultLabel.Text += ConvertToRoyalNames(player.Hand.Peek().CardNumber);
    }

    private void DisplayGameWinner(Player winningPlayer)
    {
        if (winningPlayer == null) DisplayGameTie();
        else
        {
            resultLabel.Text += String.Format("<h3>{0} wins with {1} cards!</h3>", winningPlayer.Name, winningPlayer.Hand.Count); 
        }
    }

    private void DisplayGameTie()
    {
        resultLabel.Text += "<h3>The game is a tie!</h3>";
    }
}
