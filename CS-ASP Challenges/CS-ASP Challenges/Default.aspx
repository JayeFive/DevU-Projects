<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Convert to cups<br />
            <br />
            <asp:TextBox ID="quantityTextBox" runat="server" AutoPostBack="True" OnTextChanged="quantityTextBox_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="fromCupsRadio" runat="server" AutoPostBack="True" GroupName="fromGroup" OnCheckedChanged="cupsRadio_CheckedChanged" Text="Cups" />
            <br />
            <asp:RadioButton ID="fromPintsRadio" runat="server" AutoPostBack="True" GroupName="fromGroup" OnCheckedChanged="fromPintsRadio_CheckedChanged" Text="Pints" />
            <br />
            <asp:RadioButton ID="fromQuartsRadio" runat="server" AutoPostBack="True" GroupName="fromGroup" OnCheckedChanged="fromQuartsRadio_CheckedChanged" Text="Quarts" />
            <br />
            <asp:RadioButton ID="fromGallonsRadio" runat="server" AutoPostBack="True" GroupName="fromGroup" OnCheckedChanged="fromGallonsRadio_CheckedChanged" Text="Gallons" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
