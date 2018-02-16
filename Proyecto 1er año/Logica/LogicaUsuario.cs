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
        public static Usuario Login(string pUsu, string pPass)
        {
            Usuario U = null;

            U = PersistenciaCliente.Login(pUsu, pPass);

            if (U == null)
            {
                U = PersistenciaAdministrador.Login(pUsu, pPass);
            }

            return U;
        }


        public static Usuario Buscar(string pUsu)
        {
            Usuario U = null;

            U = PersistenciaCliente.Buscar(pUsu);

            if (U == null)
            {
                U = PersistenciaAdministrador.Buscar(pUsu);
            }

            return U;
        }
    }
}