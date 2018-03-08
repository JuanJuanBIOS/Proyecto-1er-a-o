<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="Proyecto_1er_año.RegistroCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 286px;
        }
        .style3
        {
            width: 151px;
        }
        .style4
        {
            text-align: left;
        }
        .style5
        {
            width: 151px;
            text-align: left;
        }
        .style6
        {
            width: 286px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
            Registro de Cliente</h1>
    
    </div>
    <table class="style1">
        <tr>
            <td class="style2" valign="top">
                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td colspan="2" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                Nombre de usuario:</td>
            <td class="style4" colspan="2" valign="top">
                <asp:TextBox ID="TBNomUsu" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                Nombre:</td>
            <td class="style4" colspan="2" valign="top">
                <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                Password:</td>
            <td class="style4" colspan="2" valign="top">
                <asp:TextBox ID="TBPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                Ingrese password nuevamente:</td>
            <td class="style4" colspan="2" valign="top">
                <asp:TextBox ID="TBPassword2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                Dirección:</td>
            <td class="style4" colspan="2" valign="top">
                <asp:TextBox ID="TBDireccion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                Tarjeta de crédito:</td>
            <td class="style4" colspan="2" valign="top">
                <asp:TextBox ID="TBTarjeta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                Teléfono:</td>
            <td class="style5" valign="top">
                <asp:TextBox ID="TBTelefono" runat="server"></asp:TextBox>
&nbsp;
            </td>
            <td class="style4" valign="top">
                <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" 
                    Text="Agregar" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnQuitar" runat="server" onclick="BtnQuitar_Click" 
                    Text="Quitar" />
            </td>
        </tr>
        <tr>
            <td class="style2" valign="top">
                &nbsp;</td>
            <td class="style3" valign="top">
                <asp:ListBox ID="LBTelefonos" runat="server" Height="112px" Width="178px">
                </asp:ListBox>
            </td>
            <td valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" valign="top">
                <asp:Button ID="BtnRegistrar" runat="server" onclick="BtnRegistrar_Click" 
                    Text="Registrar" />
            </td>
            <td class="style3" valign="top">
                &nbsp;</td>
            <td valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" valign="top">
                &nbsp;</td>
            <td class="style3" valign="top">
                &nbsp;</td>
            <td valign="top">
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
