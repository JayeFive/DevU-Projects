<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Is
            <asp:TextBox ID="inputText1" runat="server"></asp:TextBox>
&nbsp;equal to
            <asp:TextBox ID="inputText2" runat="server"></asp:TextBox>
&nbsp;?<br />
            <br />
            <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="Check" />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
