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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();
            TBNomUsu.Focus();
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
            TBNombre.Text = "";
            TBPass.Text = "";
            DDLCargo.SelectedIndex = 0;
            BloqueoCampos();
        }

        private void BloqueoCampos()
        {
            TBNombre.Enabled = false;
            TBPass.Enabled = false;
            DDLCargo.Enabled = false;
        }

        private void HabilitoCampos()
        {
            TBNombre.Enabled = true;
            TBPass.Enabled = true;
            DDLCargo.Enabled = true;
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
            TBNomUsu.Enabled = false;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string nomusu = TBNomUsu.Text;

            this.LimpioFormulario();

            try
            {
                Usuario Usu = LogicaUsuario.Buscar(nomusu);
                if (Usu == null)
                {
                    LblError.ForeColor = System.Drawing.Color.Red;
                    LblError.Text = "El Administrador ingresado no existe en la base de datos";
                    this.ActivoBotonesA();
                }
                else if (Usu is Cliente)
                {
                    LblError.ForeColor = System.Drawing.Color.Red;
                    LblError.Text = "El Usuario ingresado corresponde a un Cliente";
                }
                else
                {
                    Administrador Adm = (Administrador)Usu;
                    TBNombre.Text = Adm.Nombre;
                    TBPass.Text = Adm.Pass;
                    DDLCargo.SelectedValue = Adm.Cargo;
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
                string _NomUsu = Convert.ToString(TBNomUsu.Text);
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _Pass = Convert.ToString(TBPass.Text);
                string _Cargo = Convert.ToString(DDLCargo.SelectedValue);

                Administrador unAdministrador = new Administrador(_NomUsu, _Nombre, _Pass, _Cargo);

                LogicaAdministrador.Crear(unAdministrador);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Administrador ha sido ingresado a la base de datos correctamente.";
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

        protected void BtnConfirmarModificacion_Click(object sender, EventArgs e)
        {
            try
            {
                string _NomUsu = Convert.ToString(TBNomUsu.Text);
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _Pass = Convert.ToString(TBPass.Text);
                string _Cargo = Convert.ToString(DDLCargo.SelectedValue);

                Administrador unAdministrador = new Administrador(_NomUsu, _Nombre, _Pass, _Cargo);

                LogicaAdministrador.Modificar(unAdministrador);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Administrador ha sido modificado correctamente.";
                BloqueoCampos();
                TBNomUsu.Enabled = true;
                BtnConfirmarModificacion.Enabled = false;
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
                string _NomUsu = Convert.ToString(TBNomUsu.Text);
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _Pass = Convert.ToString(TBPass.Text);
                string _Cargo = Convert.ToString(DDLCargo.SelectedValue);

                Administrador unAdministrador = new Administrador(_NomUsu, _Pass, _Nombre, _Cargo);

                Administrador AdmLogueado = (Administrador)Session["Usuario"];

                if (unAdministrador.Nomusu == AdmLogueado.Nomusu)
                {
                    LblError.ForeColor = System.Drawing.Color.Red;
                    LblError.Text = "El Administrador logueado no se puede eliminar a sí mismo";
                }
                else
                {
                    LogicaAdministrador.Eliminar(unAdministrador);
                    LblError.ForeColor = System.Drawing.Color.Blue;
                    LblError.Text = "El Administrador ha sido eliminado correctamente.";
                    BloqueoCampos();
                    TBNomUsu.Enabled = true;
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