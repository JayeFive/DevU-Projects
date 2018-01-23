<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Loan Application Form:<br />
            <br />
            Name:
            <asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Phone Number:
            <asp:TextBox ID="PhoneBox" runat="server"></asp:TextBox>
            <br />
            <br />
            SSN:
            <asp:TextBox ID="SocialBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Loan Origination Date:<br />
            <asp:Calendar ID="LoanCalendar" runat="server"></asp:Calendar>
            <br />
            Salary:
            <asp:TextBox ID="SalaryBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="okBtn" runat="server" OnClick="okBtn_Click" Text="Ok" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
