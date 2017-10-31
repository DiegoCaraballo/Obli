<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMComercio.aspx.cs" Inherits="ABMComercio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td style="text-align: right; width: 1200px">
                &nbsp;</td>
            <td class="style2" style="width: 1052px">
                <h1>COMERCIO</h1></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                &nbsp;</td>
            <td class="style2" style="width: 1052px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                PADRON:</td>
            <td align="left" class="style2" style="font-size: 12px; width: 1052px;">
                <asp:TextBox ID="txtPadron" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                    Text="BUSCAR" />
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right; width: 1200px;">
                DIRECCION:</td>
            <td class="style2" style="height: 26px; width: 1052px">
                <asp:TextBox ID="txtDireccion" runat="server" Width="119px"></asp:TextBox>
            </td>
            <td style="height: 26px">
                </td>
        </tr>
        <tr>
            <td class="style1" style="height: 14px; text-align: right; width: 1200px;">
                PRECIO:</td>
            <td class="style3" style="height: 14px; width: 1052px">
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            </td>
            <td class="style1" style="height: 14px">
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                ACCION:</td>
            <td class="style2" style="width: 1052px">
                <asp:DropDownList ID="ddlAccion" runat="server">
                    <asp:ListItem>ALQUILER</asp:ListItem>
                    <asp:ListItem>VENTA</asp:ListItem>
                    <asp:ListItem>PERMUTA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                BAÑOS:</td>
            <td class="style2" style="width: 1052px">
                <asp:TextBox ID="txtBanio" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                HABITACIONES:</td>
            <td class="style2" style="width: 1052px">
                <asp:TextBox ID="txtHabitacion" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                MT2(CONSTRUCCION):</td>
            <td class="style2" style="width: 1052px">
                <asp:TextBox ID="txtMt2C" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="height: 17px; text-align: right; width: 1200px;">
                ZONA(LETRADPTO)</td>
            <td class="style3" style="height: 17px; width: 1052px">
                <asp:TextBox ID="txtLetraDpto" runat="server"></asp:TextBox>
            </td>
            <td class="style1" style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="height: 17px; text-align: right; width: 1200px;">
                ZONA(ABREVIACION)</td>
            <td class="style3" style="height: 17px; width: 1052px">
                <asp:TextBox ID="txtAbreviacion" runat="server"></asp:TextBox>
            &nbsp;
                <asp:Button ID="btnBuscaZona" runat="server" onclick="btnBuscarZona_Click" 
                    Text="Buscar Zona" />
            </td>
            <td class="style1" style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                MODIFICADO POR:</td>
            <td class="style2" style="width: 1052px">
                <asp:TextBox ID="txtUsuario" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                HABILITADO:</td>
            <td class="style2" style="width: 1052px">
                <asp:DropDownList ID="ddlHabilitado" runat="server">
                    <asp:ListItem>SI</asp:ListItem>
                    <asp:ListItem>NO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                &nbsp;</td>
            <td class="style2" style="width: 1052px">
                <asp:Button ID="btnAlta" runat="server" Enabled="False" Text="ALTA" 
                    onclick="btnAlta_Click" />
                <asp:Button ID="btnBaja" runat="server" Enabled="False" Text="BAJA" 
                    onclick="btnBaja_Click" />
                <asp:Button ID="btnModificar" runat="server" Enabled="False" Text="MODIFICAR" 
                    onclick="btnModificar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" 
                    onclick="btnCancelar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                &nbsp;</td>
            <td class="style2" style="width: 1052px">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 1200px">
                &nbsp;</td>
            <td class="style2" style="width: 1052px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

