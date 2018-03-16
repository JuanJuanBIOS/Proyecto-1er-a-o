using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.IO;


namespace Proyecto_1er_año
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] is Administrador)
            {
                if (!IsPostBack)
                    this.LimpioFormulario();
                TBNombre.Focus();
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
                    ImagenHotel.ImageUrl = Hot.Foto;

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
                string _Foto = ImagenHotel.ImageUrl;


                Hotel unHotel = new Hotel(_Nombre, _Calle, _Numpuerta, _Ciudad, _Telefono, _Fax, _Playa, _Piscina, _Estrellas, _Foto);

                LogicaHotel.Crear(unHotel);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Hotel ha sido ingresado a la base de datos correctamente.";
                BloqueoCampos();
                BtnCrear.Enabled = false;
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
                string _Foto = "";
                
                if (FileUpload.HasFile)
                {
                    try
                    {
                        if (FileUpload.PostedFile.ContentType == "image/jpeg")
                        {
                            if (FileUpload.PostedFile.ContentLength < 1024000)
                            {
                                FileUpload.PostedFile.SaveAs(Server.MapPath("~/Imagenes/") + FileUpload.FileName);
                                Session["imagen"] = "~/Imagenes/" + FileUpload.FileName;
                                LblError.Text = "Imagen cargada!";
                                //muestro imagen
                                ImagenHotel.ImageUrl = Session["imagen"].ToString();
                            }
                            else
                                LblError.Text = "El archivo debe tener menos de 100kb!";
                        }
                        else
                            LblError.Text = "Solo archivos JPEG son aceptados!";
                    }
                    catch (Exception ex)
                    {
                        LblError.Text = "El archivo no pudo ser cargado. El siquiente error ocurrio: " + ex.Message;
                    }
                }

                _Foto = ImagenHotel.ImageUrl;


                Hotel unHotel = new Hotel(_Nombre, _Calle, _Numpuerta, _Ciudad, _Telefono, _Fax, _Playa, _Piscina, _Estrellas, _Foto);

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
                string _Foto = ImagenHotel.ImageUrl;

                Hotel unHotel = new Hotel(_Nombre, _Calle, _Numpuerta, _Ciudad, _Telefono, _Fax, _Playa, _Piscina, _Estrellas, _Foto);

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

        protected void FileUpload_DataBinding(object sender, EventArgs e)
        {
            FileUpload.PostedFile.SaveAs(Server.MapPath("~/Imagenes/") + FileUpload.FileName);
            Session["imagen"] = "~/Imagenes/" + FileUpload.FileName;
            LblError.Text = "Imagen cargada!";
            //muestro imagen
            ImagenHotel.ImageUrl = Session["imagen"].ToString();
        }








    }
}