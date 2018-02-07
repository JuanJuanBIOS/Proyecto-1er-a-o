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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();
        }

        private void LimpioFormulario()
        {
            //Bloqueo botones si no hay registro
            BtnCrear.Enabled = false;
            BtnModificar.Enabled = false;
            BtnConfirmarModificacion.Enabled = false;
            BtnEliminar.Enabled = false;

            LblError.ForeColor = System.Drawing.Color.Red;
            LblError.Text = "";
            TBPiso.Text = "";
            TBDescripcion.Text = "";
            TBHuespedes.Text = "";
            TBCostodiario.Text = "";

            BloqueoCampos();
        }

        private void BloqueoCampos()
        {
            TBPiso.Enabled = false;
            TBDescripcion.Enabled = false;
            TBHuespedes.Enabled = false;
            TBCostodiario.Enabled = false;
        }

        private void HabilitoCampos()
        {
            TBPiso.Enabled = true;
            TBDescripcion.Enabled = true;
            TBHuespedes.Enabled = true;
            TBCostodiario.Enabled = true;
        }

        private void ActivoBotonesA()
        {
            BtnCrear.Enabled = true;
            BtnModificar.Enabled = false;
            BtnConfirmarModificacion.Enabled = false;
            BtnEliminar.Enabled = false;

            HabilitoCampos();
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrear.Enabled = false;
            BtnModificar.Enabled = true;
            BtnConfirmarModificacion.Enabled = false;
            BtnEliminar.Enabled = true;

            BloqueoCampos();
        }

        private void ActivoCamposM()
        {
            BtnCrear.Enabled = false;
            BtnModificar.Enabled = false;
            BtnConfirmarModificacion.Enabled = true;
            BtnEliminar.Enabled = false;

            HabilitoCampos();
            TBNombre.Enabled = false;
            TBNumero.Enabled = false;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string hotel = TBNombre.Text;
            int habitacion;

            this.LimpioFormulario();

            try
            {
                habitacion = Convert.ToInt32(TBNumero.Text);
            }
            catch
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = "El número de habitación ingresado no es válido";
                return;
            }

            try
            {
                Habitacion Hab = LogicaHabitacion.Buscar(hotel, habitacion);
            }
            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

    }
}