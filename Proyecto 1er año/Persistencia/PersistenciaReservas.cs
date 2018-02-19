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
    public class PersistenciaReservas
    {
        public static List<Reserva> ReservasActivas()
        {
            List<Reserva> Activas = new List<Reserva>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Reservas_Activas ", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Cliente C = PersistenciaCliente.Buscar(_Reader["nomusu"].ToString());
                        Hotel Hot = PersistenciaHotel.Buscar(_Reader["hotel"].ToString());
                        Habitacion Hab = PersistenciaHabitacion.Buscar(Hot, Convert.ToInt32(_Reader["habitacion"]));
                        Reserva R = new Reserva(Convert.ToInt32(_Reader["idReserva"]), C, Hab, Convert.ToDateTime(_Reader["fechaini"]), Convert.ToDateTime(_Reader["fechafin"]), _Reader["estado"].ToString());
                        Activas.Add(R);
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

            return Activas;
        }
    }
}
