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
        public static Habitacion Buscar(Hotel pHotel, int Habitacion)
        {
            Habitacion H = null;

            H = PersistenciaHabitacion.Buscar(pHotel, Habitacion);

            return H;
        }

        public static void Crear(Habitacion Hab)
        {
            PersistenciaHabitacion.Crear(Hab);
        }

        public static void Modificar(Habitacion Hab)
        {
            PersistenciaHabitacion.Modificar(Hab);
        }
    }
}
