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
            <td style="width: 49px; height: 34px;">
                Hotel:</td>
            <td colspan="2" style="height: 34px">
                <asp:DropDownList ID="DDLHotel" runat="server" 
                    onselectedindexchanged="DDLHotel_SelectedIndexChanged" AutoPostBack="True" 
                     Width="222px">
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
            <td colspan="3">
                <asp:Label ID="LbHabitaciones" runat="server" Text="Habitaciones"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GVHabitaciones" runat="server"
                AutoGenerateColumns = "False" BackColor="White" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="Vertical" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="numero" HeaderText="Nº Habitación" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="piso" HeaderText="Piso" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="huespedes" HeaderText="Huéspedes" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="costodiario" HeaderText="Costo Diario ($)" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LBVerReservas" Text="Ver Reservas" runat="server" 
                                    CommandArgument='<%# Eval("numero") %>' onclick="LBVerReservas_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
            </tr>
        <tr>
            <td colspan="3" style="height: 25px" class="style4">
                &nbsp;</td>
            </tr>
        <tr>
            <td colspan="3" style="height: 25px" class="style4">
                <asp:Label ID="LbReservas" runat="server" Text="Reservas"></asp:Label>
            &nbsp;
                </td>
            </tr>
        <tr>
            <td colspan="3" valign="middle" >
                <asp:Label ID="LbEstado" runat="server" 
                    Text="Seleccione Estado de la reserva: "></asp:Label>
                <asp:DropDownList ID="DdlEstado" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DdlEstado_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem>Activa</asp:ListItem>
                    <asp:ListItem>Finalizada</asp:ListItem>
                    <asp:ListItem>Cancelada</asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
        <tr>
            <td colspan="3" >
                <asp:GridView ID="GVReservas" runat="server"
                AutoGenerateColumns = "False" BackColor="White" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="idReserva" HeaderText="ID de Reserva" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="125px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Cliente.Nombre" HeaderText="Cliente" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Habitacion.Hotel.Nombre" HeaderText="Hotel" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Habitacion.Numero" HeaderText="Habitación" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fechaini" DataFormatString="{0:d}" HeaderText="Fecha Inicio" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fechafin" DataFormatString="{0:d}" HeaderText="Fecha Fin" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Estado" DataFormatString="{0:d}" HeaderText="Estado" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
            </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle" colspan="3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
