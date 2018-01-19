<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            How do you like to take notes?<br />
            <br />
            <asp:RadioButton ID="pencilRadio" runat="server" GroupName="noteType" Text="Pencil" />
            <br />
            <asp:RadioButton ID="penRadio" runat="server" GroupName="noteType" Text="Pen" />
            <br />
            <asp:RadioButton ID="phoneRadio" runat="server" GroupName="noteType" Text="Phone" />
            <br />
            <asp:RadioButton ID="tabletRadio" runat="server" GroupName="noteType" Text="Tablet" />
            <br />
            <br />
            <asp:Button ID="submitBtn" runat="server" OnClick="submitBtn_Click" Text="Submit" />
            <br />
            <br />
            <asp:Image ID="resultImage" runat="server" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </div>
    </form>
</body>
</html>
