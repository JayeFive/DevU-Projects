<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hours worked on a project:<br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="Add Hours" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
