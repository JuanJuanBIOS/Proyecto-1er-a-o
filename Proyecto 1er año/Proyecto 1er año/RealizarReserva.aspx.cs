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
    public partial class RealizarReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LbHoteles.Visible = false;
                GVHoteles.Visible = false;
                LbHabitaciones.Visible = false;
                GVHabitaciones.Visible = false;
                LbDetalles.Visible = false;
                GVDetallesHabitacion.Visible = false;
                LbFechaIni.Visible = false;
                TBFechaIni.Visible = false;
                CalInicio.Visible = false;
                LbFechaFin.Visible = false;
                TBFechaFin.Visible = false;
                CalFin.Visible = false;
            }
        }

        protected void DDLCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbHoteles.Visible = true;
            GVHoteles.Visible = true;

            int _categoria = Convert.ToInt32(DDLCategoria.SelectedValue);

            List<Hotel> _hoteles = new List<Hotel>();
            _hoteles = LogicaHotel.HotelesporCategoria(_categoria);

            GVHoteles.DataSource = _hoteles;
            GVHoteles.DataBind();
        }
    }
}