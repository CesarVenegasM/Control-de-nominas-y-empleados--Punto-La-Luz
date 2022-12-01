using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoLaLuz
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        string sql;
        MySqlConnection conexion = ConexionSQL.getConexion();
        Nominas nominas = new Nominas();
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader reader;

        int idinv;


        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            Bajas.Hide();
            Modificar.Hide();
            Altas.Hide();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Hide();
            dgv_ES.Hide();
            Ventas.Hide();

            Entradas_y_salidas es = new Entradas_y_salidas();
            es.Show();
            Cajas cajas = new Cajas();
            cajas.Show();
        }

        private void AltasMenu_Click(object sender, EventArgs e)
        {
            Bajas.Hide();
            Modificar.Hide();
            Altas.Show();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Hide();
            dgv_ES.Hide();
            Ventas.Hide();

            Altas.Location = new Point(100, 180);
            conexion.Open();
            sql = "SELECT * FROM colaboradores";
            RellenarDatagriv(sql);
            dtg_altas.DataSource = dt;
            conexion.Close();
        }

        private void btn_alta_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            int id = random.Next(1000, 9999);


            sql = "INSERT INTO colaboradores (id_colab, nom_colab, fecha_ingreso, puesto, salario) VALUES (@idcolab, @nombre, @fecha, @puesto, @salario)";
            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idcolab", id);
            cmd.Parameters.AddWithValue("@nombre", txt_nom.Text);
            cmd.Parameters.AddWithValue("@fecha", txt_fecha.Text);
            cmd.Parameters.AddWithValue("@puesto", cmb_puesto.Text);
            cmd.Parameters.AddWithValue("@salario", txt_sal.Text);
            cmd.ExecuteNonQuery();

            sql = "SELECT * FROM colaboradores";
            RellenarDatagriv(sql);
            dtg_altas.DataSource = dt;
            conexion.Close();
        }

        private void btn_limpiarA_Click(object sender, EventArgs e)
        {
            txt_nom.Text = "";
            txt_fecha.Text = "";
            cmb_puesto.Text = "";
            txt_sal.Text = "";
        }

        private void btn_regresarA_Click(object sender, EventArgs e)
        {
            Altas.Hide();
        }

        private void BajasMenu_Click(object sender, EventArgs e)
        {
            Bajas.Show();
            Modificar.Hide();
            Altas.Hide();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Hide();
            Ventas.Hide();
            dgv_ES.Hide();

            Bajas.Location = new Point(100, 180);
            conexion.Open();
            sql = "SELECT * FROM colaboradores";
            RellenarDatagriv(sql);
            dtg_bajas.DataSource = dt;
            conexion.Close();
        }
        private void btn_buscB_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM colaboradores WHERE id_colab LIKE @idcolab";
            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idcolab", txt_numB.Text);

            reader = cmd.ExecuteReader();
            reader.Read();

            txt_nomB.Text = reader["nom_colab"].ToString();
            txt_puestoB.Text = reader["puesto"].ToString();

            conexion.Close();
        }

        private void btn_baja_Click(object sender, EventArgs e)
        {
            sql = "DELETE FROM colaboradores WHERE id_colab LIKE @idcolab";
            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idcolab", txt_numB.Text);
            cmd.ExecuteNonQuery();


            sql = "SELECT * FROM colaboradores";
            RellenarDatagriv(sql);
            dtg_bajas.DataSource = dt;
            conexion.Close();
        }

        private void btn_limpiarB_Click(object sender, EventArgs e)
        {
            txt_nomB.Text = "";
            txt_numB.Text = "";
            txt_puestoB.Text = "";
        }

        private void btn_regresarB_Click(object sender, EventArgs e)
        {
            Bajas.Hide();
        }

        private void ModifcarMenu_Click(object sender, EventArgs e)
        {
            Bajas.Hide();
            Modificar.Show();
            Altas.Hide();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Hide();
            dgv_ES.Hide();
            Ventas.Hide();

            Modificar.Location = new Point(100, 180);
            sql = "SELECT * FROM colaboradores";
            conexion.Open();
            RellenarDatagriv(sql);
            dtg_modificar.DataSource = dt;

            conexion.Close();
        }

        private void btn_buscM_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM colaboradores WHERE id_colab LIKE @idcolab";

            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idcolab", txt_numM.Text);

            reader = cmd.ExecuteReader();
            reader.Read();

            txt_nomM.Text = reader["nom_colab"].ToString();
            DateTime fecha = Convert.ToDateTime(reader["fecha_ingreso"].ToString());
            txt_fechaM.Text = fecha.ToString("yyyy-MM-dd");
            cmb_puestoM.Text = reader["puesto"].ToString();
            txt_salM.Text = reader["salario"].ToString();

            conexion.Close();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            sql = "UPDATE colaboradores SET nom_colab=@nombre, fecha_ingreso=@fecha, puesto=@puesto, salario=@salario WHERE id_colab LIKE @idcolab";

            conexion.Open();

            cmd = new MySqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@idcolab", txt_numM.Text);
            cmd.Parameters.AddWithValue("@nombre", txt_nomM.Text);
            cmd.Parameters.AddWithValue("@fecha", txt_fechaM.Text);
            cmd.Parameters.AddWithValue("@puesto", cmb_puestoM.Text);
            cmd.Parameters.AddWithValue("@salario", txt_salM.Text);
            cmd.ExecuteNonQuery();

            sql = "SELECT * FROM colaboradores";
            RellenarDatagriv(sql);
            dtg_modificar.DataSource = dt;
            conexion.Close();
        }

        private void btn_limpiarM_Click(object sender, EventArgs e)
        {
            txt_nomM.Text = "";
            txt_fechaM.Text = "";
            cmb_puestoM.Text = "";
            txt_salM.Text = "";
        }

        private void btn_regresarM_Click(object sender, EventArgs e)
        {
            Modificar.Hide();
        }

        public void RellenarDatagriv(string sql)
        {
            cmd = new MySqlCommand(sql, conexion);
            da = new MySqlDataAdapter();
            dt = new DataTable();

            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            conexion.Close();
        }

        private void Entradas_Salidas_Click(object sender, EventArgs e)
        {
            Bajas.Hide();
            Modificar.Hide();
            Altas.Hide();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Hide();
            dgv_ES.Show();
            Ventas.Hide();

            dgv_ES.Location = new Point(100, 180);

            sql = "SELECT * FROM entradas_salidas";
            RellenarDatagriv(sql);
            dgv_ES.DataSource = dt;
        }

        private void NominasMenu_Click(object sender, EventArgs e)
        {

            Bajas.Hide();
            Modificar.Hide();
            Altas.Hide();
            Nominas.Show();
            Inventarios.Hide();
            AgregarElementos.Hide();
            dgv_ES.Hide();
            Ventas.Hide();

            Nominas.Location = new Point(100, 180);
        }

        private void btn_buscNOM_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM colaboradores WHERE id_colab LIKE @idcolab";
            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idcolab", txt_numNOM.Text);

            reader = cmd.ExecuteReader();
            reader.Read();

            lbl_nom.Text = reader["nom_colab"].ToString();

            lbl_fecha.Text = reader["fecha_ingreso"].ToString();

            lbl_puesto.Text = reader["puesto"].ToString();

            lbl_salxh.Text = reader["salario"].ToString();

            float salario = Single.Parse(reader["salario"].ToString());

            reader.Close();
            sql = "SELECT SUM(horasT) FROM entradas_salidas WHERE colab=@colab";
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@colab", txt_numNOM.Text);

            int horasT = Convert.ToInt16(cmd.ExecuteScalar().ToString());

            lbl_hrsT.Text = horasT.ToString();
            int horasE = horasT - 48;

            if (horasE < 0)
            {
                lbl_hrsE.Text = "0";
            }
            else
            {
                lbl_hrsE.Text = horasE.ToString();
            }

            lbl_info.Text = (100).ToString();

            lbl_salT.Text = ((salario * horasT) - 100).ToString();
        }

        private void AgregarElementosMenu_Click(object sender, EventArgs e)
        {
            Bajas.Hide();
            Modificar.Hide();
            Altas.Hide();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Show();
            dgv_ES.Hide();
            Ventas.Hide();

            AgregarElementos.Location = new Point(100, 180);
            conexion.Open();
            sql = "SELECT * FROM inventario";
            RellenarDatagriv(sql);
            dtg_AgreElem.DataSource = dt;
            conexion.Close();

        }

        private void ExaminarMenu_Click(object sender, EventArgs e)
        {
            Bajas.Hide();
            Modificar.Hide();
            Altas.Hide();
            Nominas.Hide();
            Inventarios.Show();
            AgregarElementos.Hide();
            dgv_ES.Hide();
            Ventas.Hide();

            Inventarios.Location = new Point(100, 180);

            conexion.Open();
            sql = "SELECT * FROM inventario";
            RellenarDatagriv(sql);
            dtg_inv.DataSource = dt;
            conexion.Close();
        }

        private void btn_añad_Click(object sender, EventArgs e)
        {
            sql = "INSERT INTO inventario (id_inv, nom_produc, cantidad, area) VALUES (@idinv, @nombre, @cantidad, @area)";
            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idinv", txt_elemento.Text);
            cmd.Parameters.AddWithValue("@nombre", txt_nomElem.Text);
            cmd.Parameters.AddWithValue("@cantidad", txt_cantElem.Text);
            cmd.Parameters.AddWithValue("@area", cmb_elem.Text);
            cmd.ExecuteNonQuery();

            sql = "SELECT * FROM inventario";
            RellenarDatagriv(sql);
            dtg_AgreElem.DataSource = dt;
            conexion.Close();
        }

        private void btn_limpiarElem_Click(object sender, EventArgs e)
        {
            txt_nomElem.Text = "";
            txt_elemento.Text = "";
            txt_cantElem.Text = "";
            cmb_elem.Text = "";
        }

        private void btn_regresarElem_Click(object sender, EventArgs e)
        {
            AgregarElementos.Hide();
        }

        private void btn_buscElemen_Click(object sender, EventArgs e)
        {

            sql = "SELECT * FROM inventario WHERE area LIKE @area";
            conexion.Open();
            cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@area", txt_numElem.Text);
            cmd.ExecuteNonQuery();


            dtg_AgreElem.DataSource = dt;
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);

            conexion.Close();
        }

        private void btn_guard_Click(object sender, EventArgs e)
        {
            sql = "UPDATE inventario SET cantidad=@cantidad WHERE id_inv=@idinv";
            cmd = new MySqlCommand(sql, conexion);
            conexion.Open();
            cmd.Parameters.AddWithValue("@cantidad", txt_cantidadP.Text);
            cmd.Parameters.AddWithValue("@idinv", lbl_idPro.Text);
            cmd.ExecuteNonQuery();

            sql = "SELECT * FROM inventario";
            cmd = new MySqlCommand(sql, conexion);
            dtg_AgreElem.DataSource = dt;
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            
            conexion.Close();
        }

        private void dtg_inv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int posicion = dtg_inv.CurrentRow.Index;
            lbl_idPro.Text = dtg_inv[0, posicion].Value.ToString();
            lbl_areaP.Text = dtg_inv[3, posicion].Value.ToString();
            lbl_pro.Text = dtg_inv[1, posicion].Value.ToString();
            txt_cantidadP.Text = dtg_inv[2, posicion].Value.ToString();
        }


        private void menuVentas_Click(object sender, EventArgs e)
        {
            Bajas.Hide();
            Modificar.Hide();
            Altas.Show();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Hide();
            dgv_ES.Hide();
            Ventas.Show();

            Ventas.Location = new Point(100, 180);
            
            conexion.Open();
            sql = "SELECT * FROM ventas";
            RellenarDatagriv(sql);
            dtg_ventas.DataSource = dt;
            conexion.Close();


            sql = "SELECT SUM(precio) FROM ventas WHERE fecha = @fecha";
            cmd = new MySqlCommand(sql, conexion);
            conexion.Open();
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));

            lbl_ventasD.Text = cmd.ExecuteScalar().ToString();

            sql = "SELECT SUM(precio) FROM ventas";
            cmd = new MySqlCommand(sql, conexion);            
            lbl_ventasT.Text = cmd.ExecuteScalar().ToString();
            conexion.Close();
        }

        private void btn_impNOM_Click(object sender, EventArgs e)
        {
            nominas.ImprimirNomina(piclogo.Image, lbl_nom.Text, lbl_fecha.Text, lbl_puesto.Text, lbl_salxh.Text, lbl_hrsT.Text, lbl_hrsE.Text, lbl_info.Text, lbl_salT.Text);
        }

        private void Nominas_Enter(object sender, EventArgs e)
        {

        }
    }
}
