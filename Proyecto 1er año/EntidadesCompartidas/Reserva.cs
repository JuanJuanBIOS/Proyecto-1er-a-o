using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Reserva
    {
        //Atributos
        private int _idreserva;
        private Cliente _cliente;
        private Habitacion _habitacion;
        private DateTime _fechaini;
        private DateTime _fechafin;
        private string _estado;

        //Propiedades
        public int idReserva
        {
            get
            {
                return _idreserva;
            }
            set
            {
                _idreserva = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                if (value != null)
                {
                    _cliente = value;
                }
                else
                {
                    throw new Exception("El cliente ingresado no es válido");
                }
            }
        }

        public Habitacion Habitacion
        {
            get
            {
                return _habitacion;
            }
            set
            {
                if (value != null)
                {
                    _habitacion = value;
                }
                else
                {
                    throw new Exception("La habitación ingresada no es válida");
                }
            }
        }

        public DateTime Fechaini
        {
            get
            {
                return _fechaini;
            }
            set
            {
               _fechaini = value;
            }
        }

        public DateTime Fechafin
        {
            get
            {
                return _fechafin;
            }
            set
            {
               _fechafin = value;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                if (value == "Activa" || value == "Finalizada" || value == "Cancelada")
                {
                    _estado = value;

                }
                else
                {
                    throw new Exception("El estado ingresado no es válido");
                }
            }
        }


       //Constructor
        public Reserva(int pidReserva, Cliente pCliente, Habitacion pHabitacion, DateTime pFechaini, DateTime pFechafin, string pEstado)
        {
            idReserva = pidReserva;
            Cliente = pCliente;
            Habitacion = pHabitacion;
            Fechaini = pFechaini;
            Fechafin = pFechafin;
            Estado = pEstado;
        }
    }
}
