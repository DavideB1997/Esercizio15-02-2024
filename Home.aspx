<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EsercizioW3D4.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Auto"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Optionals"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Anni di garanzia"></asp:Label>
            <asp:DropDownList ID="DropDownListAnniGaranzia" runat="server">
            <asp:ListItem Text="1 anno" Value="1"></asp:ListItem>
            <asp:ListItem Text="2 anni" Value="2"></asp:ListItem>
            <asp:ListItem Text="3 anni" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <br />
            
            <asp:Label ID="Label1" runat="server" Text="Conferma Preventivo"></asp:Label>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />


            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />

        </div>
        <asp:Image ID="Image1" runat="server" Height="156px" Width="295px" />
    </form>
</body>
</html>
