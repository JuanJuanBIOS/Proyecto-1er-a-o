using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador
    {
        //Atributos
        private string _nomusu;
        private int _cargo;

        //Propiedades
        public string Nomusu
        {
            get
            {
                return _nomusu;
            }
            set
            {
                if (value.Length > 0)
                {
                    _nomusu = value;
                }
                else
                {
                    throw new Exception("El nombre de usuario ingresado no es válido");
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
        public Administrador(string pNomusu, int pCargo)
        {
            Nomusu = pNomusu;
            Cargo = pCargo;
        }
    }
}
