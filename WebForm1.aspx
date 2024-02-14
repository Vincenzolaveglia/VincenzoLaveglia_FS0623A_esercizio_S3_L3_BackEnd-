<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Esercizio_L3_S3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
        <h1>Cinema</h1>
        <h2>Vendita Biglietti</h2>

        <div>
            Sala Nord: 
            <asp:Label ID="LblNord" runat="server" Text="Label"></asp:Label>
            <br />
            Sala Est:
            <asp:Label ID="LblEst" runat="server" Text="Label"></asp:Label>
            <br />
            Sala Sud: 
            <asp:Label ID="LblSud" runat="server" Text="Label"></asp:Label>
        </div>

        <br />

        <div>
            Nome:
            <asp:TextBox ID="TxtNome" runat="server"></asp:TextBox>
            <br />
            <br />
            Cognome:
            <asp:TextBox ID="TxtCognome" runat="server"></asp:TextBox>
            <br />
            <br />
            Sala:
             <asp:RadioButtonList ID="LstSala" runat="server">
                 <asp:ListItem Value="nord">Sala Nord</asp:ListItem>
                 <asp:ListItem Value="est">Sala Est</asp:ListItem>
                 <asp:ListItem Value="sud">Sala Sud</asp:ListItem>
             </asp:RadioButtonList>
            <br />
            <asp:CheckBox ID="ChkRidotto" runat="server" Text="Ridotto" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Prenota" OnClick="Button1_Click" />
        </div>

    </form>
</body>
</html>
