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
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string _NomUsu = Convert.ToString(TBNomUsu.Text);
                string _Nombre = Convert.ToString(TBNombre.Text);
                string _Pass = Convert.ToString(TBPassword.Text);
                string _Pass2 = Convert.ToString(TBPassword2.Text);
                string _Direccion = Convert.ToString(TBDireccion.Text);
                string _Tarjeta = Convert.ToString(TBTarjeta.Text);
                ArrayList _Telefonos = new ArrayList();
                _Telefonos.AddRange(LBTelefonos.Items);

                if (_Pass != _Pass2)
                {
                    throw new Exception("Los passwords no coinciden, ingrese nuevament un password");
                }

                if (_Telefonos.Count ==0 )
                {
                    throw new Exception("Ingrese al menos un número de teléfono");
                }


                Cliente unCli = new Cliente(_NomUsu, _Pass, _Nombre, _Tarjeta, _Direccion, _Telefonos);
                LogicaCliente.Crear(unCli);
                LblError.ForeColor = System.Drawing.Color.Blue;
                LblError.Text = "El Cliente ha sido ingresado a la base de datos correctamente.";
            }

             catch (Exception ex)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = ex.Message;
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Agrego telefono ingresato en ListBox
            string _Telefono = Convert.ToString(TBTelefono.Text);
            if (_Telefono != "")
            {
                LBTelefonos.Items.Add(_Telefono);
                TBTelefono.Text = "";
            }


        }

        protected void BtnQuitar_Click(object sender, EventArgs e)
        {
            //Borro el ultimo telefono ingresado
            if (LBTelefonos.Items.Count > 0)
            {
                LBTelefonos.Items.RemoveAt(LBTelefonos.Items.Count - 1);
            }
        }
    }
}