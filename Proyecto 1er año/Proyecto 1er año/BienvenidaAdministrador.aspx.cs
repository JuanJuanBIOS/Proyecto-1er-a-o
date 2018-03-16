using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

namespace Proyecto_1er_año
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] is Administrador)
            {

            }
            else if (Session["Usuario"] is Cliente)
            {
                Response.Redirect("BienvenidaCliente.aspx", false);
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}