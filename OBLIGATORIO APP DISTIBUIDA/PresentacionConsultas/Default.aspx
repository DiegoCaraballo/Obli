<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Theme="Tema"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        height: 2.2em;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="container">
    <center style="height: 42px"><h1>Consulta de Propiedades</h1>
    <p><asp:Label ID="lblCount" runat="server"></asp:Label></p>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>&nbsp; </center>
    <nav>
    <p>
    <img src="Imagenes/Logo.png" height="150" />
    </p>
    &nbsp;Acción: 
        <asp:DropDownList ID="ddlAccion" runat="server" Height="30px" Width="152px">
            <asp:ListItem>--Seleccione Opción--</asp:ListItem>
            <asp:ListItem Value="PERMUTA">Permuta</asp:ListItem>
            <asp:ListItem Value="ALQUILER">Alquiler</asp:ListItem>
            <asp:ListItem Value="VENTA">Venta</asp:ListItem>
        </asp:DropDownList>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;
Tipo: 
            <asp:DropDownList ID="ddlProp" runat="server" Height="30px" Width="152px">
            <asp:ListItem Value="0">--Seleccione Opción--</asp:ListItem>
            <asp:ListItem Value="CASA">Casa</asp:ListItem>
            <asp:ListItem Value="APARTAMENTO">Apartamento</asp:ListItem>
            <asp:ListItem Value="COMERCIO">Comercio</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;
Dpto: 
                <asp:DropDownList ID="ddlDepartamento" runat="server" Height="30px" 
                Width="152px" AutoPostBack="True" 
                onselectedindexchanged="ddlDepartamento_SelectedIndexChanged">
                <asp:ListItem Value="0">--Seleccione Opción--</asp:ListItem>
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
        </p>
&nbsp;&nbsp;&nbsp;
Zona: 
    <asp:DropDownList ID="ddlZona" runat="server" Height="30px" Width="152px">
        <asp:ListItem Value="0">--Seleccione Opción--</asp:ListItem>
    </asp:DropDownList>
    <p>
&nbsp;
Precio: 
        <asp:DropDownList ID="ddlPrecio" runat="server" Height="30px" Width="152px">
            <asp:ListItem Value="0">--Seleccione Opción--</asp:ListItem>
            <asp:ListItem Value="1">0-4999</asp:ListItem>
            <asp:ListItem Value="2">5000-9999</asp:ListItem>
            <asp:ListItem Value="3">10000-14999</asp:ListItem>
            <asp:ListItem Value="4">15000-19999</asp:ListItem>
            <asp:ListItem Value="5">&gt;20000</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFiltrar" runat="server" onclick="btnFiltrar_Click" 
            Text="Aplico Filtro" />
            
        <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
            Text="Borrar Filtros" />
    </p>
</nav>
   
                   
    <article>
    <table class="propiedades">
                         <tr bgcolor ="#8C8D88">
                        <td  class="style1">
                            PADRON                                                                   
                        </td>
                        <td class="style1">
                            DIRECCION
                        </td>
                        <td class="style1">
                            ZONA
                        </td>
                        <td class="style1">
                            ACCION
                        </td>
                        <td class="style1">                        
                            MOSTRAR
                        </td>
                    </tr>
        <asp:Repeater ID="rpPropiedades" runat="server" 
            onitemcommand="rpPropiedades_ItemCommand">
            <ItemTEmplate>                                                               
                </table>
                <table class="propiedades">
                <tr bgcolor ="##2d81ad">
                   
                        <td>
                               <asp:Label ID="lblPadron" runat="server" Text= '<%# Bind("Padron") %>' ></asp:Label>                                                                       
                        </td>
                        <td>
                               <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("Direccion") %>' ></asp:Label>
                        </td>
                        <td>
                               <asp:Label ID="lblZona" runat="server" Text='<%# Bind("ZonaNombre") %>' ></asp:Label>
                        </td>
                        <td>
                               <asp:Label ID="lblAccion" runat="server" Text='<%# Bind("Accion") %>'></asp:Label>
                        </td>
                        <td>                        
                           <asp:Button ID="btnMostrar"  runat="server" CommandName="Mostrar" style="text-algin: center" Text="Mostrar" />
                        </td>
                    </tr>

                  
   
     </table>
            </ItemTEmplate>
              <AlternatingItemTEmplate>
                     <table class="propiedades">
                         <tr bgcolor ="#2F64A0">
                        <td>
                            <asp:Label ID="lblPadron" runat="server" Text= '<%# Bind("Padron") %>' ></asp:Label>                                                                     
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Direccion") %>' ></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server"  Text='<%# Bind("ZonaNombre") %>' ></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Accion") %>' ></asp:Label>
                        </td>
                        <td>                        
                            <asp:Button ID="btnMostrar"  runat="server" CommandName="Mostrar" style=" text-algin: center" Text="Mostrar" />

                        </td>
                    </tr>
                                                    
                </table>
                    </AlternatingItemTEmplate>
                    
     
        </asp:Repeater>
        </article>
        </div>
</asp:Content>

