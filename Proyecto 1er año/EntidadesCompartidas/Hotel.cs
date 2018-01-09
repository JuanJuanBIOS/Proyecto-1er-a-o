using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Hotel
    {
        //Atributos
        private string _nombre;
        private string _calle;
        private int _numpuerta;
        private string _ciudad;
        private int _telefono;
        private int _fax;
        private bool _playa;
        private int _estrellas;

        //Propiedades
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
                    _nombre = value;
                }
                else
                {
                    throw new Exception("El nombre ingresado no es válido");
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

        public int Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                if (value > 0 && value.ToString().Length > 7)
                {
                    _telefono = value;
                }
                else
                {
                    throw new Exception("El número de teléfono ingresado no es válido");
                }
            }
        }

        public int Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                if (value > 0 && value.ToString().Length > 7)
                {
                    _fax = value;
                }
                else
                {
                    throw new Exception("El número de fax ingresado no es válido");
                }
            }
        }

        public bool Playa
        {
            get
            {
                return _playa;
            }
            set
            {
                _playa = value;
            }
        }

        public int Estrellas
        {
            get
            {
                return _estrellas;
            }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _estrellas = value;
                }
                else
                {
                    throw new Exception("El número de estrellas ingresado no es válido");
                }
            }
        }

        

       //Constructor
        public Hotel(string pNombre, string pCalle, int pNumpuerta, string pCiudad, int pTelefono, int pFax, bool pPlaya, int pEstrellas)
        {
            Nombre = pNombre;
            Calle = pCalle;
            Numpuerta = pNumpuerta;
            Ciudad = pCiudad;
            Telefono = pTelefono;
            Fax = pFax;
            Playa = pPlaya;
            Estrellas = pEstrellas;
        }
    }
}
