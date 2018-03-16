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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] is Cliente)
            {
                if (!IsPostBack)
                {
                    LimpioFormulario();
                }
                Cliente unCli = (Cliente)Session["Usuario"];
                List<Reserva> _activas = LogicaReservas.ReservasActivasporUsuario(unCli.Nomusu);

                GVReservasActivas.DataSource = _activas;
                GVReservasActivas.DataBind();
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
            LbDetallesReserva.Visible = false;
            LbHotel.Visible = false;
            LbNombre.Visible = false;
            TbNombre.Visible = false;
            LbEstrellas.Visible = false;
            TbEstrellas.Visible = false;
            LbDireccion.Visible = false;
            TbDireccion.Visible = false;
            LbCiudad.Visible = false;
            TbCiudad.Visible = false;
            LbTelefono.Visible = false;
            TbTelefono.Visible = false;
            LbFax.Visible = false;
            TbFax.Visible = false;
            LbPlaya.Visible = false;
            TbPlaya.Visible = false;
            LbPiscina.Visible = false;
            TbPiscina.Visible = false;
            LbFoto.Visible = false;
            ImgFoto.Visible = false;

            LbHabitacion.Visible = false;
            LbNumero.Visible = false;
            TbNumero.Visible = false;
            LbPiso.Visible = false;
            TbPiso.Visible = false;
            LbDescripcion.Visible = false;
            TbDescripcion.Visible = false;
            LbHuespedes.Visible = false;
            TbHuespedes.Visible = false;
            LbCostodiario.Visible = false;
            TbCostodiario.Visible = false;

            LbReserva.Visible = false;
            LbFechaini.Visible = false;
            TbFechaini.Visible = false;
            LbFechafin.Visible = false;
            TbFechafin.Visible = false;
            LbEstado.Visible = false;
            TbEstado.Visible = false;
            LbCosto.Visible = false;
            TbCosto.Visible = false;

            BtnCancelarReserva.Visible = false;
            BtnOk.Visible = false;
        }

        private void ActivoFormulario()
        {
            LbDetallesReserva.Visible = true;
            LbHotel.Visible = true;
            LbNombre.Visible = true;
            TbNombre.Visible = true;
            LbEstrellas.Visible = true;
            TbEstrellas.Visible = true;
            LbDireccion.Visible = true;
            TbDireccion.Visible = true;
            LbCiudad.Visible = true;
            TbCiudad.Visible = true;
            LbTelefono.Visible = true;
            TbTelefono.Visible = true;
            LbFax.Visible = true;
            TbFax.Visible = true;
            LbPlaya.Visible = true;
            TbPlaya.Visible = true;
            LbPiscina.Visible = true;
            TbPiscina.Visible = true;
            LbFoto.Visible = true;
            ImgFoto.Visible = true;

            LbHabitacion.Visible = true;
            LbNumero.Visible = true;
            TbNumero.Visible = true;
            LbPiso.Visible = true;
            TbPiso.Visible = true;
            LbDescripcion.Visible = true;
            TbDescripcion.Visible = true;
            LbHuespedes.Visible = true;
            TbHuespedes.Visible = true;
            LbCostodiario.Visible = true;
            TbCostodiario.Visible = true;

            LbReserva.Visible = true;
            LbFechaini.Visible = true;
            TbFechaini.Visible = true;
            LbFechafin.Visible = true;
            TbFechafin.Visible = true;
            LbEstado.Visible = true;
            TbEstado.Visible = true;
            LbCosto.Visible = true;
            TbCosto.Visible = true;

            BtnCancelarReserva.Enabled = true;
            BtnCancelarReserva.Visible = true;
        }

        protected void LBDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                int idRes = Convert.ToInt32((sender as LinkButton).CommandArgument);

                Reserva unaReserva = LogicaReservas.BuscarReserva(idRes);
                Session["_reserva"] = unaReserva;

                if (unaReserva != null)
                {
                    ActivoFormulario();
                    TbNombre.Text = unaReserva.Habitacion.Hotel.Nombre;
                    TbEstrellas.Text = unaReserva.Habitacion.Hotel.Estrellas;
                    TbDireccion.Text = unaReserva.Habitacion.Hotel.Calle + " " + unaReserva.Habitacion.Hotel.Numpuerta;
                    TbCiudad.Text = unaReserva.Habitacion.Hotel.Ciudad;
                    TbTelefono.Text = unaReserva.Habitacion.Hotel.Telefono;
                    TbFax.Text = unaReserva.Habitacion.Hotel.Fax;
                    if (unaReserva.Habitacion.Hotel.Playa)
                        TbPlaya.Text = "Si";
                    else
                        TbPlaya.Text = "No";
                    if (unaReserva.Habitacion.Hotel.Piscina)
                        TbPiscina.Text = "Si";
                    else
                        TbPiscina.Text = "No";
                    ImgFoto.ImageUrl = unaReserva.Habitacion.Hotel.Foto;

                    TbNumero.Text = unaReserva.Habitacion.Numero.ToString();
                    TbPiso.Text = unaReserva.Habitacion.Piso;
                    TbDescripcion.Text = unaReserva.Habitacion.Descripcion;
                    TbHuespedes.Text = unaReserva.Habitacion.Huespedes;
                    TbCostodiario.Text = unaReserva.Habitacion.Costodiario.ToString();

                    TbFechaini.Text = unaReserva.Fechaini.ToShortDateString();
                    TbFechafin.Text = unaReserva.Fechafin.ToShortDateString();
                    TbEstado.Text = unaReserva.Estado;
                    double oCosto = (unaReserva.Fechafin.Subtract(unaReserva.Fechaini)).Days * unaReserva.Habitacion.Costodiario;
                    TbCosto.Text = oCosto.ToString();
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

        protected void BtnCencelarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                Reserva unaReserva = (Reserva)Session["_reserva"];

                LogicaReservas.Cancelar_Reserva(unaReserva);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "La reserva se canceló correctamente";
                BtnCancelarReserva.Enabled = false;
                GVReservasActivas.Enabled = false;
                BtnOk.Visible = true;
            }

            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            GVReservasActivas.Enabled = true;
            LblError.Text = "";
            LimpioFormulario();
        }
    }
}