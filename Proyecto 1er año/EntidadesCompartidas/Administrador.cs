using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador
    {
        //Atributos
        private int _idadministrador;
        private int _cargo;

        //Propiedades
        public int idAdministrador
        {
            get
            {
                return _idadministrador;
            }
            set
            {
                if (value >= 0)
                {
                    _idadministrador = value;
                }
                else
                {
                    throw new Exception("El idAdministrador ingresado no es válido");
                }
            }
        }
        
        public int Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                if (value > 0)
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
        public Administrador(int pidAdministrador, int pCargo)
        {
            idAdministrador = pidAdministrador;
            Cargo = pCargo;
        }
    }
}
