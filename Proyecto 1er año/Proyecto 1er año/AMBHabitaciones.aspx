<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="AMBHabitaciones.aspx.cs" Inherits="Proyecto_1er_año.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">


    <p>
    Mantenimiento de Habitaciones</p>
<p>
    Nombre del Hotel:
    <asp:TextBox ID="TBNombre" runat="server" MaxLength="50" Width="383px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Número de Habitación: &nbsp;<asp:TextBox 
        ID="TBNumero" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
        onclick="BtnBuscar_Click" />
</p>
    <p>
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
</p>
    <table style="width: 100%">
        <tr>
            <td style="width: 177px">
                Piso:
            </td>
            <td colspan="4">
                <asp:TextBox ID="TBPiso" runat="server" Width="324px" MaxLength="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
                Descripción:
            </td>
            <td colspan="4">
                <asp:TextBox ID="TBDescripcion" runat="server" Width="324px" MaxLength="100" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
                Huéspedes:
            </td>
            <td colspan="4">
                <asp:TextBox ID="TBHuespedes" runat="server" Width="324px" MaxLength="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
                Costo Diario (USD):
            </td>
            <td colspan="4">
                <asp:TextBox ID="TBCostodiario" runat="server" Width="324px" MaxLength="7"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
                &nbsp;</td>
            <td style="width: 145px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="width: 177px" >
                <asp:Button ID="BtnCrear" runat="server" Text="Crear" 
                    onclick="BtnCrear_Click" />
            </td>
            <td align="center" >
                <asp:Button ID="BtnModificar" runat="server" Text="Modificar"/>
            </td>
            <td align="center" >
                <asp:Button ID="BtnConfirmarModificacion" runat="server" 
                    Text="Confirmar Modificación" />
            </td>
            <td align="center" >
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" />
            </td>
            <td align="center" style="width: 543px" >
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
