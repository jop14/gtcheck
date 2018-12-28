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

namespace Checador
{
    public partial class editarEliminarCorreo : Form
    {
        conexion datos = new conexion();
        String id_est;
        public editarEliminarCorreo()
        {
            InitializeComponent();
        }

        private void editarEliminarCorreo_Load(object sender, EventArgs e)
        {
            datos.cn.Open();
            txt_ape.Enabled = false;
            txt_correo.Enabled = false;
            txt_nom.Enabled = false;
            txt_numTel.Enabled = false;
            txt_referencia.Enabled = false;
            gb_genero.Enabled = false;
            btn_actualizar.Enabled = false;
            btn_eliminar.Enabled = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btn_bus_Click(object sender, EventArgs e)
        {
            //LLENAR DATAGRID

            if (txt_idbusc.Text == "")
            {
                try
                {
                    datos.consulta("SELECT id_correo AS ID, nombre + ' ' + apellidos AS NOMBRE, correo AS CORREO FROM contacto", "contacto");
                    this.dg_bus.DataSource = datos.ds.Tables["contacto"];
                    this.dg_bus.Columns[0].Width = 50;
                    this.dg_bus.Refresh();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            else
            {
                if (txt_idbusc.TextLength > 0)
                {

                    try
                    {
                        SqlCeCommand cm = new SqlCeCommand("SELECT id_correo AS ID, nombre + ' ' + apellidos AS NOMBRE, correo AS CORREO FROM contacto WHERE nombre + ' ' + apellidos LIKE @nombre ", datos.cn);
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
            id_est = this.dg_bus.CurrentRow.Cells["ID"].Value.ToString();


            SqlCeCommand cm = new SqlCeCommand("SELECT *FROM contacto WHERE Id_correo = @id", datos.cn);
            cm.Parameters.AddWithValue("@id", id_est);
            SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cm.ExecuteReader();

            //MessageBox.Show(dt.Rows[0][0].ToString().Trim() + dt.Rows[0][1].ToString().Trim() + dt.Rows[0][2].ToString().Trim() + dt.Rows[0][3].ToString().Trim() + dt.Rows[0][4].ToString().Trim() + dt.Rows[0][5].ToString().Trim() + dt.Rows[0][6].ToString().Trim());

            try
            {

                txt_nom.Text = dt.Rows[0][1].ToString().Trim();
                txt_ape.Text = dt.Rows[0][2].ToString().Trim();
                txt_correo.Text = dt.Rows[0][3].ToString().Trim();
                txt_referencia.Text = dt.Rows[0][4].ToString().Trim();
                txt_numTel.Text = dt.Rows[0][5].ToString().Trim();


                if (dt.Rows[0][6].ToString().Trim() == "hombre")
                {
                    rdb_hombre.Checked = true;
                }
                else
                {
                    rdb_mujer.Checked = true;
                }
                txt_ape.Enabled = true;
                txt_correo.Enabled = true;
                txt_nom.Enabled = true;
                txt_numTel.Enabled = true;
                txt_referencia.Enabled = true;
                gb_genero.Enabled = true;
                btn_actualizar.Enabled = true;
                btn_eliminar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            SqlCeCommand cm = new SqlCeCommand("DELETE FROM contacto WHERE Id_correo = @id ", datos.cn);
            cm.Parameters.AddWithValue("@id", id_est);
            try
            {
                int col_afect = cm.ExecuteNonQuery();
                if (col_afect > 0)
                {
                    dg_bus.Refresh();
                    MessageBox.Show("Contacto eliminado correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_ape.Enabled = false;
                    txt_correo.Enabled = false;
                    txt_nom.Enabled = false;
                    txt_numTel.Enabled = false;
                    txt_referencia.Enabled = false;
                    gb_genero.Enabled = false;
                    btn_actualizar.Enabled = false;
                    btn_eliminar.Enabled = false;

                    txt_ape.Clear();
                    txt_correo.Clear();
                    txt_idbusc.Clear();
                    txt_nom.Clear();
                    txt_numTel.Clear();
                    txt_referencia.Clear();
                    rdb_hombre.Checked = true;

                    dg_bus.Refresh();

                }
                else
                {
                    MessageBox.Show("Fallo al eliminar al contacto", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txt_idbusc_Enter(object sender, EventArgs e)
        {
         
        }

        private void txt_idbusc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_bus.PerformClick();
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            SqlCeCommand cm = new SqlCeCommand("UPDATE contacto SET nombre = @nombre, apellidos = @apellidos, correo = @correo, referencia = @referencia, numero = @numero, genero = @genero WHERE Id_correo = @id", datos.cn);
            cm.Parameters.AddWithValue("@id", id_est);
            cm.Parameters.AddWithValue("@nombre", txt_nom.Text);
            cm.Parameters.AddWithValue("@apellidos", txt_ape.Text);
            cm.Parameters.AddWithValue("@correo", txt_correo.Text);
            cm.Parameters.AddWithValue("@referencia", txt_referencia.Text);
            cm.Parameters.AddWithValue("@numero", txt_numTel.Text);



            if (rdb_hombre.Checked == true)
            {
                cm.Parameters.AddWithValue("@genero", "hombre");

            }
            else
            {
                cm.Parameters.AddWithValue("@genero", "mujer");
            }
            
            try
            {
                int col_afect = cm.ExecuteNonQuery();
                if (col_afect > 0)
                {
                    MessageBox.Show("Update realizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dg_bus.Enabled = true;
                    dg_bus.Refresh();

                   

                    txt_nom.Clear();
                    txt_ape.Clear();
                    txt_correo.Clear();
                    txt_referencia.Clear();
                    txt_numTel.Clear();

                    txt_nom.Enabled = false;
                    txt_ape.Enabled = false;
                    txt_correo.Enabled = false;
                    txt_referencia.Enabled = false;
                    txt_numTel.Enabled = false;

                    btn_actualizar.Enabled = false;
                    btn_eliminar.Enabled = false;


                    rdb_hombre.Checked = true;
                    gb_genero.Enabled = false;
             
                }
                else
                {
                    MessageBox.Show("fallo Update", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dg_bus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}

