<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            How many days have elapsed?<br />
            <br />
            <asp:Calendar ID="firstCalendar" runat="server"></asp:Calendar>
            <br />
            <asp:Calendar ID="secondCalendar" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="okBtn" runat="server" OnClick="okBtn_Click" Text="Ok" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
