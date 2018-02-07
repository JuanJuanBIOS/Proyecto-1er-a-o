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
    public partial class WebForm4 : System.Web.UI.Page
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
            BtnConfirmar.Enabled = false;
            BtnEliminar.Enabled = false;

            LblError.Text = "";
            TBCalle.Text = "";
            TBCiudad.Text = "";
            TBNumPuerta.Text = "";
            TBTelefono.Text = "";

            BloqueoCampos();

        }

        private void BloqueoCampos()
        {
            TBCalle.Enabled = false;
            TBCiudad.Enabled = false;
            TBNumPuerta.Enabled = false;
            TBTelefono.Enabled = false;
            ImagenHotel.Visible = false;
            CBPiscina.Enabled = false;
            CBPlaya.Enabled = false;
            FileUpload.Enabled = false;
        }

        private void HabilitoCampos()
        {
            TBCalle.Enabled = true;
            TBCiudad.Enabled = true;
            TBNumPuerta.Enabled = true;
            TBTelefono.Enabled = true;
            ImagenHotel.Visible = true;
            CBPiscina.Enabled = true;
            CBPlaya.Enabled = true;
            FileUpload.Enabled = true;
        }

        private void ActivoBotonesA()
        {
            //Activo botones para Alta
            BtnCrear.Enabled = true;
            BtnModificar.Enabled = false;
            BtnConfirmar.Enabled = false;
            BtnEliminar.Enabled = false;

            HabilitoCampos();
        }

        private void ActivoBotonesBM()
        {
            //Activo botones para Baja y Modificacion
            BtnCrear.Enabled = false;
            BtnModificar.Enabled = true;
            BtnConfirmar.Enabled = false;
            BtnEliminar.Enabled = true;

            BloqueoCampos();
        }

        private void ActivoCamposM()
        {
            //Activo campos para Modificacion
            BtnCrear.Enabled = false;
            BtnModificar.Enabled = false;
            BtnConfirmar.Enabled = true;
            BtnEliminar.Enabled = false;

            HabilitoCampos();
            TBNombre.Enabled = false;

        }


        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = TBNombre.Text;
            this.LimpioFormulario();

            try
            {
                Hotel Hot = LogicaHotel.Buscar(nombre);

                if (Hot == null)
                {
                    LblError.ForeColor = System.Drawing.Color.Red;
                    LblError.Text = "El hotel ingresado no existe en la base de datos. Ingrese los datos y presione 'Crear'";
                    this.ActivoBotonesA();
                }
                else
                {
                    TBCalle.Text = Hot.Calle;
                    TBCiudad.Text = Hot.Ciudad;
                    TBNumPuerta.Text = Hot.Numpuerta;
                    TBTelefono.Text = Hot.Telefono;

                    ActivoBotonesBM();

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