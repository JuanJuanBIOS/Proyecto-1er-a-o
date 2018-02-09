using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_1er_año
{
    public partial class Master_Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadesCompartidas.Usuario usuLogueado = (EntidadesCompartidas.Usuario)Session["Usuario"];

            LblUser.Text = usuLogueado.Nombre;

            ABMHoteles.Visible = false;
            ABMHabitaciones.Visible = false;
            ABMAdministradores.Visible = false;
            ConfirmarReserva.Visible = false;
            ListadoHabRes.Visible = false;
            RealizarReserva.Visible = false;
            ReservasActivas.Visible = false;

            if (usuLogueado is EntidadesCompartidas.Cliente)
            {
                RealizarReserva.Visible = true;
                ReservasActivas.Visible = true;
            }

            if (usuLogueado is EntidadesCompartidas.Administrador)
            {
                ABMHoteles.Visible = true;
                ABMHabitaciones.Visible = true;
                ABMAdministradores.Visible = true;
                ConfirmarReserva.Visible = true;
                ListadoHabRes.Visible = true;
            }
        }
    }
}