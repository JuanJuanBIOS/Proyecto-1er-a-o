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

        public static Cliente Buscar(string pUsu)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Buscar_Cliente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", pUsu);

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

        public static void Crear(Cliente unC)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Crear_Cliente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", unC.Nomusu);
            _Comando.Parameters.AddWithValue("@pass", unC.Pass);
            _Comando.Parameters.AddWithValue("@nombre", unC.Nombre);
            _Comando.Parameters.AddWithValue("@tarjeta", unC.Tarjeta);
            _Comando.Parameters.AddWithValue("@direccion", unC.Direccion);


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("Ya existe el usuario  en la base de datos");
                }
                else if (_Afectados == -2)
                {
                    throw new Exception("Error al crear el cliente en la base de datos");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("La tarjeta de crédito ya es utilizada por otro usuario");
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

            /*
            //Guardo telefonos
            SqlConnection _ConexionTel = new SqlConnection(Conexion.STR);
            SqlCommand _ComandoTel = new SqlCommand("Crear_Teléfono", _Conexion);
            _ComandoTel.CommandType = CommandType.StoredProcedure;

            //TENGO QUE RECORRER EL ARRAYLIST 

            _ComandoTel.Parameters.AddWithValue("@nomusu", unC.Nomusu);
            
            _ComandoTel.Parameters.AddWithValue("@telefono", unC.Telefonos);
            
            SqlParameter _RetornoTel = new SqlParameter("@Retorno", SqlDbType.Int);
            _RetornoTel.Direction = ParameterDirection.ReturnValue;
            _ComandoTel.Parameters.Add(_Retorno);

            try
            {
                _ConexionTel.Open();
                _ComandoTel.ExecuteNonQuery();

                int _Afectados = (int)_ComandoTel.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("Ya existe el usuario ingresado, intente con otro nombre de usuario");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("La tarjeta ya es utilizada en otro usuario");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _ConexionTel.Close();
            }
        }
        */
        }

    }
}
