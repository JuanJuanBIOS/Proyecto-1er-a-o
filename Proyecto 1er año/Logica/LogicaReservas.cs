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

        public static void Consultar_Reserva(Reserva Res)
        {
            PersistenciaReservas.Consultar_Reserva(Res);
        }

        public static void Realizar_Reserva(Reserva Res)
        {
            PersistenciaReservas.Realizar_Reserva(Res);
        }

        public static List<Reserva> ReservasActivasporUsuario(string nomUsu)
        {
            List<Reserva> ReservasActivasporUsuario = new List<Reserva>();

            ReservasActivasporUsuario.AddRange(PersistenciaReservas.ReservasActivasporUsuario(nomUsu));

            return ReservasActivasporUsuario;
        }

        public static void Cancelar_Reserva(Reserva Res)
        {
            PersistenciaReservas.Cancelar_Reserva(Res);
        }
    }
}
