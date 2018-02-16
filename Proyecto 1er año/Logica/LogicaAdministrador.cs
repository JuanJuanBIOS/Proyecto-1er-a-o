using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaAdministrador
    {
        public static void Crear(Administrador Adm)
        {
            PersistenciaAdministrador.Crear(Adm);
        }

        public static void Modificar(Administrador Adm)
        {
            PersistenciaAdministrador.Modificar(Adm);
        }

        public static void Eliminar(Administrador Adm)
        {
            PersistenciaAdministrador.Eliminar(Adm);
        }
    }
}
