<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMEmpleado.aspx.cs" Inherits="ABMEmpleado" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table align="center">
    <tr>
        <td style="text-align: right; width: 251px">
            &nbsp;</td>
        <td style="width: 445px">
            <h1>
                ABM EMPLEADOS</h1>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 251px">
            &nbsp;</td>
        <td style="width: 445px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 251px">
            &nbsp;</td>
        <td style="width: 445px">
    <asp:Label ID="LblError" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 251px">
            Usuario: 
        </td>
        <td style="width: 445px">
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Button ID="btnBuscar" runat="server" 
    Text="Buscar" onclick="btnBuscar_Click" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 251px">
            Contraseña:
        </td>
        <td style="width: 445px">
    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td style="width: 251px; height: 22px">
        </td>
        <td style="width: 445px; height: 22px">
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" onclick="btnIngresar_Click" />
            &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" onclick="btnModificar_Click" />
            &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" onclick="btnEliminar_Click" />
            &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" />
        </td>
    </tr>
    </table>
</asp:Content>
