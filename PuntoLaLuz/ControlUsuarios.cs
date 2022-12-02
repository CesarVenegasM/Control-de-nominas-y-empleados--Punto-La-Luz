using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoLaLuz
{
    internal class ControlUsuarios
    {
        string sql;
        MySqlConnection conexion = ConexionSQL.getConexion();
        MySqlCommand cmd;
        MySqlDataReader reader;
        MenuAdmin ma = new MenuAdmin();

        public void UsuarioAltas(string nom, string fecha, string puesto, string sal)
        {
            Random random = new Random();

            int id = random.Next(1000, 9999);

            if (nom != "" && fecha != "" && puesto != "" && sal != "")
            {
                if (puesto == "Barra" || puesto == "Caja" || puesto == "Cocina")
                {
                    try
                    {
                        sql = "INSERT INTO colaboradores (id_colab, nom_colab, fecha_ingreso, puesto, salario) VALUES (@idcolab, @nombre, @fecha, @puesto, @salario)";
                        conexion.Open();
                        cmd = new MySqlCommand(sql, conexion);
                        cmd.Parameters.AddWithValue("@idcolab", Convert.ToInt16(id).ToString());
                        cmd.Parameters.AddWithValue("@nombre", nom);
                        cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha).ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@puesto", puesto);
                        cmd.Parameters.AddWithValue("@salario", double.Parse(sal).ToString());
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

        public void UsuarioBaja(string numB)
        {
            sql = "DELETE FROM colaboradores WHERE id_colab LIKE @idcolab";
            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idcolab", numB);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void UsuarioModificar(string numM, string nomM, string fechaM, string puestoM, string salM)
        {
            sql = "UPDATE colaboradores SET nom_colab=@nombre, fecha_ingreso=@fecha, puesto=@puesto, salario=@salario WHERE id_colab LIKE @idcolab";
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idcolab", numM);
            conexion.Open();

            if (numM != "" && fechaM != "" && puestoM != "" && salM != "" && nomM != "") 
            {
                if (puestoM == "Barra" || puestoM == "Caja" || puestoM == "Cocina")
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@nombre", nomM);
                        cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fechaM).ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@puesto", puestoM);
                        cmd.Parameters.AddWithValue("@salario", double.Parse(salM).ToString());
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
            conexion.Close();
        }       
    }
}
