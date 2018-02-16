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
            TBNombre.Focus();
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
                Hotel Hot = LogicaHotel.Buscar(hotel);
                if (Hot == null)
                {
                    LblError.ForeColor = System.Drawing.Color.Red;
                    LblError.Text = "El Hotel ingresado no existe en la base de datos";
                }
                else
                {
                    Habitacion Hab = LogicaHabitacion.Buscar(Hot, habitacion);
                    if (Hab == null)
                    {
                        LblError.ForeColor = System.Drawing.Color.Red;
                        LblError.Text = "La Habitación ingresada no existe en la base de datos";
                        this.ActivoBotonesA();
                    }
                    else
                    {
                        TBPiso.Text = Hab.Piso;
                        TBDescripcion.Text = Hab.Descripcion;
                        TBHuespedes.Text = Hab.Huespedes;
                        TBCostodiario.Text = Convert.ToString(Hab.Costodiario);

                        ActivoBotonesBM();
                    }
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
                int _Numero = Convert.ToInt32(TBNumero.Text);
                string _Piso = Convert.ToString(TBPiso.Text);
                string _Descripcion = Convert.ToString(TBDescripcion.Text);
                string _Huespedes = Convert.ToString(TBHuespedes.Text);
                double _Costodiario = Convert.ToDouble(TBCostodiario.Text);

                Hotel unHotel = LogicaHotel.Buscar(_Nombre);

                if (unHotel == null)
                {
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "El Hotel ingresado no existe en la base de datos";
                }
                else
                {
                    Habitacion unaHabitacion = new Habitacion(_Numero, unHotel, _Piso, _Descripcion, _Huespedes, _Costodiario);

                    LogicaHabitacion.Crear(unaHabitacion);
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "La Habitación ha sido ingresada a la base de datos correctamente.";
                    BloqueoCampos();
                }
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

        protected void BtnConfirmarModificacion_Click(object sender, EventArgs e)
        {
            try
            {
                int _Numero = Convert.ToInt32(TBNumero.Text);
                string _Piso = Convert.ToString(TBPiso.Text);
                string _Descripcion = Convert.ToString(TBDescripcion.Text);
                string _Huespedes = Convert.ToString(TBHuespedes.Text);
                double _Costodiario = Convert.ToDouble(TBCostodiario.Text);

                Hotel unHotel = LogicaHotel.Buscar(TBNombre.Text);

                if (unHotel == null)
                {
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "El Hotel ingresado no existe en la base de datos";
                }
                else
                {
                    Habitacion unaHabitacion = new Habitacion(_Numero, unHotel, _Piso, _Descripcion, _Huespedes, _Costodiario);

                    LogicaHabitacion.Modificar(unaHabitacion);
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "La Habitación ha sido modificada correctamente.";
                    BloqueoCampos();
                    TBNombre.Enabled = true;
                    TBNumero.Enabled = true;
                    BtnConfirmarModificacion.Enabled = false;
                }
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
                int _Numero = Convert.ToInt32(TBNumero.Text);
                string _Piso = Convert.ToString(TBPiso.Text);
                string _Descripcion = Convert.ToString(TBDescripcion.Text);
                string _Huespedes = Convert.ToString(TBHuespedes.Text);
                double _Costodiario = Convert.ToDouble(TBCostodiario.Text);

                Hotel unHotel = LogicaHotel.Buscar(TBNombre.Text);

                if (unHotel == null)
                {
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "El Hotel ingresado no existe en la base de datos";
                }
                else
                {
                    Habitacion unaHabitacion = new Habitacion(_Numero, unHotel, _Piso, _Descripcion, _Huespedes, _Costodiario);

                    LogicaHabitacion.Eliminar(unaHabitacion);
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "La Habitación ha sido eliminada correctamente.";
                    BloqueoCampos();
                    TBNombre.Enabled = true;
                    TBNumero.Enabled = true;
                    BtnModificar.Enabled = false;
                    BtnEliminar.Enabled = false;
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