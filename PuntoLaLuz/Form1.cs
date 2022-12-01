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
using MySql.Data.MySqlClient;
using MySql.Debugger;

namespace PuntoLaLuz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = ConexionSQL.getConexion();
        MySqlDataReader reader;

        string sql = "SELECT user_admin, contr_admin FROM administradores WHERE user_admin LIKE @usuario";
        

        private void btn_log_Click(object sender, EventArgs e)
        {
            bool flag = true;

            if (txt_user.Text == "" || txt_passw.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@usuario", txt_user.Text);

                    reader = cmd.ExecuteReader();
                    reader.Read();

                    string contraseña = reader["contr_admin"].ToString();
                    if (txt_passw.Text == contraseña)
                    {
                        MenuAdmin perfil = new MenuAdmin();
                        flag = false;
                        perfil.Show();
                        reader.Close();
                        conexion.Close();
                    }                    
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Datos incorrectos", "Error de conxión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexion.Close();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
