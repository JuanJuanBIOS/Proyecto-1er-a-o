using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaHotel
    {

        public static Hotel Buscar(string nombre)
        {
            Hotel hot = PersistenciaHotel.Buscar(nombre);
            return hot;
        }

    }
}
