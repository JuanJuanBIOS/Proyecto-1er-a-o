<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ABMAdministrador.aspx.cs" Inherits="Proyecto_1er_año.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">
    <h2>
        Mantenimiento de Hoteles</h2>
    <p>
        Ingrese nombre de Usuario:&nbsp; 
        <asp:TextBox ID="TBNomUsu" 
            runat="server" MaxLength="10" Width="200px"></asp:TextBox>
    &nbsp;&nbsp;
        <asp:Button ID="BtnBuscar" runat="server" onclick="BtnBuscar_Click" 
            Text="Buscar" />
    </p>
    <p>
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <table class="style1">
        <tr>
            <td style="width: 370px; height: 26px;">
                Nombre:</td>
            <td style="width: 691px; height: 26px;" colspan="5">
                <asp:TextBox ID="TBNombre" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Pass: </td>
            <td style="width: 691px" colspan="5">
                <asp:TextBox ID="TBPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Cargo:</td>
            <td style="width: 691px" colspan="5">
                <asp:DropDownList ID="DDLCargo" runat="server" Height="23px" Width="130px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Gerente</asp:ListItem>
                    <asp:ListItem>Jefe</asp:ListItem>
                    <asp:ListItem>Administrativo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                &nbsp;</td>
            <td style="width: 691px" colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 370px; height: 30px;">
                <asp:Button ID="BtnCrear" runat="server" Text="Crear" Width="47px" 
                    onclick="BtnCrear_Click" />
            </td>
            <td style="width: 427px; height: 30px; margin-left: 120px;">
                <asp:Button ID="BtnModificar" runat="server" Text="Modificar" 
                    onclick="BtnModificar_Click" />
            </td>
            <td style="width: 691px; height: 30px;">
                <asp:Button ID="BtnConfirmarModificacion" runat="server" Text="Confirmar Modificacion" 
                    onclick="BtnConfirmarModificacion_Click" />
            </td>
            <td style="width: 1035px; height: 30px; margin-left: 120px;">
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" 
                    onclick="BtnEliminar_Click" />
            </td>
            <td style="width: 1018px; height: 30px;">
                </td>
            <td style="width: 691px; height: 30px;">
                </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</asp:Content>
