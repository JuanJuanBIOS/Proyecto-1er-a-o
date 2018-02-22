<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ListadodeHabyRes.aspx.cs" Inherits="Proyecto_1er_año.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="3">
                Listado de Habitaciones y Reservas</td>
        </tr>
        <tr>
            <td style="width: 49px">
                &nbsp;</td>
            <td style="width: 171px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 49px; height: 26px;">
                Hotel:</td>
            <td colspan="2" style="height: 26px">
                <asp:DropDownList ID="DDLHotel" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 49px">
                &nbsp;</td>
            <td style="width: 171px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="LbHabitaciones" runat="server" Text="Habitaciones"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="LbReservas" runat="server" Text="Reservas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
            <td align="center">
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
