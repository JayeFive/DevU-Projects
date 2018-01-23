<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            From:<br />
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="FromBtns" Text="Chicago" />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="FromBtns" Text="New York" />
            <br />
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="FromBtns" Text="London" />
            <br />
            <br />
            To:<br />
            <br />
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="ToBtns" Text="Chicago" />
            <br />
            <asp:RadioButton ID="RadioButton5" runat="server" GroupName="ToBtns" Text="New York" />
            <br />
            <asp:RadioButton ID="RadioButton6" runat="server" GroupName="ToBtns" Text="London" />
            <br />
            <br />
            <asp:Button ID="OkBtn" runat="server" OnClick="OkBtn_Click" Text="Ok" />
            <br />
            <br />
            Ticket Price: <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
