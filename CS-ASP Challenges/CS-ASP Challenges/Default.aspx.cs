using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        ImageReel1.ImageUrl = imagePaths[random.Next(0, imagePaths.Length)];
        ImageReel2.ImageUrl = imagePaths[random.Next(0, imagePaths.Length)];
        ImageReel3.ImageUrl = imagePaths[random.Next(0, imagePaths.Length)];

    }

    string[] imagePaths = new string[] 
        { @".\images\bar.png", @".\images\Bell.png", @".\images\Cherry.png", @".\images\Clover.png",
          @".\images\Diamond.png", @".\images\HorseShoe.png", @".\images\Lemon.png", @".\images\Orange.png",
          @".\images\Plum.png", @".\images\Seven.png", @".\images\Strawberry.png", @".\images\Watermelon.png"};

    
    
}