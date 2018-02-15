using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;


namespace Persistencia
{
    public class PersistenciaAdministrador
    {
        public static Administrador Login(string pUsu, string pPass)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Login_Administrador", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", pUsu);
            _Comando.Parameters.AddWithValue("@pass", pPass);

            Administrador unAdm = null;

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
                    string _cargo = (string)_Reader["cargo"];

                    _Reader.Close();

                    unAdm = new Administrador(_nomusu, _pass, _nombre, _cargo);

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

            return unAdm;
        }
    }
}
