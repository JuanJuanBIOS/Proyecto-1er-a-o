<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrodeCliente.aspx.cs" Inherits="Proyecto_1er_año.RegistrodeCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            margin-right: 0px;
        }
        .style2
        {
            width: 214px;
            height: 101px;
        }
        .style3
        {
            height: 101px;
            width: 1170px;
        }
        .style4
        {
            height: 40px;
        }
        .style5
        {
            height: 6px;
        }
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 131px;
        }
        .style8
        {
        }
        .style9
        {
            width: 93px;
        }
        .style10
        {
            width: 266px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2" align="right" bgcolor="#009900" valign="middle" class="style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td align="center" bgcolor="#009900" valign="middle" class="style4">
               
                </td>
            <td align="center" bgcolor="#009900" valign="middle" class="style4">
                <h1><asp:Label ID="LbTitulo" runat="server" Text="Hoteles J&amp;J"></asp:Label></h1>
                </td>
        </tr>
        <tr>
            <td bgcolor="#00CC00" class="style2" valign="top">
                        <h2 align="center">
                            <asp:Label ID="LbRegistro" runat="server" Text="Registro de Cliente"></asp:Label>
                        </h2>
                        <p align="center">
                            &nbsp;</p>
                        <p align="center">
                            &nbsp;</p>
                        <p align="center">
                            &nbsp;</p>
                        <p align="center">
                            &nbsp;</p>
                        <p align="center">
                            &nbsp;</p>
                        <p align="center">
                            &nbsp;</p>
                        <p align="center">
                            &nbsp;</p>
            </td>
            <td bgcolor="#99CC00" class="style3" valign="top">
                <table class="style6">
                    <tr>
                        <td colspan="4">
                            <h2><asp:Label ID="LbSubt" runat="server" Text="Ingrese los Datos"></asp:Label></h2>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;</td>
                        <td class="style10">
                            &nbsp;</td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Nombre completo: </td>
                        <td class="style10">
                <asp:TextBox ID="TBNombre" runat="server" Width="233px"></asp:TextBox>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Nombre de usuario: </td>
                        <td class="style10">
                <asp:TextBox ID="TBNomUsu" runat="server" Width="233px"></asp:TextBox>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Contraseña: </td>
                        <td class="style10">
                <asp:TextBox ID="TBPassword" runat="server" Width="233px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Repita la contraseña:</td>
                        <td class="style10">
                <asp:TextBox ID="TBPassword2" runat="server" Width="233px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Dirección: </td>
                        <td class="style10">
                <asp:TextBox ID="TBDireccion" runat="server" Width="233px"></asp:TextBox>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Tarjeta de Crédito: </td>
                        <td class="style10">
                <asp:TextBox ID="TBTarjeta" runat="server" Width="233px"></asp:TextBox>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Teléfono:</td>
                        <td class="style10">
                <asp:TextBox ID="TBTelefono" runat="server" Width="233px"></asp:TextBox>
                        </td>
                        <td class="style9">
                <asp:Button ID="BtnAgregar" runat="server"  
                    Text="Agregar" onclick="BtnAgregar_Click" />
                        </td>
                        <td>
                <asp:Button ID="BtnQuitar" runat="server" 
                    Text="Quitar" onclick="BtnQuitar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;</td>
                        <td class="style10">
                <asp:ListBox ID="LBTelefonos" runat="server" Height="112px" Width="178px">
                </asp:ListBox>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;</td>
                        <td class="style10">
                            &nbsp;</td>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                <asp:Button ID="BtnRegistrar" runat="server" onclick="BtnRegistrar_Click" 
                    Text="Registrar" />
                        </td>
                        <td class="style8" colspan="2">
                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="BtnOk" runat="server" onclick="BtnOk_Click" Text="Ok" 
                                Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" bgcolor="#009900" height="50" valign="middle" align="center">
                <h4>&nbsp;</h4>
                </td>
        </tr>
    </table>
    <div>
    </div>
    </form>
</body>
</html>
