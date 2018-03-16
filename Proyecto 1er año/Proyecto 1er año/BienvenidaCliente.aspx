<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true"
    CodeBehind="BienvenidaCliente.aspx.cs" Inherits="Proyecto_1er_año.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PaginaPrincipal" runat="server">
    <table style="width: 100%">
        <tr>
            <td align="center">
                <h1><asp:Label ID="LbBienvenido" runat="server" Text="Bienvenido"></asp:Label></h1>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <h3><asp:Label ID="LbInfo" runat="server" 
                    Text="Seleccione la opción deseada en el Menú Principal"></asp:Label></h3>
            </td>
        </tr>
    </table>
</asp:Content>
