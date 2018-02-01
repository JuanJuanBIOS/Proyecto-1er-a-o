using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador : Usuario
    {
        //Atributos
        private Enums.Cargo _cargo;

        //Propiedades
        public Enums.Cargo Cargo
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
        public Administrador(string pNomusu, string pPass, string pNombre, Enums.Cargo pCargo)
            :base(pNomusu, pPass, pNombre)
        {
            Cargo = pCargo;
        }
    }
}
