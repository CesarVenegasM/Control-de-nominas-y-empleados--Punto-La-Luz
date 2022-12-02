using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoLaLuz
{
    public partial class Cajas : Form
    {
        public Cajas()
        {
            InitializeComponent();
        }


        string sql;
        MySqlConnection conexion = ConexionSQL.getConexion();
        MySqlCommand cmd;
        RadioButton productos;
        RadioButton tipos;
        CheckBox extras;


        List<string> Producto = new List<string>();
        List<string> Tipo = new List<string>();
        List<string> Extra = new List<string>();
        List<int> Precio = new List<int>();      

        string prod;
        string type;
        string ex;
        int cashP;
        int cashT;
        int cashE;

        #region Menús
        private void Cajas_Load(object sender, EventArgs e)
        {
            grp_punto.Hide();
            grp_barra.Hide();
            gbx_CornKitchen.Hide();
            gbx_Varios.Hide();

            L_Producto.DataSource = null;
            L_Tipo.DataSource = null;
            L_Extra.DataSource = null;
            L_Precio.DataSource = null;
        }

        private void menuBarra_Click(object sender, EventArgs e)
        {
            grp_punto.Hide();
            grp_barra.Show();
            gbx_CornKitchen.Hide();
            gbx_Varios.Hide();
            grp_barra.Location = new Point(28, 210);
            resetControl();
        }

        private void menuPunto_Click(object sender, EventArgs e)
        {
            grp_punto.Show();
            grp_barra.Hide();
            gbx_CornKitchen.Hide();
            gbx_Varios.Hide();
            grp_punto.Location = new Point(28, 210);
            resetControl();
        }

        private void manuCorn_Click(object sender, EventArgs e)
        {
            grp_punto.Hide();
            grp_barra.Hide();
            gbx_CornKitchen.Show();
            gbx_Varios.Hide();
            gbx_CornKitchen.Location = new Point(140, 210);
            resetControl();
        }

        private void manuVarios_Click(object sender, EventArgs e)
        {
            grp_punto.Hide();
            grp_barra.Hide();
            gbx_CornKitchen.Hide();
            gbx_Varios.Show();

            gbx_Varios.Location = new Point(220, 210);
            resetControl();
        }
        #endregion

        #region Selección de prodúctos
        private void radProductos(object sender, EventArgs e)
        {
            productos = sender as RadioButton;
            
            if (productos.Checked)
            {
                prod = productos.Text;
                sql = "select precio from productos where producto=@prod";
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@prod", productos.Text);
                cashP = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.Close();
            }
            else if (productos.Checked == false)
            {
                cashP = 0;
            }
        }

        private void radTipos(object sender, EventArgs e)
        {
            tipos = sender as RadioButton;
            if (tipos.Checked)
            {
                type = tipos.Text;

                sql = "select precio from productos where producto=@prod";
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@prod", tipos.Text);
                cashT = Convert.ToInt16(cmd.ExecuteScalar());
                conexion.Close();
            }
            else if (tipos.Checked == false)
            {
                cashT = 0;
                type = "";
            }
        }

        private void chExtras(object sender, EventArgs e)
        {
            extras = sender as CheckBox;
            if (extras.Checked && cashE == 0)
            {
                ex = extras.Text;

                sql = "select precio from productos where producto=@prod";
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@prod", extras.Text);

                cashE = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.Close();
            }
            else if (extras.Checked == false)
            {
                ex = "";
                cashE = 0;
            }
        }
        #endregion

        #region Botones
        private void btn_añadir_Click(object sender, EventArgs e)
        {
            if (cbx_extra.Checked && cbx_jarabe.Checked && cbx_leche.Checked)
            {
                ex = "Extra Shot + Jarabe + leche";
                cashE = 25;
            }
            else if (cbx_extra.Checked && cbx_jarabe.Checked)
            {
                ex = "Extra Shot + Jarabe";
                cashE = 10;
            }
            else if (cbx_jarabe.Checked && cbx_leche.Checked)
            {
                ex = " Jarabe + leche";
                cashE = 15;
            }
            else if (cbx_extra.Checked && cbx_leche.Checked)
            {
                ex = "Extra Shot + leche";
                cashE = 15;
            }

            if (prod != "" && type != "")
            {
                Producto.Add(prod);
                Tipo.Add(type);
                Extra.Add(ex);
                Precio.Add(cashE + cashP + cashT);

                L_Producto.DataSource = null;
                L_Tipo.DataSource = null;
                L_Extra.DataSource = null;
                L_Precio.DataSource = null;
                L_Producto.DataSource = Producto;
                L_Tipo.DataSource = Tipo;
                L_Extra.DataSource = Extra;
                L_Precio.DataSource = Precio;


                txt_total.Text = Precio.Sum().ToString();
            }
            else
            {
                MessageBox.Show("Debe escojer un prodúcto y un tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            resetControl();
        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            if (txt_total.Text != "") 
            {
                sql = "INSERT INTO ventas (fecha, producto, tipo, extra, precio) VALUES (@fecha, @produc, @tipo, @extra, @precio)";
                cmd = new MySqlCommand(sql, conexion);
                conexion.Open();
                for (int a = 0; a < Producto.Count; a++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@produc", Producto[a]);
                    cmd.Parameters.AddWithValue("@tipo", Tipo[a]);
                    cmd.Parameters.AddWithValue("@extra", Extra[a]);
                    cmd.Parameters.AddWithValue("@precio", Precio[a]);
                    cmd.ExecuteNonQuery();
                }

                conexion.Close();

                areadecajas imprimir = new areadecajas();
                imprimir.imprimirRecibo(piclogo1.Image, Producto, Tipo, Extra, Precio, Convert.ToInt16(txt_total.Text));

                Producto.Clear();
                Tipo.Clear();
                Extra.Clear();
                Precio.Clear();
            }
            else
            {
                MessageBox.Show("Debe escojer un prodúcto y un tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btn_reiniciar_Click(object sender, EventArgs e)
        {
            L_Producto.DataSource = null;
            L_Tipo.DataSource = null;
            L_Extra.DataSource = null;
            L_Precio.DataSource = null;
            Producto.Clear();
            Tipo.Clear();
            Extra.Clear();
            Precio.Clear();
            txt_total.Text = "";
        }
        #endregion

        #region Funcionalidades
        public void resetControl()
        {
            rad_ame.Checked = false;
            rad_afo.Checked = false;
            rad_band.Checked = false;
            rad_big.Checked = false;
            rad_cal.Checked = false;
            rad_dalg.Checked = false;
            rad_ent.Checked = false;
            rad_ente.Checked = false;
            rad_flame.Checked = false;
            rad_frio.Checked = false;
            rad_Glat.Checked = false;
            rad_lat.Checked = false;
            rad_nec.Checked = false;
            rad_papa.Checked = false;
            rad_shor.Checked = false;
            rad_singT.Checked = false;
            rad_tej.Checked = false;
            rad_tosti.Checked = false;
            rad_trad.Checked = false;
            rad_brow.Checked = false;
            cbx_exQue.Checked = false;
            cbx_extra.Checked = false;
            cbx_extraS.Checked = false;
            rad_gall.Checked = false;
            cbx_jarabe.Checked = false;
            cbx_leche.Checked = false;
            rad_pan.Checked = false;

            prod = "";
            type = "";
            ex = "";
            cashP = 0;
            cashT = 0;
            cashE = 0;

        }

        private void Cajas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
        #endregion
    }
}
