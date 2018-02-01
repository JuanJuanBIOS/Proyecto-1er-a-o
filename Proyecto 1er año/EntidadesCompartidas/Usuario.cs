using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        //Atributos
        private string _nomusu;
        private string _pass;
        private string _nombre;

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

        public string Pass
        {
            get
            {
                return _pass;
            }
            set
            {
                if (value.Length > 0)
                {
                    _pass = value;
                }
                else
                {
                    throw new Exception("El password ingresado no es válido");
                }
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (value.Length > 0)
                {
                    _nombre = value; ;
                }
                else
                {
                    throw new Exception("El nombre ingresado no es válido");
                }
            }
        }
                

       //Constructor
        public Usuario(string pNomusu, string pPass, string pNombre)
        {
            Nomusu = pNomusu;
            Pass = pPass;
            Nombre = pNombre;
        }
    }
}
