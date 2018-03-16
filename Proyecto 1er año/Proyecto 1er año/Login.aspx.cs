using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EntidadesCompartidas;
using Logica;


namespace Proyecto_1er_año
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si se pasa por esta página se hace un deslogueo
            Session["Usuario"] = null;  
            TBNombre.Focus();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico el usuario y contraseña
                Usuario unUsu = LogicaUsuario.Login(TBNombre.Text, TBContrasenia.Text);
                if (unUsu != null)
                {
                    Session["Usuario"] = unUsu;
                    if (unUsu is Administrador)
                    {
                        Response.Redirect("BienvenidaAdministrador.aspx", false);
                    }
                    else if (unUsu is Cliente)
                    {
                        Response.Redirect("BienvenidaCliente.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                }
                else
                {
                    LblException.Text = "";
                    LblError.Text = "Usuario y/o contraseña incorrectos.";
                }

            }
            catch (Exception ex)
            {
                LblError.Text = "";
                LblException.Text = "Error en la base de datos. Contacte con el administrador.";
            }
        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {   
            Response.Redirect("RegistrodeCliente.aspx");
        }
    }
}