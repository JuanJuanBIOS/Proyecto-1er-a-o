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
            if (!IsPostBack)
            {
                Session["_habitacion"] = null;
                LbHabitaciones.Visible = false;
                LbReservas.Visible = false;
                LbEstado.Visible = false;
                DdlEstado.Visible = false;
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

        protected void DDLHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbReservas.Visible = false;
            LbEstado.Visible = false;
            DdlEstado.Visible = false;
            GVReservas.Visible = false;

            Hotel _hotel = LogicaHotel.Buscar(DDLHotel.SelectedValue.ToString());

            LbHabitaciones.Visible = true;

            List<Habitacion> _habitaciones = new List<Habitacion>();
            _habitaciones = LogicaHabitacion.ListarHabitaciones(_hotel);

            GVHabitaciones.DataSource = _habitaciones;
            GVHabitaciones.DataBind();
        }

        protected void LBVerReservas_Click(object sender, EventArgs e)
        {
            LbReservas.Visible = true;
            LbEstado.Visible = true;
            DdlEstado.Visible = true;
            Session["_habitacion"] = Convert.ToInt32((sender as LinkButton).CommandArgument);
        }

        protected void DdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            GVReservas.Visible = true;

            try
            {
                Hotel _hotel = LogicaHotel.Buscar(DDLHotel.SelectedValue.ToString());

                Habitacion unaHabitacion = LogicaHabitacion.Buscar(_hotel, (int)Session["_habitacion"]);
                if (unaHabitacion != null)
                {
                    List<Reserva> _reservas = new List<Reserva>();
                    if (DdlEstado.SelectedIndex == 0)
                    {
                        GVReservas.Visible = false;
                    }
                    else if (DdlEstado.SelectedIndex == 1)
                    {
                        _reservas = LogicaReservas.ReservasHabitacionTodas(unaHabitacion);
                        GVReservas.DataSource = _reservas;
                        GVReservas.DataBind();
                    }
                    else if (DdlEstado.SelectedIndex == 2)
                    {
                        _reservas = LogicaReservas.ReservasHabitacionActivas(unaHabitacion);
                        GVReservas.DataSource = _reservas;
                        GVReservas.DataBind();
                    }
                    else if (DdlEstado.SelectedIndex == 3)
                    {
                        _reservas = LogicaReservas.ReservasHabitacionFinalizadas(unaHabitacion);
                        GVReservas.DataSource = _reservas;
                        GVReservas.DataBind();
                    }
                    else if (DdlEstado.SelectedIndex == 4)
                    {
                        _reservas = LogicaReservas.ReservasHabitacionCanceladas(unaHabitacion);
                        GVReservas.DataSource = _reservas;
                        GVReservas.DataBind();
                    }
                }
                else
                {
                    LblError.ForeColor = System.Drawing.Color.Red;
                    LblError.Text = "La Reserva no se encuentra en la base de datos";

                }
            }
            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }
    }
}