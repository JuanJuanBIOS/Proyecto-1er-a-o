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
        private Int64 _tarjeta;
        private string _calle;
        private int _numpuerta;
        private string _ciudad;
        private int _telefono1;
        private int _telefono2;

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

        public Int64 Tarjeta
        {
            get
            {
                return _tarjeta;
            }
            set
            {
                if (value >= 0 && value.ToString().Length == 16)
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

        public int Numpuerta
        {
            get
            {
                return _numpuerta;
            }
            set
            {
                if (value >= 0)
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

        public int Telefono1
        {
            get
            {
                return _telefono1;
            }
            set
            {
                if (value > 0 && value.ToString().Length > 7)
                {
                    _telefono1 = value;
                }
                else
                {
                    throw new Exception("El número de teléfono ingresado no es válido");
                }
            }
        }

        public int Telefono2
        {
            get
            {
                return _telefono2;
            }
            set
            {
                if (value > 0 && value.ToString().Length > 7)
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
        public Cliente(string pNomusu, Int32 pTarjeta, string pCalle, int pNumpuerta, string pCiudad, int pTelefono1, int pTelefono2)
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
