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
        private string _numpuerta;
        private string _ciudad;
        private string _telefono;
        private string _fax;
        private bool _playa;
        private bool _piscina;
        private string _estrellas;

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

        public string Numpuerta
        {
            get
            {
                return _numpuerta;
            }
            set
            {
                if (Convert.ToInt16(value) >= 0 &&  value.Length <= 6)
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

        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                if (Convert.ToInt64(value) > 0 && value.Length > 7 && value.Length <= 15)
                {
                    _telefono = value;
                }
                else
                {
                    throw new Exception("El número de teléfono ingresado no es válido");
                }
            }
        }

        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                if (Convert.ToInt64(value) > 0 && value.Length > 7 && value.Length <= 15)
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

        public bool Piscina
        {
            get
            {
                return _piscina;
            }
            set
            {
                _piscina = value;
            }
        }

        public string Estrellas
        {
            get
            {
                return _estrellas;
            }
            set
            {
                if (Convert.ToInt16(value) >= 1 && Convert.ToInt16(value) <= 5)
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
        public Hotel(string pNombre, string pCalle, string pNumpuerta, string pCiudad, string pTelefono, string pFax, bool pPlaya, bool pPiscina, string pEstrellas)
        {
            Nombre = pNombre;
            Calle = pCalle;
            Numpuerta = pNumpuerta;
            Ciudad = pCiudad;
            Telefono = pTelefono;
            Fax = pFax;
            Playa = pPlaya;
            Piscina = pPiscina;
            Estrellas = pEstrellas;
        }
    }
}
