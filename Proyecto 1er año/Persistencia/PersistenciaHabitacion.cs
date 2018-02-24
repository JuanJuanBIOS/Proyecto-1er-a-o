using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using System.Configuration;

namespace Persistencia
{
    public class PersistenciaHabitacion
    {
        public static Habitacion Buscar(Hotel pHotel, int pHabitacion)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Buscar_Habitacion", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@hotel", pHotel.Nombre);
            _Comando.Parameters.AddWithValue("@numero", pHabitacion);

            Habitacion unHab = null;

            try
            {
                _Conexion.Open();
                SqlDataReader _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    _Reader.Read();

                    //Leo propiedades
                    int _numero = (int)_Reader["numero"];
                    string _piso = (string)_Reader["piso"];
                    string _descripcion = (string)_Reader["descripcion"];
                    string _huespedes = (string)_Reader["huespedes"];
                    double _costodiario = (double)_Reader["costodiario"];

                    unHab = new Habitacion(_numero, pHotel, _piso, _descripcion, _huespedes, _costodiario);

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

            return unHab;
        }

        public static void Crear(Habitacion unaH)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Crear_Habitacion", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@numero", unaH.Numero);
            _Comando.Parameters.AddWithValue("@hotel", unaH.Hotel.Nombre);
            _Comando.Parameters.AddWithValue("@piso", unaH.Piso);
            _Comando.Parameters.AddWithValue("@descripcion", unaH.Descripcion);
            _Comando.Parameters.AddWithValue("@huespedes", unaH.Huespedes);
            _Comando.Parameters.AddWithValue("@costodiario", unaH.Costodiario);

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
                    throw new Exception("Ya existe la Habitación ingresada");
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

        public static void Modificar(Habitacion unaH)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Modificar_Habitacion", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@numero", unaH.Numero);
            _Comando.Parameters.AddWithValue("@hotel", unaH.Hotel.Nombre);
            _Comando.Parameters.AddWithValue("@piso", unaH.Piso);
            _Comando.Parameters.AddWithValue("@descripcion", unaH.Descripcion);
            _Comando.Parameters.AddWithValue("@huespedes", unaH.Huespedes);
            _Comando.Parameters.AddWithValue("@costodiario", unaH.Costodiario);

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
                    throw new Exception("La Habitación no existe en la base de datos");
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

        public static void Eliminar(Habitacion unaH)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Eliminar_Habitacion", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@numero", unaH.Numero);
            _Comando.Parameters.AddWithValue("@hotel", unaH.Hotel.Nombre);

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
                    throw new Exception("La Habitación no existe en la base de datos");
                }

                else if (_Afectados == -2)
                {
                    throw new Exception("Error al eliminar las reservas asociadas a la habitación");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("Error al eliminar la habitación");
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

        public static List<Habitacion> ListarHabitaciones(Hotel pHotel)
        {
            List<Habitacion> Habitaciones = new List<Habitacion>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Listar_Habitaciones", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@hotel", pHotel.Nombre);

            Habitacion unHab = null;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        int Num = Convert.ToInt32(_Reader["numero"]);
                        string Piso = _Reader["piso"].ToString();
                        string Desc = _Reader["descripcion"].ToString();
                        string Hues = _Reader["huespedes"].ToString();
                        double Costo = Convert.ToDouble(_Reader["costodiario"]);

                        Habitacion H = new Habitacion(Num, pHotel, Piso, Desc, Hues, Costo);
                        Habitaciones.Add(H);
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

            return Habitaciones;
        }
    }
}
