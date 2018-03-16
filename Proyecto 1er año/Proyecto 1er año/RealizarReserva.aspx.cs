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
            if (Session["Usuario"] is Cliente)
            {
                if (!IsPostBack)
                {
                    LimpioFormulario();
                }
            }
            else if (Session["Usuario"] is Administrador)
            {
                Response.Redirect("BienvenidaCliente.aspx", false);
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

            private void LimpioFormulario()
            {
                LbHoteles.Visible = false;
                GVHoteles.Visible = false;
                LbHabitaciones.Visible = false;
                GVHabitaciones.Visible = false;
                LbDetalles.Visible = false;
                GVDetallesHabitacion.Visible = false;
                LbReserva.Visible = false;
                LbFechaIni.Visible = false;
                TBFechaIni.Text = "";
                TBFechaIni.Visible = false;
                CalInicio.Visible = false;
                LbFechaFin.Visible = false;
                TBFechaFin.Text = "";
                TBFechaFin.Visible = false;
                CalFin.Visible = false;
                LblError.Text = "";
                BtnOk.Visible = false;
                BtnVerificar.Visible = false;
                BtnConfirmar.Visible = false;
                BtnCancelar.Visible = false;
            }

        protected void DDLCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpioFormulario();
            LbHoteles.Visible = true;
            GVHoteles.Visible = true;

            int _categoria = Convert.ToInt32(DDLCategoria.SelectedValue);

            List<Hotel> _hoteles = new List<Hotel>();
            _hoteles = LogicaHotel.HotelesporCategoria(_categoria);

            GVHoteles.DataSource = _hoteles;
            GVHoteles.DataBind();
        }

        protected void LBVerHabitaciones_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
            LbHoteles.Visible = true;
            GVHoteles.Visible = true;
            LbHabitaciones.Visible = true;
            GVHabitaciones.Visible = true;

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
            TBFechaIni.Text = "";
            TBFechaIni.Visible = true;
            CalInicio.Visible = true;
            LbFechaFin.Visible = true;
            TBFechaFin.Text = "";
            TBFechaFin.Visible = true;
            CalFin.Visible = true;
            BtnOk.Visible = false;
            BtnVerificar.Visible = true;
            BtnConfirmar.Visible = false;
            BtnCancelar.Visible = false;

            Habitacion unaHab = LogicaHabitacion.Buscar((Hotel)Session["_hotel"], Convert.ToInt32((sender as LinkButton).CommandArgument));
            Session["_habitacion"] = unaHab;

            List<Habitacion> _detalles = new List<Habitacion>();
            _detalles.Add(unaHab);

            GVDetallesHabitacion.DataSource = _detalles;
            GVDetallesHabitacion.DataBind();
        }

        protected void CalInicio_SelectionChanged(object sender, EventArgs e)
        {
            LblError.Text = "";
            TBFechaIni.Text = CalInicio.SelectedDate.ToShortDateString();
            if (CalInicio.SelectedDate.Date < DateTime.Now.Date)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = "La fecha de Inicio no puede ser anterior al día de hoy";
            }
            if (CalInicio.SelectedDate >= CalFin.SelectedDate && TBFechaFin.Text != "")
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = "La fecha de Fin debe ser mayor a la fecha de Inicio";
            }
        }

        protected void CalFin_SelectionChanged(object sender, EventArgs e)
        {
            LblError.Text = "";
            TBFechaFin.Text = CalFin.SelectedDate.ToShortDateString();
            if (CalInicio.SelectedDate.Date < DateTime.Now.Date)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = "La fecha de Inicio no puede ser anterior al día de hoy";
            }
            if (CalInicio.SelectedDate >= CalFin.SelectedDate && TBFechaIni.Text != "")
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = "La fecha de Fin debe ser mayor a la fecha de Inicio";
            }
        }

        protected void BtnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente oCliente = (Cliente)Session["Usuario"];
                Habitacion oHabitacion = (Habitacion)Session["_habitacion"];
                DateTime oFechaIni = CalInicio.SelectedDate;
                DateTime oFechaFin = CalFin.SelectedDate;

                if (oCliente == null)
                    {
                        LblError.ForeColor = System.Drawing.Color.Red;
                        LblError.Text = "El cliente logueado no existe en la base de datos";
                    }
                    else if (oHabitacion == null)
                    {
                        LblError.ForeColor = System.Drawing.Color.Red;
                        LblError.Text = "La habitación ingresada no existe en la base de datos";
                    }
                    else if (oFechaIni == null)
                    {
                        LblError.ForeColor = System.Drawing.Color.Red;
                        LblError.Text = "La fecha de inicio no puede estar vacía";
                    }
                    else if (oFechaFin == null)
                    {
                        LblError.ForeColor = System.Drawing.Color.Red;
                        LblError.Text = "La fecha de fin no puede estar vacía";
                    }
                    else
                    {
                        double oCosto = (oFechaFin.Subtract(oFechaIni)).Days * oHabitacion.Costodiario;

                        Session["_costo"] = oCosto;

                        Reserva unaReserva = new Reserva(oCliente, oHabitacion, oFechaIni, oFechaFin, "Activa");

                        LogicaReservas.Consultar_Reserva(unaReserva);

                        Session["_reserva"] = unaReserva;

                        LblError.ForeColor = System.Drawing.Color.Blue;
                        LblError.Text = "La reserva tendrá un costo de $" + oCosto + ". ¿Desea confirmarla?";
                        DDLCategoria.Enabled = false;
                        GVHoteles.Enabled = false;
                        GVHabitaciones.Enabled = false;
                        GVDetallesHabitacion.Enabled = false;
                        CalInicio.Enabled = false;
                        CalFin.Enabled = false;
                        BtnOk.Visible = false;
                        BtnVerificar.Enabled = false;
                        BtnConfirmar.Visible = true;
                        BtnCancelar.Visible = true;
                    }
            }
            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Reserva unaReserva = (Reserva)Session["_reserva"];

                LogicaReservas.Realizar_Reserva(unaReserva);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "La reserva se realizó correctamente";
                BtnConfirmar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnOk.Visible = true;
            }

            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
            DDLCategoria.SelectedIndex = 0;
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
            DDLCategoria.SelectedIndex = 0;
        }
    }
}