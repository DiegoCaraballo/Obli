<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMZona.aspx.cs" Inherits="ABMZona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style3 {
        text-align: center;
        font-size: x-large;
        width: 453px;
    }
    .auto-style4 {
        text-align: center;
        width: 453px;
    }
    .auto-style5 {
        width: 142px;
    }
    .auto-style6 {
        width: 453px;
    }
    .auto-style7 {
        height: 35px;
    }
    .auto-style8 {
        width: 142px;
        height: 35px;
    }
    .auto-style9 {
        width: 453px;
        height: 35px;
    }
        .style1
        {
            height: 26px;
        }
        .style2
        {
            width: 2594px;
            height: 26px;
            text-align: right;
        }
        .style3
        {
            width: 876px;
            height: 26px;
        }
        .style4
        {
            width: 2594px;
            text-align: right;
        }
        .style5
        {
            width: 2594px;
            height: 35px;
            text-align: right;
        }
        .style6
        {
            width: 2594px;
        }
        .style7
        {
            text-align: left;
            font-size: x-large;
            width: 876px;
        }
        .style8
        {
            text-align: center;
            width: 876px;
        }
        .style9
        {
            width: 876px;
        }
        .style10
        {
            width: 876px;
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="style4">&nbsp;</td>
        <td class="style7"><strong style="text-align: left">ABM ZONAS</strong></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style4">&nbsp;</td>
        <td class="style8">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style4">&nbsp;</td>
        <td class="style9">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style4">Código: </td>
        <td class="style9">
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                onclick="btnBuscar_Click" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style4">Departamento: </td>
        <td class="style9">
            <asp:DropDownList ID="ddlDepartamento" runat="server" Height="30px" 
                Width="144px">
                <asp:ListItem Value="G">Artigas</asp:ListItem>
                <asp:ListItem Value="A">Canelones</asp:ListItem>
                <asp:ListItem Value="E">Cerro Largo</asp:ListItem>
                <asp:ListItem Value="L">Colonia</asp:ListItem>
                <asp:ListItem Value="Q">Durazno</asp:ListItem>
                <asp:ListItem Value="N">Flores</asp:ListItem>
                <asp:ListItem Value="O">Florida</asp:ListItem>
                <asp:ListItem Value="P">Lavalleja</asp:ListItem>
                <asp:ListItem Value="B">Maldonado</asp:ListItem>
                <asp:ListItem Value="S">Montevideo</asp:ListItem>
                <asp:ListItem Value="I">Paysandu</asp:ListItem>
                <asp:ListItem Value="J">Rio Negro</asp:ListItem>
                <asp:ListItem Value="F">Rivera</asp:ListItem>
                <asp:ListItem Value="C">Rocha</asp:ListItem>
                <asp:ListItem Value="H">Salto</asp:ListItem>
                <asp:ListItem Value="M">San Jose</asp:ListItem>
                <asp:ListItem Value="K">Soriano</asp:ListItem>
                <asp:ListItem Value="R">Tacuarembo</asp:ListItem>
                <asp:ListItem Value="D">Treinta y Tres</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style4">Nombre: </td>
        <td class="style9">
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style2">Cant. Habitantes: </td>
        <td class="style3">
            <asp:TextBox ID="txtCantHab" runat="server"></asp:TextBox>
        </td>
        <td class="style1"></td>
        <td class="style1"></td>
    </tr>
    <tr>
        <td class="style5">Servicios: </td>
        <td class="style10">
            <asp:TextBox ID="txtServicios" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Servicio" OnClick="btnAgregar_Click" />
        </td>
        <td class="auto-style7"></td>
        <td class="auto-style7"></td>
    </tr>
    <tr>
        <td class="style4">Lista de Servicios: </td>
        <td class="style9">
            <asp:ListBox ID="lbServicios" runat="server" Height="84px" Width="146px">
            </asp:ListBox>
            <asp:Button ID="btnBorrarServicio" runat="server" 
                onclick="btnBorrarServicio_Click" Text="Borrar" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style4">&nbsp;</td>
        <td class="style9">
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
                onclick="btnIngresar_Click" />
&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                onclick="btnModificar_Click" />
&nbsp;
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                onclick="btnEliminar_Click" />
        &nbsp;
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="style6">&nbsp;</td>
        <td class="style9">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>