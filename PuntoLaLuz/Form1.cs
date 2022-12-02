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

        //Declarando variables a utilizar
        static string usuario, contraseña;

        static MySqlConnection conexion = ConexionSQL.getConexion();
        static MySqlDataReader reader;
        static bool flag = false;

        static string sql = "SELECT user_admin, contr_admin FROM administradores WHERE user_admin LIKE @usuario";

        public interface INest
        {
            void Access();
        }

        //Clase de seguridad para el login
        public class SecureNestProxy : INest
        {
            private INest nest;           

            public SecureNestProxy()
            {
                nest = new RealNest();
            }
            public void Access()
            {
                if (usuario == "" || contraseña == "")
                {
                    MessageBox.Show("Debe llenar todos los campos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        //Validación del usuario y contraseña
                        conexion.Open();
                        MySqlCommand cmd = new MySqlCommand(sql, conexion);
                        cmd.Parameters.AddWithValue("@usuario", usuario);

                        reader = cmd.ExecuteReader();
                        reader.Read();

                        string passsword = reader["contr_admin"].ToString();
                        if (contraseña == passsword)
                        {
                            MenuAdmin perfil = new MenuAdmin();
                            perfil.Show();
                            Cajas cajas = new Cajas();
                            cajas.Show();
                            reader.Close();
                            conexion.Close();
                            flag = true;
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos", "Error de conxión", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        //Clase de acceso para el login
        public class RealNest : INest
        {
            public void Access()
            {
                MessageBox.Show("Credenciales ingresadas validas", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }
        }

        //Ejecución de todo el login
        private void btn_log_Click(object sender, EventArgs e)
        {
            usuario = txt_user.Text;
            contraseña = txt_passw.Text;

            SecureNestProxy ss = new SecureNestProxy();            
            ss.Access();

            if (flag == true) { this.Hide(); }
        }
    }
}
