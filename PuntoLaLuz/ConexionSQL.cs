using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoLaLuz
{
    internal class ConexionSQL
    {
        public static MySqlConnection getConexion()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "";
            string bd = "puntolaluz";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            return conexion;
        }
    }
}
