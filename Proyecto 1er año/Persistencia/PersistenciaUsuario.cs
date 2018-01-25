using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static EntidadesCompartidas.Usuario Login(string pUsu, string pPass)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBHoteles"].ConnectionString;
            SqlConnection _Conexion = new SqlConnection(CS);
            SqlCommand _Comando = new SqlCommand("Login_Usuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", pUsu);
            _Comando.Parameters.AddWithValue("@pass", pPass);

            EntidadesCompartidas.Usuario unUsu = null;
            
            try
            {
                _Conexion.Open();

                SqlDataReader _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    _Reader.Read();
                    int _idusuario = (int)_Reader["idUsuario"];
                    string _nomusu = (string)_Reader["nomusu"];
                    string _pass = (string)_Reader["pass"];
                    string _nombre = (string)_Reader["nombre"];
                    int _tipo = (int)_Reader["tipo"];
                    

                    if (_tipo == (int)EntidadesCompartidas.Enums.Tipo_Usuario.Cliente)
                    {
                        string _tarjeta = (string)_Reader["tarjeta"];
                        string _calle = (string)_Reader["calle"];
                        string _numpuerta = (string)_Reader["numpuerta"];
                        string _ciudad = (string)_Reader["ciudad"];
                        string _telefono1 = Convert.ToString(11111111);
                        string _telefono2 = Convert.ToString(22222222);


                        EntidadesCompartidas.Cliente unCli = null;
                        unCli = new EntidadesCompartidas.Cliente(_idusuario, _nomusu, _pass, _nombre, _tipo, _tarjeta, _calle, 
                                    _numpuerta, _ciudad, _telefono1, _telefono2);
                        unUsu = (EntidadesCompartidas.Usuario)unCli;
                    }
                    else if (_tipo == (int)EntidadesCompartidas.Enums.Tipo_Usuario.Administrador)
                    {
                        int _cargo = (int)_Reader["cargo"];
                        EntidadesCompartidas.Administrador unAdm = null;
                        unAdm = new EntidadesCompartidas.Administrador(_idusuario, _nomusu, _pass, _nombre, _tipo, _cargo);
                        unUsu = (EntidadesCompartidas.Usuario)unAdm;
                    }

                }

                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }

            return unUsu;
        }
    }
}
