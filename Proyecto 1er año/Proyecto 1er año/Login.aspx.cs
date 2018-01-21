﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Proyecto_1er_año
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si se pasa por esta página se hace un deslogueo
            Session["Usuario"] = null;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico el usuario y contraseña
                EntidadesCompartidas.Usuario unUsu = Logica.LogicaUsuario.Login(TBNombre.Text, TBContrasenia.Text);
                if (unUsu != null)
                {
                    Session["Usuario"] = unUsu;
                    //Response.Redirect(".aspx");
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
    }
}