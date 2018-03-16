<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ABMHoteles.aspx.cs" Inherits="Proyecto_1er_año.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">
    <h2 align="center">
        <asp:Label ID="LbSubt" runat="server" Text="Mantenimiento de Hoteles"></asp:Label>
    </h2>
    <p>
        Ingrese nombre de Hotel:&nbsp; <asp:TextBox ID="TBNombre" 
            runat="server" MaxLength="50" Width="861px"></asp:TextBox>
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
                Calle:</td>
            <td style="width: 691px; height: 26px;" colspan="5">
                <asp:TextBox ID="TBCalle" runat="server" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Número de puerta:</td>
            <td style="width: 691px" colspan="5">
                <asp:TextBox ID="TBNumPuerta" runat="server" MaxLength="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Ciudad:</td>
            <td style="width: 691px" colspan="5">
                <asp:TextBox ID="TBCiudad" runat="server" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Telefono:</td>
            <td style="width: 691px" colspan="5">
                <asp:TextBox ID="TBTelefono" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Fax:</td>
            <td style="width: 691px" colspan="5">
                <asp:TextBox ID="TBFax" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Estrellas:</td>
            <td style="width: 691px" colspan="5">
                <asp:TextBox ID="TBEstrellas" runat="server" MaxLength="1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Playa:</td>
            <td style="width: 691px" colspan="5">
                <asp:CheckBox ID="CBPlaya" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Piscina:</td>
            <td style="width: 691px" colspan="5">
                <asp:CheckBox ID="CBPiscina" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 370px">
                Foto:</td>
            <td style="width: 691px" colspan="5">
                <asp:Image ID="ImagenHotel" runat="server" AlternateText="Imagen no disponible" 
                    Height="198px" Width="288px" />
                <br />
                <br />
                <asp:FileUpload ID="FileUpload" runat="server" 
                    ondatabinding="FileUpload_DataBinding" />
            </td>
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
                <asp:Button ID="BtnConfirmar" runat="server" Text="Confirmar Modificacion" 
                    onclick="BtnConfirmar_Click" />
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
