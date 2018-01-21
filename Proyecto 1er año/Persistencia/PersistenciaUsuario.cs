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

                    unUsu = new EntidadesCompartidas.Usuario(_idusuario, _nomusu, _pass, _nombre, _tipo);
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
