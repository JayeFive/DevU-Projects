using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    // Global variables //
    Random random = new Random();
    int playerMoney;
    Image[] reels;  // Array to hold the 3 reel images
    int[] reelOutcomes = new int[3];            // Relational index to winner/loser reel outcomes
    const int bar = 0, cherry = 2, seven = 9;   // Above mentioned index locations

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState.Add("playerMoney", 100);
            GenerateRandomImages();     // Start game as though the last player's outcome is still there
        }
        playerMoney = (int)ViewState["playerMoney"];
        MoneyLabel.Text = String.Format("Player's Money: {0:C}", playerMoney);
    }

    string[] imagePaths = new string[]
        { @".\images\bar.png", @".\images\Bell.png", @".\images\Cherry.png", @".\images\Clover.png",
          @".\images\Diamond.png", @".\images\HorseShoe.png", @".\images\Lemon.png", @".\images\Orange.png",
          @".\images\Plum.png", @".\images\Seven.png", @".\images\Strawberry.png", @".\images\Watermelon.png" };


    // Event handler for lever click
    protected void LeverBtn_Click(object sender, EventArgs e)
    {
        GenerateRandomImages();
        if (IsLoser()) UpdatePlayerMoney(false);
        else DetermineWinningReels();
    }

    // This loads 3 images at random, saves their indexes //
    private void GenerateRandomImages()
    {
        reels = new Image[] { ImageReel1, ImageReel2, ImageReel3 };  // Populate reels array

        for (var i = 0; i < reels.Length; i++)
        {
            reelOutcomes[i] = random.Next(0, imagePaths.Length);  // Save the index to check for winning
            reels[i].ImageUrl = imagePaths[reelOutcomes[i]];      // Select image to display
        }
    }

    // Check for bars //
    private bool IsLoser()  
    {
        for (var i = 0; i < reelOutcomes.Length; i++)
        {
            if (reelOutcomes[i] == bar) return true;
        }
        return false;
    }

    // Check for cherries and sevens
    private void DetermineWinningReels()
    {
        int cherries = 0, sevens = 0;
        for (var i = 0; i < reelOutcomes.Length; i++)
        {
            if (reelOutcomes[i] == cherry) cherries++;
            else if (reelOutcomes[i] == seven) sevens++;
        }
        if (cherries == 0 && sevens == 0) UpdatePlayerMoney(false); // Natural loss without bars
        else DetermineWinningsMultiplier(cherries, sevens);  // Send the number of cherries and sevens through
    }

    // Find multiplier based on cherries and sevens
    private void DetermineWinningsMultiplier(int numCherries, int numSevens)
    {
        if (numCherries == 1) UpdatePlayerMoney(true, 2);
        else if (numCherries == 2) UpdatePlayerMoney(true, 3);
        else if (numCherries == 3) UpdatePlayerMoney(true, 4);
        else if (numSevens == 3) UpdatePlayerMoney(true, 100);
        else UpdatePlayerMoney(false);
    }

    // Find player bet, calculate any winnings, control to label updater
    private void UpdatePlayerMoney(bool isWinner, int multiplier = 1)
    {
        int playerBet = int.Parse(BetTextBox.Text), winnings = 0;

        if (isWinner)
        {
            playerMoney += (winnings = CalculateWinnings(playerBet, multiplier));
            UpdateLabels(playerBet, winnings);
        }
        else
        {
            playerMoney -= playerBet;
            UpdateLabels(playerBet);
        }
    }

    // In the case of a win, determine to winnings
    private int CalculateWinnings(int playerBet, int multiplier)
    {
        int winnings = playerBet * multiplier;
        return winnings;
    }

    // Update labels if a win
    private void UpdateLabels(int playerBet, int winnings)
    {
        GameOutcomeLabel.Text = String.Format("You bet {0:C} and won {1:C}!", playerBet, winnings);
        MoneyLabel.Text = String.Format("Player's Money: {0:C}", playerMoney);
        UpdateViewState(playerMoney);
    }

    // Update labels if a loss
    private void UpdateLabels(int playerBet)
    {
        GameOutcomeLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time!", playerBet);
        MoneyLabel.Text = String.Format("Player's Money: {0:C}", playerMoney);
        UpdateViewState(playerMoney);
    }

    private void UpdateViewState(int playerMoney)
    {
        ViewState["playerMoney"] = playerMoney;
    }
}