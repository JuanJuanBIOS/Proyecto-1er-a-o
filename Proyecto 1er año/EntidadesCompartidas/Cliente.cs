using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : Usuario
    {
        //Atributos
        private string _tarjeta;
        private string _direccion;
        private ArrayList _telefonos = new ArrayList();

        //Propiedades
        public string Tarjeta
        {
            get
            {
                return _tarjeta;
            }
            set
            {
                if (Convert.ToInt64(value) >= 0 && value.Length == 16)
                {
                    _tarjeta = value;
                }
                else
                {
                    throw new Exception("El número de tarjeta ingresado no es válido");
                }
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                if (value.Length > 0)
                {
                    _direccion = value;
                }
                else
                {
                    throw new Exception("La dirección ingresada no es válida");
                }
            }
        }

        public ArrayList Telefonos
        {
            get
            {
                return _telefonos;
            }
            set
            {
                foreach (string telefono in Telefonos)
                {
                    if (Convert.ToInt64(telefono) > 0 && telefono.Length > 7 && telefono.Length <= 15)
                    {
                        _telefonos.Add(telefono);
                    }
                    else
                    {
                        throw new Exception("El número de teléfono ingresado no es válido");
                    }
                }

                _telefonos = value;
            }
        }


       //Constructor
        public Cliente(string pNomusu, string pPass, string pNombre, string pTarjeta, string pDireccion, ArrayList pTelefonos)
            :base(pNomusu, pPass, pNombre)
        {
            Tarjeta = pTarjeta;
            Direccion = pDireccion;
            Telefonos = pTelefonos;
        }
    }
}
