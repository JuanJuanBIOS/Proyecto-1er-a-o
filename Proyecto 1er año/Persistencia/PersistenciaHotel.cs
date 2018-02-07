using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaHotel
    {
        //creo metodo para buscar
        public static Hotel Buscar(string nombre)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBHoteles"].ConnectionString;
            SqlConnection _Conexion = new SqlConnection(CS);
            SqlCommand _Comando = new SqlCommand("Buscar_Hotel", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@nombre", nombre);

            Hotel unHot = null;
            
            try
            {
                _Conexion.Open();

                SqlDataReader _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    _Reader.Read();

                    //Leo propiedades
                    string _nombre = (string)_Reader["nombre"];
                    string _calle = (string)_Reader["calle"];
                    string _numpuerta = (string)_Reader["numpuerta"];
                    string _ciudad = (string)_Reader["ciudad"];
                    string _telefono = (string)_Reader["telefono"];
                    string _fax = (string)_Reader["fax"];
                    bool _playa = (bool)_Reader["playa"];
                    bool _piscina = (bool)_Reader["piscina"];
                    string _estrellas = (string)_Reader["estrellas"];

                    unHot = new Hotel(_nombre, _calle, _numpuerta, _ciudad, _telefono, _fax, _playa, _piscina, _estrellas);

                    _Reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }

            return unHot;

        }

    }
}
