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
    <style type="text/css">
        .jb_auto-style3 {
            background-color:aquamarine;
            position:fixed;
            top: 25%;
            left: 25%;
            width: 700px;
            height: 250px;
        }
    </style>  
</head>
<body style="height: 270px; width: 1399px; margin-bottom: 15px;">
    <form id="form1" runat="server">
    <div id="parent">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div id="child1" class="jb_auto-style1">
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Font-Bold="True" ></asp:Label><br /><br />
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
                </asp:DropDownList><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Dane użytkownika: " ForeColor="Blue" Font-Bold="True" ></asp:Label><br />
                
                <asp:DropDownList ID="DropDownList2" runat="server" Height="32px" Width="255px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged2" AutoPostBack="True">
                </asp:DropDownList><br /><br />
                <asp:Label ID="data" Text="Data Uruchomienia" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="150px" />
                <asp:Label ID="data2" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="100px" />
                <asp:Label ID="godzina" Text="Godzina Uruchomienia" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="150px" />
                <asp:Label ID="godzina2" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="100px" />
                <asp:Label ID="uzyt" Text="Ilu użytkowników zalogowanych" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="150px" />
                <asp:Label ID="uzyt2" Text="0" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="100px" />
                <asp:Label ID="roz" Text="Ile Zmian Rozmiaru" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="150px" />
                <asp:Label ID="roz2" Text="0" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="100px" />
                <asp:Label ID="ukl" Text="Ile Zmian Układu" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="150px" />
                <asp:Label ID="ukl2" Text="0" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="100px" /> 
                <asp:Label ID="uzyt3" Text="Ilu użytkowników w bazie" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="150px" />
                <asp:Label ID="uzyt4" Text="0" runat="server" BackColor="#FF9966" BorderColor="#CC6600" BorderStyle="Solid" BorderWidth="1px" Width="100px" />
            </div>
            <div id="child2" class="jb_auto-style2">
                <asp:Image ID="Image1" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image2" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image3" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image4" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
                <asp:Image ID="Image5" runat="server" src="Rysunek/rysunek.png" Height="30px" Width="30px" />
            
            </div>
            <asp:Timer ID="Timer1" runat="server" Interval="15000" OnTick="Timer1_Tick"></asp:Timer>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" BackColor="Aquamarine" Visible="true" HorizontalAlign="Center">
            <div id="child3" class="jb_auto-style3" >
                <br /><center><b><asp:Label ID="Label5" runat="server" Text="Podaj imię i nazwisko" ForeColor="Black" Font-Bold="True" Width="707px"></asp:Label></b></center><br /> 
                <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" Width="500px" OnTextChanged="TextBox1_TextChanged1" Text="Imię i Nazwisko"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FiV1" runat="server" Text="*" ControlToValidate="TextBox1" ErrorMessage="Nie wprowadzono żadnej wartości" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="ExV1" runat="server" Text="*" ControlToValidate="TextBox1" ValidationExpression="^[A-ZĄĆĘŃÓŁŚŻŹ][a-zząćęńółśżź][a-ząćęńółśżź]([a-ząćęńółśżź])*\s[A-ZĄĆĘŃÓŁŚŻŹ][a-ząćęńółśżź][a-ząćęńółśżź]([a-ząćęńółśżź])*$" ErrorMessage="Identyfikator nie jest zgodny z wzorcem"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="ExV2" runat="server" Text="*" ControlToValidate="TextBox1" ValidationExpression="^[A-ZĄĆĘŃÓŁŚŻŹ][a-zząćęńółśżź][a-ząćęńółśżź]([a-ząćęńółśżź])*\s[A-ZĄĆĘŃÓŁŚŻŹ][a-ząćęńółśżź][a-ząćęńółśżź]([a-ząćęńółśżź])*$" ErrorMessage="Użytkownik jest zalogowany" Visible="False"></asp:RegularExpressionValidator>
                <br /><br /><asp:Button ID="Button1" runat="server" Text="Zarejestruj" style="margin-left: 0px" Width="150px" OnClick="Button1_Click1" /><br /><br />
                <asp:ValidationSummary ID="VSu1" runat="server"></asp:ValidationSummary>
            </div>
        </asp:Panel>
        </div>
       
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
