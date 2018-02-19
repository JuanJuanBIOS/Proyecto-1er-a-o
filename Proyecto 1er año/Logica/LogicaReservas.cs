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
    }
}
