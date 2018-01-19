<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .h1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .h2 {
            font-family: Arial, Helvetica, sans-serif;
        }
        #special-deals {
            font-family: Arial, Helvetica, sans-serif;
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Papa Bob's Pizza and Software</h1>

            <asp:RadioButton ID="size1" runat="server" GroupName="pizzaSize"  
                Text="Baby Bob Size (10&quot) - $10" /><br />
            <asp:RadioButton ID="size2" runat="server" GroupName="pizzaSize"  
                Text="Momma Bob Size (13&quot) - $13" /><br />
            <asp:RadioButton ID="size3" runat="server" GroupName="pizzaSize" 
                Text="Papa Bob Size (16&quot) - $16" /><br />
            <br />
            <asp:RadioButton runat="server" GroupName="crustOption" ID="crust1" 
                Text="Thin Crust" /><br />
            <asp:RadioButton runat="server" GroupName="crustOption" ID="crust2"
                Text="Deep Dish (+$2)" /><br />
            <br />
            <asp:CheckBox runat="server" ID="toppings1" GroupName="toppings" 
                Text="Pepperoni (+$1.50)" /><br />
            <asp:CheckBox runat="server" ID="toppings2" GroupName="toppings" 
                Text="Onions (+$0.75)" /><br />
            <asp:CheckBox runat="server" ID="toppings3" GroupName="toppings" 
                Text="Green Peppers (+$0.50)" /><br />
            <asp:CheckBox runat="server" ID="toppings4" GroupName="toppings" 
                Text="Red Peppers (+$0.75)" /><br />
            <asp:CheckBox runat="server" ID="toppings5" GroupName="toppings" 
                Text="Anchovies (+$2)" /><br />
            <br />
            <h2>Papa Bob's <span id="special-deals">Special Deals</span></h2>
            <p>Save $2.00 when you add Pepperoni, Green Peppers and Anchovies OR
                Pepperoni, Red Peppers and Onions to your pizza!
            </p>
            <asp:Button ID="PurchaseButton" runat="server" Text="Purchase" OnClick="PurchaseButton_Click" />
            <br /><br />
            <label>Total Price: </label>
            <asp:Label ID="TotalPrice" runat="server" />



        </div>
    </form>
</body>
</html>
