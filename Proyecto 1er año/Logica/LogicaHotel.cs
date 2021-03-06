﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaHotel
    {

        public static Hotel Buscar(string nombre)
        {
            Hotel hot = PersistenciaHotel.Buscar(nombre);
            return hot;
        }

        public static void Crear(Hotel Hot)
        {
            PersistenciaHotel.Crear(Hot);
        }

        public static void Modificar(Hotel Hot)
        {
            PersistenciaHotel.Modificar(Hot);
        }

        public static void Eliminar(Hotel Hot)
        {
            PersistenciaHotel.Eliminar(Hot);
        }

        public static List<string> ListaHoteles()
        {
            List<string> listahoteles= PersistenciaHotel.ListaHoteles();
            return listahoteles;
        }

        public static List<Hotel> HotelesporCategoria(int Categoria)
        {
            List<Hotel> Hoteles = new List<Hotel>();

            Hoteles.AddRange(PersistenciaHotel.HotelesporCategoria(Categoria));

            return Hoteles;
        }
    }
}
