<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="css/Estilos.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Login</title>
    <style type="text/css">
        .style8
        {
            width: 817px;
            text-align: right;
        }
        .style9
        {
            width: 63px;
            text-align: right;
        }
    </style>
</head>
<body>

<asp:Panel ID="Panel1" runat="server" DefaultButton= "btnIngresar" >
<form id="form1" runat="server">
    
<div class="container">

<header>
   <h1>Login</h1>
</header>
  


<table align="center"><tr><td class="style9">&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            <img alt="BiosRealState" src="Imagenes/Logo.png" 
            style="height: 127px; width: 197px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr><td class="style9">&nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr><tr><td class="style9">&nbsp;Usuario:</td>
        <login>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" TabIndex="1" Width="193px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </login>
    </tr>
    <tr>
        <td class="style9">
            Contraseña:</td>
        <td>
            <asp:TextBox ID="txtPass" runat="server" TabIndex="2" TextMode="Password" 
                Width="194px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;&nbsp;
            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" 
                TabIndex="3" Text="Ingresar" Width="89px" />
            &nbsp;
            <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                TabIndex="4" Text="Cancelar" Width="89px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            <asp:Label ID="LblError" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    </login>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
</div>
                
            
                &nbsp;&nbsp;</form>

    </asp:Panel>

    
</body>
</html>