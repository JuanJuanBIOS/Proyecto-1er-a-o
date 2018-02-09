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
            TBNombre.Focus();
            
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
            TBFax.Text = "";
            TBEstrellas.Text = "";
            CBPlaya.Checked = false;
            CBPiscina.Checked = false;

            BloqueoCampos();

        }

        private void BloqueoCampos()
        {
            TBCalle.Enabled = false;
            TBCiudad.Enabled = false;
            TBNumPuerta.Enabled = false;
            TBTelefono.Enabled = false;
            TBFax.Enabled = false;
            TBEstrellas.Enabled = false;
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
            TBFax.Enabled = true;
            TBEstrellas.Enabled = true;
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
                    TBFax.Text = Hot.Fax;
                    TBEstrellas.Text = Hot.Estrellas;
                    CBPlaya.Checked = Hot.Playa;
                    CBPiscina.Checked = Hot.Piscina;

                    ActivoBotonesBM();

                }
            }
            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }

        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _Calle = Convert.ToString(TBCalle.Text);
                string _Numpuerta = Convert.ToString(TBNumPuerta.Text);
                string _Ciudad = Convert.ToString(TBCiudad.Text);
                string _Telefono = Convert.ToString(TBTelefono.Text);
                string _Fax = Convert.ToString(TBFax.Text);
                bool _Playa = CBPlaya.Checked;
                bool _Piscina = CBPiscina.Checked;
                string _Estrellas = Convert.ToString(TBEstrellas.Text);


                Hotel unHotel = new Hotel(_Nombre, _Calle, _Numpuerta, _Ciudad, _Telefono, _Fax, _Playa, _Piscina, _Estrellas);

                LogicaHotel.Crear(unHotel);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Hotel ha sido ingresado a la base de datos correctamente.";
                BloqueoCampos();
            }

            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            ActivoCamposM();
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _Calle = Convert.ToString(TBCalle.Text);
                string _Numpuerta = Convert.ToString(TBNumPuerta.Text);
                string _Ciudad = Convert.ToString(TBCiudad.Text);
                string _Telefono = Convert.ToString(TBTelefono.Text);
                string _Fax = Convert.ToString(TBFax.Text);
                bool _Playa = CBPlaya.Checked;
                bool _Piscina = CBPiscina.Checked;
                string _Estrellas = Convert.ToString(TBEstrellas.Text);

                Hotel unHotel = new Hotel(_Nombre, _Calle, _Numpuerta, _Ciudad, _Telefono, _Fax, _Playa, _Piscina, _Estrellas);

                LogicaHotel.Modificar(unHotel);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Hotel ha sido modificado correctamente.";
                BloqueoCampos();
                TBNombre.Enabled = true;
                BtnConfirmar.Enabled = false;
            }

            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _Calle = Convert.ToString(TBCalle.Text);
                string _Numpuerta = Convert.ToString(TBNumPuerta.Text);
                string _Ciudad = Convert.ToString(TBCiudad.Text);
                string _Telefono = Convert.ToString(TBTelefono.Text);
                string _Fax = Convert.ToString(TBFax.Text);
                bool _Playa = CBPlaya.Checked;
                bool _Piscina = CBPiscina.Checked;
                string _Estrellas = Convert.ToString(TBEstrellas.Text);

                Hotel unHotel = new Hotel(_Nombre, _Calle, _Numpuerta, _Ciudad, _Telefono, _Fax, _Playa, _Piscina, _Estrellas);

                BtnBuscar_Click(unHotel, e);
                LogicaHotel.Eliminar(unHotel);
                LimpioFormulario();
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Hotel ha sido eliminado correctamente.";
            }

            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        } 

    }
}