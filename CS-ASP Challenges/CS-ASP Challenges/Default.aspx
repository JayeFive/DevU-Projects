<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Postal Calculator<br />
            <br />
            Width:
            <asp:TextBox ID="WidthText" runat="server"></asp:TextBox>
            <br />
            Height:
            <asp:TextBox ID="HeightText" runat="server"></asp:TextBox>
            <br />
            Length:
            <asp:TextBox ID="LengthText" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="ShipGroundBtn" runat="server" AutoPostBack="True" GroupName="ShippingGroup" OnCheckedChanged="ShipGroundBtn_CheckedChanged" Text="Ground" />
            <br />
            <asp:RadioButton ID="ShipAirBtn" runat="server" AutoPostBack="True" GroupName="ShippingGroup" OnCheckedChanged="ShipAirBtn_CheckedChanged" Text="Air" />
            <br />
            <asp:RadioButton ID="ShipNextDayBtn" runat="server" AutoPostBack="True" GroupName="ShippingGroup" OnCheckedChanged="ShipNextDayBtn_CheckedChanged" Text="Next-Day" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
