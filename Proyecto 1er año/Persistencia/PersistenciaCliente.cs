using System;
using System.Collections;
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
    public class PersistenciaCliente
    {
        public static Cliente Login(string pUsu, string pPass)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Login_Cliente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", pUsu);
            _Comando.Parameters.AddWithValue("@pass", pPass);

            Cliente unCli = null;

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

                    unCli = new Cliente(_nomusu, _pass, _nombre, _tarjeta, _direccion, _telefonos);

                    _ReaderTel.Close();
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

            return unCli;
        }
    }
}
