using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaCliente
    {
        public static void Crear(Cliente Cli)
        {
            PersistenciaCliente.Crear(Cli);
        }

    }
}
