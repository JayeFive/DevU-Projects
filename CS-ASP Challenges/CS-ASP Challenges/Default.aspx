<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Asset Performance Tracker</h1>
            Asset Name:
            <asp:TextBox ID="AssetName" runat="server"></asp:TextBox>
            <br />
            <br />
            Number of elections rigged:
            <asp:TextBox ID="NumElections" runat="server"></asp:TextBox>
            <br />
            <br />
            Number of acts of subterfuge:
            <asp:TextBox ID="NumSubterfuge" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="Add Asset" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
