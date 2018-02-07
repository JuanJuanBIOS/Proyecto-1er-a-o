using System;
using System.Collections;
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
                    
                    string _nomusu = (string)_Reader["nomusu"];
                    string _pass = (string)_Reader["pass"];
                    string _nombre = (string)_Reader["nombre"];

                    int _tipo = (int)_Reader["tipo"];

                    if (_tipo == 1)
                    {
                        string _tarjeta = (string)_Reader["tarjeta"];
                        string _direccion = (string)_Reader["direccion"];

                        _Reader.Close();

                        SqlCommand _ComandoTel = new SqlCommand("Buscar_Telefonos", _Conexion);
                        _ComandoTel.CommandType = CommandType.StoredProcedure;
                        _ComandoTel.Parameters.AddWithValue("@nomusu", pUsu);
                        SqlDataReader _ReaderTel = _ComandoTel.ExecuteReader();

                        ArrayList _telefonos = new ArrayList();

                        while (_ReaderTel.Read())
                        { 
                            _telefonos.Add(_ReaderTel["telefono"]);
                        }

                        unUsu = new EntidadesCompartidas.Cliente(_nomusu, _pass, _nombre, _tarjeta, _direccion, _telefonos);

                        _ReaderTel.Close();
                    }
                    else if (_tipo == 2)
                    {
                        string _cargo = (string)_Reader["cargo"];
                        unUsu = new EntidadesCompartidas.Administrador(_nomusu, _pass, _nombre, _cargo);

                        _Reader.Close();
                    }
                }
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
