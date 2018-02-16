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

        public static Administrador Buscar(string pUsu)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Buscar_Administrador", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", pUsu);

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

        public static void Crear(Administrador unA)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Crear_Administrador", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", unA.Nomusu);
            _Comando.Parameters.AddWithValue("@pass", unA.Pass);
            _Comando.Parameters.AddWithValue("@nombre", unA.Nombre);
            _Comando.Parameters.AddWithValue("@cargo", unA.Cargo);

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
                    throw new Exception("Ya existe el Administrador ingresado");
                }
                else if (_Afectados == -2)
                {
                    throw new Exception("Error al crear el usuario en la base de datos");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("Error al crear el administrador en la base de datos");
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
        }

        public static void Modificar(Administrador unA)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Modificar_Administrador", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", unA.Nomusu);
            _Comando.Parameters.AddWithValue("@pass", unA.Pass);
            _Comando.Parameters.AddWithValue("@nombre", unA.Nombre);
            _Comando.Parameters.AddWithValue("@cargo", unA.Cargo);

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
                    throw new Exception("El Administrador no existe en la base de datos");
                }

                else if (_Afectados == -2)
                {
                    throw new Exception("Error al actualizar el usuario en la base de datos");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("Error al actualizar el administrador en la base de datos");
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
        }

        public static void Eliminar(Administrador unA)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Eliminar_Administrador", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nomusu", unA.Nomusu);

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
                    throw new Exception("El Administrador no existe en la base de datos");
                }

                else if (_Afectados == -2)
                {
                    throw new Exception("Error al eliminar el administrador de la base de datos");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("Error al eliminar el usuario en la base de datos");
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
        }
    }
}
