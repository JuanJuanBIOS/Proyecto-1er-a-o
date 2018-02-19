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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Reserva> _lista = LogicaReservas.ReservasActivas();
            GVReservasActivas.DataSource = _lista;
            GVReservasActivas.DataBind();
        }

        protected void GVReservasActivas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}