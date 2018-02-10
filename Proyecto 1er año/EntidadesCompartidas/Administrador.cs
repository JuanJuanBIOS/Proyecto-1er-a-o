using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador : Usuario
    {
        //Atributos
        private string _cargo;

        //Propiedades
        public string Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                if (value.Length > 0)
                {
                    //controlar entre 2 o 3 cargos
                    _cargo = value;
                }
                else
                {
                    throw new Exception("El cargo ingresado no es válido");
                }
            }
        }

       //Constructor
        public Administrador(string pNomusu, string pPass, string pNombre, string pCargo)
            :base(pNomusu, pPass, pNombre)
        {
            Cargo = pCargo;
        }
    }
}
