using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Habitacion
    {
        //Atributos
        private int _numero;
        private string _hotel;
        private int _piso;
        private string _descripcion;
        private int _huespedes;
        private double _costodiario;

        //Propiedades
        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                if (value > 0)
                {
                    _numero = value;
                }
                else
                {
                    throw new Exception("El número de habitación ingresado no es válido");
                }
            }
        }

        public string Hotel
        {
            get
            {
                return _hotel;
            }
            set
            {
                if (value.Length > 0)
                {
                    _hotel = value;
                }
                else
                {
                    throw new Exception("El hotel ingresado no es válido");
                }
            }
        }

        public int Piso
        {
            get
            {
                return _piso;
            }
            set
            {
                if (value > 0)
                {
                    _piso = value;
                }
                else
                {
                    throw new Exception("El número de piso ingresado no es válido");
                }
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                if (value.Length > 0)
                {
                    _descripcion = value; ;
                }
                else
                {
                    throw new Exception("La descripción ingresada no es válida");
                }
            }
        }

        public int Huespedes
        {
            get
            {
                return _huespedes;
            }
            set
            {
                if (value > 0)
                {
                    _huespedes = value;
                }
                else
                {
                    throw new Exception("El número de huéspedes ingresado no es válido");
                }
            }
        }

        public double Costodiario
        {
            get
            {
                return _costodiario;
            }
            set
            {
                if (value > 0)
                {
                    _costodiario = value;
                }
                else
                {
                    throw new Exception("El costo diario ingresado no es válido");
                }
            }
        }

       //Constructor
        public Habitacion(int pNumero, string pHotel, int pPiso, string pDescripcion, int pHuespedes, float pCostodiario)
        {
            Numero = pNumero;
            Hotel = pHotel;
            Piso = pPiso;
            Descripcion = pDescripcion;
            Huespedes = pHuespedes;
            Costodiario = pCostodiario;
        }
    }
}