using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaHotel
    {
        //creo metodo para buscar
        public static Hotel Buscar(string nombre)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Buscar_Hotel", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nombre", nombre);

            Hotel unHot = null;
            
            try
            {
                _Conexion.Open();
                SqlDataReader _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    _Reader.Read();

                    //Leo propiedades
                    string _nombre = (string)_Reader["nombre"];
                    string _calle = (string)_Reader["calle"];
                    string _numpuerta = (string)_Reader["numpuerta"];
                    string _ciudad = (string)_Reader["ciudad"];
                    string _telefono = (string)_Reader["telefono"];
                    string _fax = (string)_Reader["fax"];
                    bool _playa = (bool)_Reader["playa"];
                    bool _piscina = (bool)_Reader["piscina"];
                    string _estrellas = (string)_Reader["estrellas"];
                    string _foto = (string)_Reader["foto"];

                    unHot = new Hotel(_nombre, _calle, _numpuerta, _ciudad, _telefono, _fax, _playa, _piscina, _estrellas, _foto);

                    _Reader.Close();
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

            return unHot;
        }

        public static void Crear(Hotel unH)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Crear_Hotel", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nombre", unH.Nombre);
            _Comando.Parameters.AddWithValue("@calle", unH.Calle);
            _Comando.Parameters.AddWithValue("@numpuerta", unH.Numpuerta);
            _Comando.Parameters.AddWithValue("@ciudad", unH.Ciudad);
            _Comando.Parameters.AddWithValue("@telefono", unH.Telefono);
            _Comando.Parameters.AddWithValue("@fax", unH.Fax);
            _Comando.Parameters.AddWithValue("@playa", unH.Playa);
            _Comando.Parameters.AddWithValue("@piscina", unH.Piscina);
            _Comando.Parameters.AddWithValue("@estrellas", unH.Estrellas);
            _Comando.Parameters.AddWithValue("@foto", unH.Foto);

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
                    throw new Exception("Ya existe el Hotel con el nombre ingresado");
                }
                else if (_Afectados == -2)
                {
                    throw new Exception("Error en la base de datos");
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

        public static void Modificar(Hotel unH)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Modificar_Hotel", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nombre", unH.Nombre);
            _Comando.Parameters.AddWithValue("@calle", unH.Calle);
            _Comando.Parameters.AddWithValue("@numpuerta", unH.Numpuerta);
            _Comando.Parameters.AddWithValue("@ciudad", unH.Ciudad);
            _Comando.Parameters.AddWithValue("@telefono", unH.Telefono);
            _Comando.Parameters.AddWithValue("@fax", unH.Fax);
            _Comando.Parameters.AddWithValue("@playa", unH.Playa);
            _Comando.Parameters.AddWithValue("@piscina", unH.Piscina);
            _Comando.Parameters.AddWithValue("@estrellas", unH.Estrellas);
            _Comando.Parameters.AddWithValue("@foto", unH.Foto);

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
                    throw new Exception("El Hotel no existe en la base de datos");
                }
                
                else if (_Afectados == -2)
                {
                    throw new Exception("Error en la base de datos");
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

        public static void Eliminar(Hotel unH)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Eliminar_Hotel", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nombre", unH.Nombre);

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
                    throw new Exception("El Hotel no existe en la base de datos");
                }
                else if (_Afectados == -2)
                {
                    throw new Exception("Error al eliminar las reservas asociadas al hotel de la base de datos");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("Error al eliminar las habitaciones asociadas al hotel de la base de datos");
                }
                else if (_Afectados == -4)
                {
                    throw new Exception("Error al eliminar el hotel de la base de datos");
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
