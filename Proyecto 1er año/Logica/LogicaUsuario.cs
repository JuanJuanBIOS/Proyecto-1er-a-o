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

            U = PersistenciaCliente.Login(pUsu, pPass);

            if (U == null)
            {
               U = PersistenciaAdministrador.Login(pUsu, pPass);
            }

            return U;
        }
    }
}
