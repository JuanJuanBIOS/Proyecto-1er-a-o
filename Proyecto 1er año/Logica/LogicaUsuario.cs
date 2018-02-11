using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static EntidadesCompartidas.Usuario Login(string pUsu, string pPass)
        {
            Usuario U = null;

            U = 
            return (Persistencia.PersistenciaUsuario.Login(pUsu, pPass));
        }
    }
}
