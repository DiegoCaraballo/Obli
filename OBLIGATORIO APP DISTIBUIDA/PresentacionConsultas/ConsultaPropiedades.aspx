<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaPropiedades.aspx.cs" Inherits="ConsultaPropiedades" Theme="Tema" %>


<%@ Register assembly="ControlesWeb" namespace="ControlesWeb" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" Text="Volver" 
        onclick="btnVolver_Click" Height="46px" Width="81px" />
        <center><h1>DATOS DE LA PROPIEDAD</h1></center>  
    </p>                   
    <p>&nbsp;<center><asp:Label ID="lblError" runat="server" Font-Bold="True" 
        Font-Size="Medium"></asp:Label></center></p>
<div class="container">
<contenido>
   <cc1:DatosPropiedad ID="DatosPropiedad" runat="server" />
</contenido>
<panel-lateral>
        <h1>Agendar Visita</h1>

    <p>
        Fecha: 
        <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;<asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;<asp:DropDownList ID="ddlDia" runat="server">
        </asp:DropDownList>
    &nbsp;</p>
    <p>
        Hora:
        <asp:DropDownList ID="ddlHora" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Teléfono:
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
    </p>
    <p>
         Nombre:
         <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </p>
    <p>   
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
        <asp:Button ID="btnVisita" runat="server" onclick="btnVisita_Click" 
            Text="Agendar Visita" Font-Bold="False" />
            </p>
    <p>
</p>
</panel-lateral>
   </div>
</asp:Content>

