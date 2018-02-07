using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaHabitacion
    {
        public static Habitacion Buscar(string Hotel, int Habitacion)
        {
            Habitacion H = null;

            H = PersistenciaHabitacion.Buscar(Hotel, Habitacion);

            return H;
        }
    }
}
