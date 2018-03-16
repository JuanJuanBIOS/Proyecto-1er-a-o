<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ReservasActivas.aspx.cs" Inherits="Proyecto_1er_año.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">
<table style="width: 100%">
        <tr>
            <td style="height: 24px" align="center">
                <h2><asp:Label ID="LbSubt" runat="server" Text="Reservas Activas"></asp:Label></h2>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <h3><asp:Label ID="LbReservas" runat="server" Text="Listado de reservas activas"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GVReservasActivas" runat="server" 
                    AutoGenerateColumns = "False" BackColor="White" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="Vertical" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="idReserva" HeaderText="ID de Reserva" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="125px" />
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LBDetalles" Text="Ver detalles" runat="server" 
                                    CommandArgument='<%# Eval("idReserva") %>' onclick="LBDetalles_Click" />
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
            <td style="height: 25px" class="style4">
                &nbsp;</td>
            </tr>
        <tr>
            <td style="height: 25px" class="style4" align="center">
                <h3><asp:Label ID="LbDetallesReserva" runat="server" Text="Detalle de la Reserva"></asp:Label></h3>
                </td>
            </tr>
        
        </table>
        <table style="width: 100%" valign="top">
                    <tr>
                        <td valign="Top" >
                            <table style="width: 100%">
                                <tr>
                                    <td align="center" colspan="2">
                                        <h4><asp:Label ID="LbHotel" runat="server" Text="Hotel"></asp:Label></h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbNombre" runat="server" Text="Nombre"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbNombre" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbEstrellas" runat="server" Text="Estrellas"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbEstrellas" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbDireccion" runat="server" Text="Dirección"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbDireccion" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbCiudad" runat="server" Text="Ciudad"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbCiudad" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbTelefono" runat="server" Text="Teléfono"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbTelefono" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbFax" runat="server" Text="Fax"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbFax" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbPlaya" runat="server" Text="Playa"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbPlaya" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbPiscina" runat="server" Text="Piscina"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbPiscina" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="LbFoto" runat="server" Text="Foto"></asp:Label>
                                                </td>
                                    <td>
                                        <asp:Image ID="ImgFoto" runat="server" ControlStyle-Width="200" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                        <td valign="Top">
                            <table style="width: 100%">
                                <tr>
                                    <td align="center" colspan="2">
                                        <h4><asp:Label ID="LbHabitacion" runat="server" Text="Habitacion"></asp:Label></h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbNumero" runat="server" Text="Numero"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbNumero" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbPiso" runat="server" Text="Piso"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbPiso" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbDescripcion" runat="server" Text="Descripcion"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbDescripcion" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbHuespedes" runat="server" Text="Huéspedes"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbHuespedes" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbCostodiario" runat="server" Text="Costo Diario ($)"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbCostodiario" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                                <h4><asp:Label ID="LbReserva" runat="server" Text="Reserva"></asp:Label></h4>
                                            </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbFechaini" runat="server" Text="Fecha de Inicio"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbFechaini" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbFechafin" runat="server" Text="Fecha de Fin"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbFechafin" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbEstado" runat="server" Text="Estado"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbEstado" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 108px">
                                                    <asp:Label ID="LbCosto" runat="server" Text="Costo Total ($)"></asp:Label>
                                                </td>
                                    <td>
                                                    <asp:TextBox ID="TbCosto" runat="server" Width="254px" Enabled="False"></asp:TextBox>
                                                </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table>
                <tr><td colspan="3">
                    &nbsp;</td></tr>
                <tr><td style="width: 250px">
                            <asp:Button ID="BtnCancelarReserva" runat="server"  
                                Text="Cancelar Reserva" onclick="BtnCencelarReserva_Click" />
                                    </td><td style="width: 250px">
                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                                    </td><td style="width: 250px">
                        <asp:Button ID="BtnOk" runat="server" onclick="BtnOk_Click" 
                            PostBackUrl="~/ReservasActivas.aspx" Text="Ok" />
                                    </td></tr>
                </table>
</asp:Content>
