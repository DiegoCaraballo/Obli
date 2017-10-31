<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMApto.aspx.cs" Inherits="ABMApto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td style="width: 1200px; height: 26px; text-align: right;">
                </td>
            <td class="auto-style1" style="width: 705px">
                <h1> APARATAMENTO</h1></td>
            <td class="auto-style1">
                </td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right; height: 23px;">
                </td>
            <td class="style2" style="width: 705px; height: 23px;">
                </td>
            <td style="height: 23px">
                </td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                PADRON:</td>
            <td align="left" class="style2" style="font-size: 12px; width: 705px;">
                <asp:TextBox ID="txtPadron" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                    Text="BUSCAR" Height="26px" style="width: 82px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                DIRECCION:</td>
            <td class="style2" style="width: 705px">
                <asp:TextBox ID="txtDireccion" runat="server" Width="119px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="width: 1200px; height: 15px; text-align: right;">
                PRECIO:</td>
            <td class="style3" style="width: 705px; height: 15px;">
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            </td>
            <td class="style1" style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                ACCION:</td>
            <td class="style2" style="width: 705px">
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
            <td style="width: 1200px; text-align: right;">
                BAÑOS:</td>
            <td class="style2" style="width: 705px">
                <asp:TextBox ID="txtBanio" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                HABITACIONES:</td>
            <td class="style2" style="width: 705px">
                <asp:TextBox ID="txtHabitacion" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                MT2(CONSTRUCCION):</td>
            <td class="style2" style="width: 705px">
                <asp:TextBox ID="txtMt2C" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="width: 1200px; height: 22px; text-align: right;">
                ZONA(LETRADPTO)</td>
            <td class="style3" style="width: 705px; height: 22px;">
                <asp:TextBox ID="txtLetraDpto" runat="server"></asp:TextBox>
            </td>
            <td class="style1" style="height: 22px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="width: 1200px; height: 22px; text-align: right;">
                ZONA(ABREVIACION)</td>
            <td class="style3" style="width: 705px; height: 22px;">
                <asp:TextBox ID="txtAbreviacion" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnBuscaZona" runat="server" onclick="btnBuscaZona_Click" 
                    Text="Buscar Zona" />
            </td>
            <td class="style1" style="height: 22px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                MODIFICADO POR:</td>
            <td class="style2" style="width: 705px">
                <asp:TextBox ID="txtUsuario" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                PISO:</td>
            <td class="style2" style="width: 705px">
                <asp:TextBox ID="txtPiso" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                ASCENSOR:</td>
            <td class="style2" style="width: 705px">
                <asp:DropDownList ID="ddlAscensor" runat="server">
                    <asp:ListItem>SI</asp:ListItem>
                    <asp:ListItem>NO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1200px; text-align: right;">
                &nbsp;</td>
            <td class="style2" style="width: 705px">
                <asp:Button ID="btnAlta" runat="server" Enabled="False" onclick="btnAlta_Click" 
                    Text="ALTA" Width="58px" />
                <asp:Button ID="btnBaja" runat="server" Enabled="False" Text="BAJA" 
                    Width="58px" onclick="btnBaja_Click" />
                <asp:Button ID="btnModificar" runat="server" Enabled="False" Text="MODIFICAR" 
                    Width="101px" onclick="btnModificar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" 
                    onclick="btnCancelar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" style="width: 1200px; text-align: right;">
            </td>
            <td class="style5" style="width: 705px">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td class="style4">
            </td>
        </tr>
    </table>
</asp:Content>

