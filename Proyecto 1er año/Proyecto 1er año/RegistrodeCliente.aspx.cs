using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using EntidadesCompartidas;
using Logica;

namespace Proyecto_1er_año
{
    public partial class RegistrodeCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TBNombre.Focus();
                ArrayList Telefonos = new ArrayList();

                Session["Telefonos"] = Telefonos;
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _NomUsu = Convert.ToString(TBNomUsu.Text);
                string _Pass = Convert.ToString(TBPassword.Text);
                string _Pass2 = Convert.ToString(TBPassword2.Text);
                string _Direccion = Convert.ToString(TBDireccion.Text);
                string _Tarjeta = Convert.ToString(TBTarjeta.Text);
                ArrayList _Telefonos = (ArrayList)Session["Telefonos"];

                if (_Pass != _Pass2)
                {
                    throw new Exception("Los contraseñas no coinciden");
                }

                if (_Telefonos.Count == 0)
                {
                    throw new Exception("Ingrese al menos un número de teléfono");
                }

                Cliente unCli = new Cliente(_NomUsu, _Pass, _Nombre, _Tarjeta, _Direccion, _Telefonos);
                LogicaCliente.Crear(unCli);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Cliente ha sido ingresado a la base de datos correctamente.";
                TBNombre.Enabled = false;
                TBNomUsu.Enabled = false;
                TBPassword.Enabled = false;
                TBPassword2.Enabled = false;
                TBDireccion.Enabled = false;
                TBTarjeta.Enabled = false;
                TBTelefono.Enabled = false;
                LBTelefonos.Enabled = false;
                BtnRegistrar.Enabled = false;
                BtnOk.Visible = true;
            }

            catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (TBTelefono.Text != "")
            {
                if (!((ArrayList)Session["Telefonos"]).Contains(TBTelefono.Text))
                {
                    ((ArrayList)Session["Telefonos"]).Add(TBTelefono.Text);
                    LBTelefonos.DataSource = (ArrayList)Session["Telefonos"];
                    LBTelefonos.DataBind();
                }
                TBTelefono.Text = "";
            }
        }

        protected void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (LBTelefonos.SelectedItem != null)
            {
                ((ArrayList)Session["Telefonos"]).Remove(LBTelefonos.SelectedItem.ToString());
                LBTelefonos.DataSource = (ArrayList)Session["Telefonos"];
                LBTelefonos.DataBind();
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }


    }
}