using iTextSharp.text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Parameters;
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
using System.Web;
using System.Windows.Forms;

namespace PuntoLaLuz
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        //Declaración de variables necesarias
        public static string nombre, fecha, salario, info, horas, horasE = "0", puesto, salT;

        public string nomb, puestob;
        string sql;
        MySqlConnection conexion = ConexionSQL.getConexion();
        Nominas nominas = new Nominas();        
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        MySqlDataReader reader;

        #region Funcionalidades
        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            OcultarObjetos();            
            Entradas_y_salidas es = new Entradas_y_salidas();
            es.Show();           
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

        //Método para seleccion de datos con indice del datagriv
        private void dtg_inv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int posicion = dtg_inv.CurrentRow.Index;
            lbl_idPro.Text = dtg_inv[0, posicion].Value.ToString();
            lbl_areaP.Text = dtg_inv[3, posicion].Value.ToString();
            lbl_pro.Text = dtg_inv[1, posicion].Value.ToString();
            txt_cantidadP.Text = dtg_inv[2, posicion].Value.ToString();
        }

        //Aquí se utiliza una parte del patrón fachada (OFF) y en cada despliegue del menú se encuentra la otra parte,
        public void OcultarObjetos()
        {
            Bajas.Hide();
            Modificar.Hide();
            Altas.Hide();
            Nominas.Hide();
            Inventarios.Hide();
            AgregarElementos.Hide();
            dgv_ES.Hide();
            Ventas.Hide();
        }

        private void MenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
        #endregion

        #region Control de usuarios
        private void AltasMenu_Click(object sender, EventArgs e)
        {
            OcultarObjetos();
            Altas.Show();

            Altas.Location = new Point(100, 180);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM colaboradores";
            RellenarDatagriv(sql);
            dtg_altas.DataSource = dt;
            conexion.Close();
        }

        private void btn_alta_Click(object sender, EventArgs e)
        {
            ControlUsuarios cu = new ControlUsuarios();
            cu.UsuarioAltas(txt_nom.Text, txt_fecha.Text, cmb_puesto.Text, txt_sal.Text);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
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
            OcultarObjetos();
            Bajas.Show();

            Bajas.Location = new Point(100, 180);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM colaboradores";
            RellenarDatagriv(sql);
            dtg_bajas.DataSource = dt;
            conexion.Close();
        }
        private void btn_buscB_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM colaboradores WHERE id_colab LIKE @idcolab";
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idcolab", txt_numB.Text);

                //Validando existencia del colaborador
                if (cmd.ExecuteScalar() != null)
                {
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    //Rellenando txtbox para la vista de datos
                    txt_nomB.Text = reader["nom_colab"].ToString();
                    txt_puestoB.Text = reader["puesto"].ToString();
                }
                else
                {
                    MessageBox.Show("Introduzca un número de empleado valido", "Colaborador invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato no valido. \nCorregir inmediatamente!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion.Close();
        }

        private void btn_baja_Click(object sender, EventArgs e)
        {
            ControlUsuarios cu = new ControlUsuarios();
            cu.UsuarioBaja(txt_numB.Text);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
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
            OcultarObjetos();
            Modificar.Show();
            Modificar.Location = new Point(100, 180);

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM colaboradores";
            conexion.Open();
            RellenarDatagriv(sql);
            dtg_modificar.DataSource = dt;
            conexion.Close();
        }

        private void btn_buscM_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM colaboradores WHERE id_colab LIKE @idcolab";
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idcolab", txt_numM.Text);

                //Validando existencia del colaborador
                if (cmd.ExecuteScalar() != null)
                {
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    //Rellenando txtbox para la actualización de datos
                    txt_nomM.Text = reader["nom_colab"].ToString();
                    DateTime fecha = Convert.ToDateTime(reader["fecha_ingreso"].ToString());
                    txt_fechaM.Text = fecha.ToString("yyyy-MM-dd");
                    cmb_puestoM.Text = reader["puesto"].ToString();
                    txt_salM.Text = reader["salario"].ToString();
                }
                else
                {
                    MessageBox.Show("Introduzca un número de empleado valido", "Colaborador invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato no valido. \nCorregir inmediatamente!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion.Close();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            ControlUsuarios cu = new ControlUsuarios();
            cu.UsuarioModificar(txt_numM.Text, txt_nomM.Text, txt_fechaM.Text, cmb_puestoM.Text, txt_salM.Text);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
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
        #endregion

        #region Entradas y salidas
        private void Entradas_Salidas_Click(object sender, EventArgs e)
        {
            OcultarObjetos();
            dgv_ES.Show(); ;
            dgv_ES.Location = new Point(100, 180);

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM entradas_salidas";
            RellenarDatagriv(sql);
            dgv_ES.DataSource = dt;
        }      

        #endregion 
        
        #region Nóminas
        private void NominasMenu_Click(object sender, EventArgs e)
        {
            OcultarObjetos();
            Nominas.Show();
            Nominas.Location = new Point(100, 180);
        }

        private void btn_buscNOM_Click(object sender, EventArgs e)
        {
            string n, f, s, i, h, hE, p;

            try
            {
                sql = "SELECT * FROM colaboradores WHERE id_colab LIKE @idcolab";
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idcolab", txt_numNOM.Text);

                //Validando existencia del colaborador
                if (cmd.ExecuteScalar() != null)
                {
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    //Guardando datos de consolta en variables estáticas
                    n = reader["nom_colab"].ToString();

                    f = reader["fecha_ingreso"].ToString();

                    p = reader["puesto"].ToString();

                    s = reader["salario"].ToString();

                    float salario1 = Single.Parse(reader["salario"].ToString());

                    reader.Close();
                    sql = "SELECT SUM(horasT) FROM entradas_salidas WHERE colab=@colab";
                    cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@colab", txt_numNOM.Text);

                    int horasTo = Convert.ToInt16(cmd.ExecuteScalar().ToString());

                    h = horasTo.ToString();

                    //Determinando horas extra
                    int horasEx = horasTo - 24;

                    if (horasEx < 0)
                    {
                        hE = "0";
                    }
                    else
                    {
                        hE = horasEx.ToString();
                    }

                    i = (100).ToString();

                    nominamont constr;
                    Ensamble nom = new Ensamble();

                    constr = new Colaborador();
                    nom.ensamble(constr, n, f, s, h, i, hE, p);
                    constr.Nomina.Despliegue();

                    //Asignando resultado del patron builder a lbls
                    lbl_nom.Text = nombre;
                    lbl_fecha.Text = fecha;
                    lbl_puesto.Text = puesto;
                    lbl_salxh.Text = salario;
                    lbl_hrsT.Text = horas;
                    lbl_hrsE.Text = horasE;
                    lbl_info.Text = info;
                    lbl_salT.Text = salT;
                }
                else
                {
                    MessageBox.Show("Introduzca un número de empleado valido", "Colaborador invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato no valido. \nCorregir inmediatamente!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion.Close();
        }

        private void btn_impNOM_Click(object sender, EventArgs e)
        {
            nominas.ImprimirNomina(piclogo.Image, lbl_nom.Text, lbl_fecha.Text, lbl_puesto.Text, lbl_salxh.Text, lbl_hrsT.Text, lbl_hrsE.Text, lbl_info.Text, lbl_salT.Text);
        }

        private void btn_regresarNOM_Click(object sender, EventArgs e)
        {
            Nominas.Hide();
        }
        #endregion

        #region Inventarios
        private void AgregarElementosMenu_Click(object sender, EventArgs e)
        {
            OcultarObjetos();
            AgregarElementos.Show();
            AgregarElementos.Location = new Point(100, 180);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM inventario";
            RellenarDatagriv(sql);
            dtg_AgreElem.DataSource = dt;
            conexion.Close();
        }

        private void ExaminarMenu_Click(object sender, EventArgs e)
        {
            OcultarObjetos();
            Inventarios.Show();
            Inventarios.Location = new Point(100, 180);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM inventario";
            RellenarDatagriv(sql);
            dtg_inv.DataSource = dt;
            conexion.Close();
        }

        private void btn_añad_Click(object sender, EventArgs e)
        {
            ControlInventarios ci = new ControlInventarios();
            ci.InsInventarios(txt_elemento.Text, txt_nomElem.Text, txt_cantElem.Text, cmb_elem.Text);

            //Actualizando informacion del datagriv correspondiente
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
            try
            {
                sql = "SELECT * FROM inventario WHERE area = @area";
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@area", txt_numEleme.Text);

                //Validando la existencia del area
                if (cmd.ExecuteScalar() != null)
                {
                    //Actualizando informacion del datagriv correspondiente
                    MessageBox.Show("Busqueda realizada con exito.", "Busqueda.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmd = new MySqlCommand(sql, conexion);
                    da = new MySqlDataAdapter();
                    dt = new DataTable();

                    cmd.Parameters.AddWithValue("@area", txt_numEleme.Text);
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    dtg_inv.DataSource = dt;
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("Introduzca un area existente", "Colaborador invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato no valido. \nCorregir inmediatamente!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }       

        private void btn_guard_Click(object sender, EventArgs e)
        {
            ControlInventarios ci = new ControlInventarios();
            ci.ModInventarios(txt_cantidadP.Text, lbl_idPro.Text);

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM inventario";
            RellenarDatagriv(sql);
            dtg_inv.DataSource = dt;
            conexion.Close();
        }

        private void btn_regresarInv_Click(object sender, EventArgs e)
        {
            Inventarios.Hide();
        }
        #endregion

        #region Ventas
        private void menuVentas_Click(object sender, EventArgs e)
        {
            OcultarObjetos();
            Ventas.Show();
            Ventas.Location = new Point(100, 180);
            conexion.Open();

            //Actualizando informacion del datagriv correspondiente
            sql = "SELECT * FROM ventas";
            RellenarDatagriv(sql);
            dtg_ventas.DataSource = dt;
            conexion.Close();

            //Realizando cálculo de ventas x dia
            sql = "SELECT SUM(precio) FROM ventas WHERE fecha = @fecha";
            cmd = new MySqlCommand(sql, conexion);
            conexion.Open();
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
            lbl_ventasD.Text = cmd.ExecuteScalar().ToString();

            //Realizando cálculo de ventas totales
            sql = "SELECT SUM(precio) FROM ventas";
            cmd = new MySqlCommand(sql, conexion);
            lbl_ventasT.Text = cmd.ExecuteScalar().ToString();
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ventas.Hide();
        }
        #endregion       

        #region patrón Builder
        
        //Clase donde se añaden todos los campos
        class Ensamble
        {
            public void ensamble(nominamont nominamont, string n, string f, string s, string h, string i, string hE, string p)
            {
                nominamont.añadirnombre(n);
                nominamont.añadirfecha(f);
                nominamont.añadirpuesto(p);
                nominamont.añadirsalario(s);
                nominamont.añadirhoras(h);
                nominamont.añadirinfo(i);
                nominamont.añadirhorasE(hE);
                nominamont.añadirsalT(s, h, hE);
            }
        }

        //Clase directora de builder
        class Nomina 
        {
            private string nominaType;
            private Dictionary<string, string> a = new Dictionary<string, string>();

            public Nomina(string nominaType)
            {
                this.nominaType = nominaType;
            }

            public string this[string key]
            {
                get { return a[key]; }
                set { a[key] = value; }
            }

            public void Despliegue()
            {

                nombre = a["nombre"];
                fecha = a["fecha"];
                puesto = a["puesto"];
                salario = a["salario"];
                horas = a["horas"];
                horasE = a["horasE"];
                info = a["info"];
                salT = a["salT"];               
            }
        }

        //Clase constructora
        abstract class nominamont
        {
            protected Nomina nomina;

            public Nomina Nomina
            {
                get { return nomina; }
            }

            public abstract void añadirnombre(string n);
            public abstract void añadirfecha(string f);
            public abstract void añadirpuesto(string p);
            public abstract void añadirsalario(string s);
            public abstract void añadirhoras(string h);
            public abstract void añadirhorasE(string hE);
            public abstract void añadirinfo(string inf);
            public abstract void añadirsalT(string s, string h, string hE);

        }

        //Clase constructora concreta (añade los datos al diccionario)
        class Colaborador : nominamont
        {
            public Colaborador()
            {
                nomina = new Nomina("Colaborador");
            }
            public override void añadirnombre(string n)
            {
                nomina["nombre"] = n;
            }
            public override void añadirfecha(string f)
            {
                nomina["fecha"] = f;
            }
            public override void añadirpuesto(string p)
            {
                nomina["puesto"] = p;
            }
            public override void añadirsalario(string s)
            {
                nomina["salario"] = s;
            }
            public override void añadirhoras(string h)
            {
                nomina["horas"] = h;
            }
            public override void añadirhorasE(string hE)
            {
                nomina["horasE"] = hE;
            }
            public override void añadirinfo(string i)
            {
                nomina["info"] = i;
            }
            public override void añadirsalT(string s, string h, string hE)
            {

                double resultado = (((double.Parse(s) * Convert.ToInt16(h)) - 100) + (Convert.ToInt16(hE) * ((double.Parse(s) * 2))));
                nomina["salT"] = resultado.ToString();
            }
        }

        #endregion;
    }
}
