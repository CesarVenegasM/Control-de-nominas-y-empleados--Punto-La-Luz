using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoLaLuz
{
    public partial class Entradas_y_salidas : Form
    {
        public Entradas_y_salidas()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = ConexionSQL.getConexion();
        MySqlCommand cmd;
        MySqlDataReader reader;
        string sql;
        string date;

        private void btn_entrada_Click(object sender, EventArgs e)
        {
            sql = "SELECT id_colab FROM colaboradores WHERE id_colab = @colab";
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
            conexion.Open();

            if (cmd.ExecuteScalar() != null) 
            {
                sql = "SELECT colab FROM entradas_salidas WHERE colab = @colab";
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);

                if (cmd.ExecuteScalar() == null || date != DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    sql = "INSERT INTO entradas_salidas (fecha_es, entrada, colab) VALUES (@fecha, @entrada, @colab)";
                    cmd = new MySqlCommand(sql, conexion);

                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@entrada", DateTime.Now.ToString("hh:mm:ss"));
                    cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
                    cmd.ExecuteNonQuery();


                    sql = "SELECT fecha_es FROM entradas_salidas WHERE colab = @colab AND fecha_es = @fecha";
                    cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                    reader = cmd.ExecuteReader();
                    reader.Read();

                     
                    date = Convert.ToDateTime(reader["fecha_es"]).ToString("yyyy-MM-dd");
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("La entrada ya fue registrada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("numero de empleado \nno registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }            
        }

        private void btn_salida_Click(object sender, EventArgs e)
        {
            sql = "SELECT colab, fecha_es FROM entradas_salidas WHERE colab = @colab AND fecha_es = @fecha";
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
            conexion.Open();

            if (cmd.ExecuteScalar() != null)
            {
                sql = "SELECT salida FROM entradas_salidas WHERE colab = @colab AND fecha_es = @fecha";
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                
                if (cmd.ExecuteScalar().ToString() == "00:00:00")
                {
                    sql = "UPDATE entradas_salidas SET salida = @salida WHERE colab = @colab AND fecha_es = @fecha";
                    cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@salida", DateTime.Now.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                    

                    sql = "SELECT entrada FROM entradas_salidas WHERE colab = @colab AND fecha_es = @fecha";
                    cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));

                    DateTime entrada = DateTime.Parse(cmd.ExecuteScalar().ToString());

                    sql = "SELECT salida FROM entradas_salidas WHERE colab = @colab AND fecha_es = @fecha";
                    cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));

                    DateTime salida = DateTime.Parse(cmd.ExecuteScalar().ToString());

                    int horast = Convert.ToUInt16(salida.Subtract(entrada).TotalHours);

                    sql = "UPDATE entradas_salidas SET horasT = @horasT WHERE colab = @colab AND fecha_es = @fecha";
                    cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@horasT", horast.ToString());
                    cmd.Parameters.AddWithValue("@colab", txt_asistencia.Text);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("La salida ya fue registrada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("numero de empleado \nno registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }            
        }
    }
}
