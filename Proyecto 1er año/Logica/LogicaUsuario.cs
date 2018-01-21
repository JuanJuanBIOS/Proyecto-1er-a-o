using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class LogicaUsuario
    {
        public static EntidadesCompartidas.Usuario Login(string pUsu, string pPass)
        {
            return (Persistencia.PersistenciaUsuario.Login(pUsu, pPass));
        }
    }
}
