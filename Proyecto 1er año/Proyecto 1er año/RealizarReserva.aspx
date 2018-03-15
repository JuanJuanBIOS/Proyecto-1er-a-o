<%@ Page Title="" Language="C#"  MaintainScrollPositionOnPostback="true" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="RealizarReserva.aspx.cs" Inherits="Proyecto_1er_año.RealizarReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">
<table style="width: 100%">
        <tr>
            <td colspan="2" style="height: 24px">
                Realizar reserva</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 221px; height: 33px;">
                <asp:Label ID="LbCategoria" runat="server" 
                    Text="Seleccione la categoría del hotel: "></asp:Label>
            </td>
            <td style="height: 33px;">
                <asp:DropDownList ID="DDLCategoria" runat="server" AutoPostBack="True" 
                    Width="50px" onselectedindexchanged="DDLCategoria_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LbHoteles" runat="server" Text="Hoteles"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GVHoteles" runat="server"
                AutoGenerateColumns = "False" BackColor="White" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="Vertical" Width="953px"  >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Hotel" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="calle" HeaderText="Calle" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="numpuerta" HeaderText="Nº puerta" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ciudad" HeaderText="Ciudad" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="telefono" HeaderText="Teléfono" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fax" HeaderText="Fax" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="playa" HeaderText="Playa" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="piscina" HeaderText="Piscina" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="foto" HeaderText="Foto" ControlStyle-Width="200" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /> 
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LBVerHabitaciones" Text="Ver Habitaciones" runat="server" 
                                    CommandArgument='<%# Eval("nombre") %>' onclick="LBVerHabitaciones_Click"/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
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
            <td colspan="2" style="height: 25px" class="style4">
                &nbsp;</td>
            </tr>
        <tr>
            <td colspan="2" style="height: 25px" class="style4">
                <asp:Label ID="LbHabitaciones" runat="server" Text="Habitaciones"></asp:Label>
            &nbsp;
                </td>
            </tr>
        <tr>
            <td colspan="2" >
                <asp:GridView ID="GVHabitaciones" runat="server"
                AutoGenerateColumns = "False" BackColor="White" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="Vertical" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Hotel.Nombre" HeaderText="Hotel" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="numero" HeaderText="Habitacion" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LBVerDetalles" Text="Ver Detalles" runat="server" 
                                    CommandArgument='<%# Eval("numero") %>' onclick="LBVerDetalles_Click"/>
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
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle" colspan="2">
                <asp:Label ID="LbDetalles" runat="server" Text="Detalles de la habitación"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="middle" colspan="2">
                <asp:GridView ID="GVDetallesHabitacion" runat="server"
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
            <td valign="middle" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table style="width: 100%">
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="LbReserva" runat="server" Text="Fechas de Reserva"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 144px">
                <asp:Label ID="LbFechaIni" runat="server" Text="Fecha de Inicio"></asp:Label>
                            <br />
                <asp:TextBox ID="TBFechaIni" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="width: 275px">
                <asp:Calendar ID="CalInicio" runat="server" onselectionchanged="CalInicio_SelectionChanged"></asp:Calendar>
                        </td>
                        <td style="width: 211px">
                            &nbsp;</td>
                        <td style="width: 147px">
                <asp:Label ID="LbFechaFin" runat="server" Text="Fecha de Fin"></asp:Label>
                            <br />
                <asp:TextBox ID="TBFechaFin" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="width: 600px">
                <asp:Calendar ID="CalFin" runat="server" onselectionchanged="CalFin_SelectionChanged"></asp:Calendar>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>


                    <tr>
                        <td colspan="5">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 399px">
                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnOk" runat="server" onclick="BtnOk_Click" Text="Ok" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>


                    <tr>
                        <td colspan="5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>


                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 245px">
                            <asp:Button ID="BtnVerificar" runat="server" onclick="BtnVerificar_Click" 
                                Text="Verificar Disponibilidad" />
                        </td>
                        <td style="width: 207px">
                            <asp:Button ID="BtnConfirmar" runat="server" onclick="BtnConfirmar_Click" 
                                Text="Confirmar Reserva" />
                        </td>
                        <td>
                            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar Reserva" 
                                onclick="BtnCancelar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </asp:Content>
