<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formularz_Borkowska_Justyna.aspx.cs" Inherits="Lab1_Borkowska_Justyna.Formularz_Borkowska_Justyna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .jb_auto-style1 {
            height: 500px;
            float: left;
            width: 30%;
        }
    </style>
    <style type="text/css">
        .jb_auto-style2 {
            height: 500px;
            float: right;
            width: 70%;
        }
        #parent {
            height: 500px;
            width: 1000px;
        }
    </style>
</head>
<body style="height: 270px; width: 1399px;">
    <form id="form1" runat="server">
        <div id="parent">
            <div id="child1" class="jb_auto-style1">
                <asp:Label ID="Label1" runat="server" Text="Określenie rozmiaru elementów: " ForeColor="Blue" Font-Bold="True"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="32px" Width="255px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Text="Mały rozmiar elementu" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Średni rozmiar elementu" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Duży rozmiar elementu" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="Label2" runat="server" Text="Określenie położenia rysunków: " ForeColor="Blue" Font-Bold="True"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="32px" Width="255px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="True">
                    <asp:ListItem Text="Kostka piątka" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Przekątna lewa" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Przekątna prawa" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Linia - poziomo" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Linia - pionowo" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="child2" class="jb_auto-style2">
                <asp:Image ID="Image1" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image2" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image3" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image4" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image5" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
            
            </div>
            
        </div>
       
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
