<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="ImageReel1" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="ImageReel2" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="ImageReel3" runat="server" Height="150px" Width="150px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="LeverBtn" runat="server" OnClick="LeverBtn_Click" Text="Pull The Lever!" />
            <br />
            <br />
            <asp:Label ID="BettingLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="MoneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - 2x Your Bet!<br />
            2 Cherries - 3x Your Bet!<br />
            3 Cherries - 4x YourBet!<br />
            3 7&#39;s - Jackpot!! 100x Your Bet!<br />
            HOWEVER - If there&#39;s even one bar you lose<br />
        </div>
    </form>
</body>
</html>
