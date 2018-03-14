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
                LbReserva.Visible = false;
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
            LbHabitaciones.Visible = false;
            GVHabitaciones.Visible = false;
            LbDetalles.Visible = false;
            GVDetallesHabitacion.Visible = false;
            LbReserva.Visible = false;
            LbFechaIni.Visible = false;
            TBFechaIni.Visible = false;
            CalInicio.Visible = false;
            LbFechaFin.Visible = false;
            TBFechaFin.Visible = false;
            CalFin.Visible = false;

            int _categoria = Convert.ToInt32(DDLCategoria.SelectedValue);

            List<Hotel> _hoteles = new List<Hotel>();
            _hoteles = LogicaHotel.HotelesporCategoria(_categoria);

            GVHoteles.DataSource = _hoteles;
            GVHoteles.DataBind();
        }

        protected void LBVerHabitaciones_Click(object sender, EventArgs e)
        {
            LbHabitaciones.Visible = true;
            GVHabitaciones.Visible = true;
            LbDetalles.Visible = false;
            GVDetallesHabitacion.Visible = false;
            LbReserva.Visible = false;
            LbFechaIni.Visible = false;
            TBFechaIni.Visible = false;
            CalInicio.Visible = false;
            LbFechaFin.Visible = false;
            TBFechaFin.Visible = false;
            CalFin.Visible = false;
            Hotel unHot = LogicaHotel.Buscar(((sender as LinkButton).CommandArgument).ToString());
            Session["_hotel"] = unHot;

            List<Habitacion> _habitaciones = new List<Habitacion>();
            _habitaciones = LogicaHabitacion.ListarHabitaciones(unHot);

            GVHabitaciones.DataSource = _habitaciones;
            GVHabitaciones.DataBind();
        }

        protected void LBVerDetalles_Click(object sender, EventArgs e)
        {
            LbDetalles.Visible = true;
            GVDetallesHabitacion.Visible = true;
            LbReserva.Visible = true;
            LbFechaIni.Visible = true;
            TBFechaIni.Visible = true;
            CalInicio.Visible = true;
            LbFechaFin.Visible = true;
            TBFechaFin.Visible = true;
            CalFin.Visible = true;

            Habitacion unaHab = LogicaHabitacion.Buscar((Hotel)Session["_hotel"], Convert.ToInt32((sender as LinkButton).CommandArgument));
            Session["_habitacion"] = unaHab;

            List<Habitacion> _detalles = new List<Habitacion>();
            _detalles.Add(unaHab);

            GVDetallesHabitacion.DataSource = _detalles;
            GVDetallesHabitacion.DataBind();
        }
    }
}