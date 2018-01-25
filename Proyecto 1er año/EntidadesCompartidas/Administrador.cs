using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador : Usuario
    {
        //Atributos
        private int _cargo;

        //Propiedades
        public int Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                if (value >= 0)
                {
                    _cargo = value;
                }
                else
                {
                    throw new Exception("El cargo ingresado no es válido");
                }
            }
        }

       //Constructor
        public Administrador(int pidUsuario, string pNomusu, string pPass, string pNombre, int pTipo, int pCargo)
            :base(pidUsuario, pNomusu, pPass, pNombre, pTipo)
        {
            Cargo = pCargo;
        }
    }
}
