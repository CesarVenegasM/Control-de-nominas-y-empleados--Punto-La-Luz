using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoLaLuz
{
    internal class ControlInventarios
    {
        string sql;
        MySqlConnection conexion = ConexionSQL.getConexion();
        MySqlCommand cmd;

        public void ModInventarios(string cantidad, string idPro)
        {
            if (cantidad != null && idPro != "...")
            {
                try
                {
                    sql = "UPDATE inventario SET cantidad=@cantidad WHERE id_inv=@idinv";
                    cmd = new MySqlCommand(sql, conexion);
                    conexion.Open();
                    cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt16(cantidad).ToString());
                    cmd.Parameters.AddWithValue("@idinv", Convert.ToInt16(idPro).ToString());
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Formato no valido. \nCorregir inmediatamente!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }              
            }
            else
            {
                MessageBox.Show("Espacios en blanco. \nCorregir inmediatamente!", "Espacios en blanco!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsInventarios(string elemento, string nomElem, string cantElem, string elem)
        {
            if (elemento != "" && nomElem != "" && cantElem != "" && elem != "") 
            {
                if(elem == "Baño" || elem == "Barra" || elem == "Cocina" || elem == "Limpieza general")
                {
                    try
                    {
                        sql = "INSERT INTO inventario (id_inv, nom_produc, cantidad, area) VALUES (@idinv, @nombre, @cantidad, @area)";
                        conexion.Open();
                        cmd = new MySqlCommand(sql, conexion);
                        cmd.Parameters.AddWithValue("@idinv", Convert.ToInt16(elemento).ToString());
                        cmd.Parameters.AddWithValue("@nombre", nomElem);
                        cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt16(cantElem).ToString());
                        cmd.Parameters.AddWithValue("@area", elem);
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Formato no valido. \nCorregir inmediatamente!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Inserte una area existente!", "Area no valida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Espacios en blanco. \nCorregir inmediatamente!", "Espacios en blanco!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
