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
        DisplayGameWinner(DetermineGameWinner());
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

    private void BeginRound()
    {
        PlayersDrawTopCard();
        CheckForWinOrWar();
    }

    private void PlayersDrawTopCard()
    {
        SetBattleCards();
        DisplayBattleCards();
        AddBattleCardsToPot();
    }

    private void SetBattleCards()
    {
        foreach (var player in players) player.BattleCard = player.Hand.Dequeue();
    }

    private void AddBattleCardsToPot()
    {
        foreach (var player in players) cardsOnTable.Push(player.BattleCard);
    }

    private void CheckForWinOrWar()
    {
        var winningPlayer = CompareBattleCards();
        if (winningPlayer == null) war();
        else
        {
            awardCards(winningPlayer);
            DisplayRoundResults(winningPlayer);
        }
    }

    private Player CompareBattleCards()
    {
        if (players[0].BattleCard.CardNumber > players[1].BattleCard.CardNumber) return players[0];
        else if (players[0].BattleCard.CardNumber < players[1].BattleCard.CardNumber) return players[1];
        else return null;
    }

    private void war()
    {
        DisplayWarHeading();
        foreach (var player in players)
        {
            DisplayPlayerWarHeading(player);
            DrawWarCards(player);
        }

        BeginRound();
    }

    private void DrawWarCards(Player player)
    {
        for (int i = 0; i < 3; i++)
        {
            cardsOnTable.Push(player.Hand.Dequeue());
            DisplayWarCard();
        }

        AddFormattingBreak();
    }

    private void awardCards(Player winningPlayer)
    {
        foreach (var card in cardsOnTable) winningPlayer.Hand.Enqueue(card);
        cardsOnTable.Clear();
    }

    private Player DetermineGameWinner()
    {
        if (players[0].Hand.Count > players[1].Hand.Count) return players[0];
        else if (players[0].Hand.Count < players[1].Hand.Count) return players[1];
        else return null;
    }

    /* Display methods */
    private string ConvertToRoyalNames(int cardNumber)
    {
        switch (cardNumber)
        {
            case 11: return "Jack";
            case 12: return "Queen";
            case 13: return "King";
            case 14: return "Ace";
            default: return cardNumber.ToString();
        }
    }

    private void DisplayBattleCards()
    {
        foreach (var player in players)
        {
            resultLabel.Text += String.Format("{0} draws the {1} of {2}<br />",
                player.Name,
                ConvertToRoyalNames(player.BattleCard.CardNumber),
                player.BattleCard.Suit
                );
        }
    }

    private void DisplayRoundResults(Player winningPlayer)
    {
        DisplayWinner(winningPlayer);
        DisplayPlayerCardCount();
        AddFormattingBreak();
    }

    private void DisplayWinner(Player winningPlayer)
    {
        resultLabel.Text += String.Format("{0} wins the round. <br />", winningPlayer.Name);
    }

    private void DisplayPlayerCardCount()
    {
        foreach (var player in players) resultLabel.Text += String.Format("{0} has {1} cards. <br />", 
                                            player.Name, player.Hand.Count);
    }

    private void DisplayWarHeading()
    {
        resultLabel.Text += "<h3>WAR!!</h3> <br />";
    }

    private void DisplayPlayerWarHeading(Player player)
    {
        resultLabel.Text += String.Format("{0} draws: <br />", player.Name);
    }

    private void DisplayWarCard()
    {
        resultLabel.Text += String.Format("{0} of {1} <br />", 
            ConvertToRoyalNames(cardsOnTable.Peek().CardNumber), cardsOnTable.Peek().Suit);
    }

    private void DisplayGameWinner(Player winningPlayer)
    {
        if (winningPlayer == null) DisplayGameTie();
        else resultLabel.Text += String.Format("<h3>{0} wins with {1} cards!</h3>", 
                winningPlayer.Name, winningPlayer.Hand.Count); 
    }

    private void DisplayGameTie()
    {
        resultLabel.Text += "<h3>The game is a tie!</h3>";
    }

    private void AddFormattingBreak()
    {
        resultLabel.Text += "<br />";
    }
}
