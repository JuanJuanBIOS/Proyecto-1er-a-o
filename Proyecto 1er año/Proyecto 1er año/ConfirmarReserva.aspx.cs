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
            if (Session["Usuario"] is Administrador)
            {
                List<Reserva> _lista = LogicaReservas.ReservasActivas();
                GVReservasActivas.DataSource = _lista;
                GVReservasActivas.DataBind();
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

        protected void LBSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                int idRes = Convert.ToInt32((sender as LinkButton).CommandArgument);

                Reserva unaReserva = LogicaReservas.BuscarReserva(idRes);
                if (unaReserva != null)
                {
                    LogicaReservas.ConfirmarReserva(unaReserva);
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "La Reserva ha sido confirmada correctamente.";
                    List<Reserva> _lista = LogicaReservas.ReservasActivas();
                    GVReservasActivas.DataSource = _lista;
                    GVReservasActivas.DataBind();
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