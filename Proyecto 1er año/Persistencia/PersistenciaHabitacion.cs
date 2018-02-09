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
        public static Habitacion Buscar(string pHotel, int pHabitacion)
        {
            Hotel Hot = null;
            try
            {
                Hot = PersistenciaHotel.Buscar(pHotel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string CS = ConfigurationManager.ConnectionStrings["DBHoteles"].ConnectionString;
            SqlConnection _Conexion = new SqlConnection(CS);
            SqlCommand _Comando = new SqlCommand("Buscar_Habitacion", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@hotel", Hot.Nombre);
            _Comando.Parameters.AddWithValue("@numero", pHabitacion);
            _Comando.Parameters.AddWithValue("@Retorno", 0);

            /*SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);*/

            Habitacion Hab = null;

            try
            {
                _Conexion.Open();
                SqlDataReader _Reader = _Comando.ExecuteReader();

                int _Retorno = (int)_Reader["@Retorno"];

                if (_Retorno == -1)
                {
                    throw new Exception("El hotel ingresado no existe en la base de datos");
                }
                else if (_Retorno == -2)
                {
                    throw new Exception("La habitación ingresada no existe en la base de datos");
                }
                else
                {
                    _Reader.Read();

                    string _Hotel = (string)_Reader["hotel"];
                    int _Habitacion = (int)_Reader["numero"];
                    string _Piso = (string)_Reader["piso"];
                    string _Descripcion = (string)_Reader["descripcion"];
                    string _Huespedes = (string)_Reader["huespedes"];
                    double _CostoDiario = (double)_Reader["costodiario"];

                    Hab = new Habitacion(_Habitacion, Hot, _Piso, _Descripcion, _Huespedes, _CostoDiario);
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

            return Hab;
        }

        public static void Crear(Hotel unH, Habitacion unaH)
        {



            string CS = ConfigurationManager.ConnectionStrings["DBHoteles"].ConnectionString;
            SqlConnection _Conexion = new SqlConnection(CS);
            SqlCommand _Comando = new SqlCommand("Crear_Habitacion", _Conexion);
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
            _Comando.Parameters.AddWithValue("@foto", "aaaaaaaaaaaa");

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
    }
}
