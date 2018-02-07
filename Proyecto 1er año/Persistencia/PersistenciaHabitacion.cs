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
        public static PersistenciaHabitacion Buscar(string pHotel, int pHabitacion)
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

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            Habitacion Hab = null;

            try
            {
                _Conexion.Open();
                SqlDataReader _Reader = _Comando.ExecuteReader();

                int _Error = (int)_Reader["@Retorno"];

                if (_Error == -1)
                {
                    throw new Exception("El hotel ingresado no existe en la base de datos");
                }
                else if (_Error == -2)
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
        }
    }
}
