<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Simple Calculator</h2>
            <p>
                First Value:
                <asp:TextBox ID="firstValueText" runat="server"></asp:TextBox>
            </p>
            <p>
                Second Value:
                <asp:TextBox ID="secondValueText" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="+" Width="21px" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubtract" runat="server" OnClick="btnSubtract_Click" Text="-" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnMultiply" runat="server" OnClick="btnMultiply_Click" Text="*" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDivide" runat="server" OnClick="btnDivide_Click" Text="/" />
            </p>
            <p>
                <asp:Label ID="resultLabel" runat="server"></asp:Label>
            </p>
            <br />
        </div>
    </form>
</body>
</html>
