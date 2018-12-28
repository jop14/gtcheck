using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;

namespace Checador
{
    public partial class busPag : Form
    {
        conexion datos = new conexion();
       
        public busPag()
        {
            InitializeComponent();
        }

        private void btn_bus_Click(object sender, EventArgs e)
        {
            //LLENAR DATAGRID
            Regex rex = new Regex(@"^[A-Z]{1}([0-9]{5})?$");

            if (txt_idbusc.Text == "")
            {
                try
                {
                    datos.consulta("SELECT Id_pag AS ESTACION, nombre AS NOMBRE  FROM pagina", "pagina");
                    this.dg_bus.DataSource = datos.ds.Tables["pagina"];
                    this.dg_bus.Refresh();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            else
            {
                if (rex.IsMatch(txt_idbusc.Text))
                {
                    try
                    {
                        SqlCeCommand cm = new SqlCeCommand("SELECT Id_pag AS ESTACION, nombre AS NOMBRE FROM pagina WHERE Id_pag = @id or nombre LIKE @nombre", datos.cn);
                        cm.Parameters.AddWithValue("@id", txt_idbusc.Text);
                        cm.Parameters.AddWithValue("@nombre", txt_idbusc.Text);
                        SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        this.dg_bus.DataSource = dt;
                        this.dg_bus.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        SqlCeCommand cm = new SqlCeCommand("SELECT Id_pag AS ESTACION, nombre AS NOMBRE FROM pagina WHERE  nombre LIKE  @nombre; ", datos.cn);
                        cm.Parameters.AddWithValue("@nombre", "%" + txt_idbusc.Text + "%");
                        SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        this.dg_bus.DataSource = dt;
                        this.dg_bus.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
        }

        private void dg_bus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            repPagina combo = Owner as repPagina;
            String id_est = this.dg_bus.CurrentRow.Cells["ESTACION"].Value.ToString();


            SqlCeCommand cm = new SqlCeCommand("SELECT *FROM pagina WHERE Id_pag = @id", datos.cn);
            cm.Parameters.AddWithValue("@id", id_est);
            SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cm.ExecuteReader();

            try
            {
               // ID = dt.Rows[0][0].ToString().Trim();
               // txt_nombre.Text = dt.Rows[0][1].ToString().Trim();
               combo.cb_id.Text = dt.Rows[0][0].ToString().Trim();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_idbusc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_bus.PerformClick();
            }
        }

        private void busPag_Load(object sender, EventArgs e)
        {
            
            datos.cn.Open();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
