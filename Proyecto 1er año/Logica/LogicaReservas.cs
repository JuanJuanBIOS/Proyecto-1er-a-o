using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaReservas
    {
        public static List<Reserva> ReservasActivas()
        {
            List<Reserva> ReservasActivas = new List<Reserva>();

            ReservasActivas.AddRange(PersistenciaReservas.ReservasActivas());

            return ReservasActivas;
        }

        public static Reserva BuscarReserva(int idRes)
        {
            Reserva unaRes = PersistenciaReservas.BuscarReserva(idRes);
            return unaRes;
        }

        public static void ConfirmarReserva(Reserva Res)
        {
            PersistenciaReservas.ConfirmarReserva(Res);
        }

        public static List<Reserva> ReservasHabitacionTodas(Habitacion Hab)
        {
            List<Reserva> ReservasHabitacion = new List<Reserva>();

            ReservasHabitacion.AddRange(PersistenciaReservas.ReservasHabitacionTodas(Hab));

            return ReservasHabitacion;
        }

        public static List<Reserva> ReservasHabitacionActivas(Habitacion Hab)
        {
            List<Reserva> ReservasHabitacion = new List<Reserva>();

            ReservasHabitacion.AddRange(PersistenciaReservas.ReservasHabitacionActivas(Hab));

            return ReservasHabitacion;
        }

        public static List<Reserva> ReservasHabitacionFinalizadas(Habitacion Hab)
        {
            List<Reserva> ReservasHabitacion = new List<Reserva>();

            ReservasHabitacion.AddRange(PersistenciaReservas.ReservasHabitacionFinalizadas(Hab));

            return ReservasHabitacion;
        }

        public static List<Reserva> ReservasHabitacionCanceladas(Habitacion Hab)
        {
            List<Reserva> ReservasHabitacion = new List<Reserva>();

            ReservasHabitacion.AddRange(PersistenciaReservas.ReservasHabitacionCanceladas(Hab));

            return ReservasHabitacion;
        }
        
    }
}
