<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Type a value to add it to the string:<br />
            <br />
            Server control:<br />
            <asp:TextBox ID="ServerBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Plain &#39;ol HTLM input=text box:<br />
            <input id="htmlBox" type="text" /><br />
            <br />
            <br />
            <asp:Button ID="okBtn" runat="server" OnClick="okBtn_Click" Text="Add" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
