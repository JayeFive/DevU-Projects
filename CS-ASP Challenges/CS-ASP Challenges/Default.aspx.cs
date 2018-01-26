using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Random random = new Random();
    Image[] reels;  // Array to hold the 3 reel images

    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateRandomImages();
    }

    string[] imagePaths = new string[]
        { @".\images\bar.png", @".\images\Bell.png", @".\images\Cherry.png", @".\images\Clover.png",
          @".\images\Diamond.png", @".\images\HorseShoe.png", @".\images\Lemon.png", @".\images\Orange.png",
          @".\images\Plum.png", @".\images\Seven.png", @".\images\Strawberry.png", @".\images\Watermelon.png" };

    // Global variables
    int playerMoney = 100;
    int[] reelOutcomes = new int[3];            // Relational index to winner/loser reel outcomes
    const int bar = 0, cherry = 2, seven = 9;   // Above mentioned index locations

    // Wrapper function for the button
    private void PullTheLever()
    {
        GenerateRandomImages();
        DetermineResultOutcome();
        UpdatePlayerMoney();
    }

    // This loads 3 images at random, saves their indexes
    private void GenerateRandomImages()
    {
        reels = new Image[] { ImageReel1, ImageReel2, ImageReel3 };  // Populate reels array

        for (var i = 0; i < reels.Length; i++)
        {
            reelOutcomes[i] = random.Next(0, imagePaths.Length);  // Save the index to check for winning
            reels[i].ImageUrl = imagePaths[reelOutcomes[i]];      // Select image to display
        }
    }

    // Check for cherries, sevens, bars
    private void DetermineResultOutcome()  
    {

        for (var i = 0; i < reelOutcomes.Length; i++)
        {
            if (reelOutcomes[i] == bar) ;
        }
    }

    private void UpdatePlayerMoney()
    {

    }

    private void UpdateLabels()
    {

    }

    protected void LeverBtn_Click(object sender, EventArgs e)
    {
        PullTheLever();
    }
}