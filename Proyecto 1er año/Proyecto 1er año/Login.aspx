<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_1er_año.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 24%;
        }
        .style2
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <table align="center" class="style1">
            <tr>
                <td align="center" class="style2">
                    Nombre:
                </td>
                <td>
                    <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="style2">
                    Contraseña:
                </td>
                <td>
                    <asp:TextBox ID="TBContrasenia" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="style2" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style2" colspan="2">
                    <asp:Button ID="BtnLogin" runat="server" onclick="BtnLogin_Click" 
                        Text="Ingresar" />
                </td>
            </tr>
            <tr>
                <td align="center" class="style2" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style2" colspan="2">
                    <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="LblException" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
