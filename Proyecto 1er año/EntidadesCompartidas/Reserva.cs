﻿using System;
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
        private Hotel _hotel;
        private DateTime _fechaini;
        private DateTime _fechafin;
        private Enums.Estado _estado;

        //Propiedades
        public int idReserva
        {
            get
            {
                return _idreserva;
            }
            set
            {
                if (value >= 0)
                {
                    _idreserva = value;
                }
                else
                {
                    throw new Exception("El idReserva ingresado no es válido");
                }
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
                _cliente = value;
            }
        }

        public Hotel Hotel
        {
            get
            {
                return _hotel;
            }
            set
            {
                _hotel = value;
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
                _habitacion = value;
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

        public Enums.Estado Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                if (value >= 0)
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
        public Reserva(int pidReserva, Cliente pCliente, Hotel pHotel, Habitacion pHabitacion, DateTime pFechaini, DateTime pFechafin, Enums.Estado pEstado)
        {
            idReserva = pidReserva;
            Cliente = pCliente;
            Hotel = pHotel;
            Habitacion = pHabitacion;
            Fechaini = pFechaini;
            Fechafin = pFechafin;
            Estado = pEstado;
        }
    }
}
