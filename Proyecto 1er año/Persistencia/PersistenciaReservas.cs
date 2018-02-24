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

        public static Reserva BuscarReserva(int unidRes)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Buscar_Reserva", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@idReserva", unidRes);

            Reserva unaRes = null;

            try
            {
                _Conexion.Open();
                SqlDataReader _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    _Reader.Read();

                    Cliente C = PersistenciaCliente.Buscar(_Reader["nomusu"].ToString());
                    Hotel Hot = PersistenciaHotel.Buscar(_Reader["hotel"].ToString());
                    Habitacion Hab = PersistenciaHabitacion.Buscar(Hot, Convert.ToInt32(_Reader["habitacion"]));
                    
                    unaRes = new Reserva(Convert.ToInt32(_Reader["idReserva"]), C, Hab, Convert.ToDateTime(_Reader["fechaini"]), Convert.ToDateTime(_Reader["fechafin"]), _Reader["estado"].ToString());

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

            return unaRes;
        }

        public static void ConfirmarReserva(Reserva unaR)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Confirmar_uso_reserva", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@idReserva", unaR.idReserva);

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
                    throw new Exception("La reserva no se encuentra en la base de datos");
                }
                else if (_Afectados == -2)
                {
                    throw new Exception("La reserva seleccionada figura como 'cancelada' en la base de datos");
                }
                else if (_Afectados == -3)
                {
                    throw new Exception("La reserva seleccionada figura como 'finalizada' en la base de datos");
                }
                else if (_Afectados == -4)
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

        public static List<Reserva> ReservasHabitacion(Habitacion unaHab)
        {
            List<Reserva> ReservasHabitacion = new List<Reserva>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Reservas_Habitacion", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@hotel", unaHab.Hotel.Nombre);
            _Comando.Parameters.AddWithValue("@habitacion", unaHab.Numero);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Cliente C = PersistenciaCliente.Buscar(_Reader["nomusu"].ToString());
                        Reserva R = new Reserva(Convert.ToInt32(_Reader["idReserva"]), C, unaHab, Convert.ToDateTime(_Reader["fechaini"]), Convert.ToDateTime(_Reader["fechafin"]), _Reader["estado"].ToString());
                        ReservasHabitacion.Add(R);
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

            return ReservasHabitacion;
        }
    }
}
