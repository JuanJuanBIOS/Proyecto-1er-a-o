<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="RealizarReserva.aspx.cs" Inherits="Proyecto_1er_año.RealizarReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">
    <h2>
    Realizar Reserva</h2>
Seleccione una categoría de hotel:<asp:DropDownList ID="DDLEstrellas" 
        runat="server" Width="36px">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
        <asp:ListItem Value="3"></asp:ListItem>
        <asp:ListItem Value="4"></asp:ListItem>
        <asp:ListItem Value="5"></asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;
<asp:Button ID="BtnBuscar" runat="server" Text="Buscar" />
<br />
<br />
<asp:GridView ID="CVHoteles" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="372px">
    <Columns>
        <asp:BoundField HeaderText="Nombre" />
        <asp:BoundField HeaderText="Fax" />
        <asp:CheckBoxField HeaderText="Piscina" />
        <asp:CheckBoxField HeaderText="Playa" />
        <asp:BoundField HeaderText="Teléfono" />
        <asp:BoundField HeaderText="Dirección" />
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>
<br />
Habitaciones:<br />
<asp:GridView ID="GVHabitaciones" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ForeColor="Black" GridLines="Horizontal">
    <Columns>
        <asp:BoundField HeaderText="Número" />
        <asp:BoundField HeaderText="Piso" />
        <asp:BoundField HeaderText="Huespedes" />
        <asp:BoundField HeaderText="Descripción" />
        <asp:BoundField HeaderText="Costo diario" />
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>
<br />
Fechas:<br />
<table style="width: 100%">
    <tr>
        <td style="width: 347px">
            Desde:</td>
        <td style="width: 413px">
            Hasta:</td>
    </tr>
    <tr>
        <td style="width: 347px">
            <asp:Calendar ID="CalDesde" runat="server"></asp:Calendar>
        </td>
        <td style="width: 413px">
            <asp:Calendar ID="CalHasta" runat="server"></asp:Calendar>
        </td>
    </tr>
</table>
<br />
<br />
<br />
</asp:Content>
