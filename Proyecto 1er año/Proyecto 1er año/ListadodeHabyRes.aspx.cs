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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbHabitaciones.Visible = false;
            LbReservas.Visible = false;
            List<string> _hoteles = new List<string>();
            _hoteles.Add("");
            foreach (string _hotel in LogicaHotel.ListaHoteles())
            {
                _hoteles.Add(_hotel);
            }
            DDLHotel.DataSource = _hoteles;
            DDLHotel.DataBind();
        }
    }
}