using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        //Atributos
        private string _nomusu;
        private string _tarjeta;
        private string _calle;
        private string _numpuerta;
        private string _ciudad;
        private string _telefono1;
        private string _telefono2;

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

        public string Calle
        {
            get
            {
                return _calle;
            }
            set
            {
                if (value.Length > 0)
                {
                    _calle = value;
                }
                else
                {
                    throw new Exception("El nombre de la calle ingresado no es válido");
                }
            }
        }

        public string Numpuerta
        {
            get
            {
                return _numpuerta;
            }
            set
            {
                if (Convert.ToInt16(value) >= 0 && value.Length <= 6)
                {
                    _numpuerta = value;
                }
                else
                {
                    throw new Exception("El número de puerta ingresado no es válido");
                }
            }
        }

        public string Ciudad
        {
            get
            {
                return _ciudad;
            }
            set
            {
                if (value.Length > 0)
                {
                    _ciudad = value;
                }
                else
                {
                    throw new Exception("La ciudad ingresada no es válida");
                }
            }
        }

        public string Telefono1
        {
            get
            {
                return _telefono1;
            }
            set
            {
                if (Convert.ToInt64(value) > 0 && value.Length > 7 && value.Length <= 15)
                {
                    _telefono1 = value;
                }
                else
                {
                    throw new Exception("El número de teléfono ingresado no es válido");
                }
            }
        }

        public string Telefono2
        {
            get
            {
                return _telefono2;
            }
            set
            {
                if (Convert.ToInt64(value) > 0 && value.Length > 7 && value.Length <= 15)
                {
                    _telefono2 = value;
                }
                else
                {
                    throw new Exception("El número de teléfono ingresado no es válido");
                }
            }
        }

       //Constructor
        public Cliente(string pNomusu, string pTarjeta, string pCalle, string pNumpuerta, string pCiudad, string pTelefono1, string pTelefono2)
        {
            Nomusu = pNomusu;
            Tarjeta = pTarjeta;
            Calle = pCalle;
            Numpuerta = pNumpuerta;
            Ciudad = pCiudad;
            Telefono1 = pTelefono1;
            Telefono2 = pTelefono2;
        }
    }
}
