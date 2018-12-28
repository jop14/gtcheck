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
    public partial class addGas : Form
    {
        Anadir_pag refre = new Anadir_pag();
        conexion datos = new conexion();
        public addGas()
        {
            InitializeComponent();
        }

        private void addGas_Load(object sender, EventArgs e)
        {
            datos.cn.Open();
            cargarCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_link.Text == "")
            {
               
            }
            else
            {
                try
                {
                    SqlCeCommand cm = new SqlCeCommand("INSERT INTO pagEnl(enlace, grupo) VALUES(@enlace, @grupo)", datos.cn);
                    cm.Parameters.AddWithValue("@enlace", txt_link.Text);
                    cm.Parameters.AddWithValue("@grupo", txt_grupo.Text);
                    int col_afect = cm.ExecuteNonQuery();
                    if (col_afect > 0)
                    {
                        //  nuevafilaexcel(ruta);
                        
                        MessageBox.Show("Enlace registrado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refre.cargarCombo();
                        this.cargarCombo();

                        txt_link.Clear();
                        txt_grupo.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void cb_link_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_id.Text = cb_link.SelectedValue.ToString();
            try
            {
                    SqlCeCommand cm = new SqlCeCommand("SELECT *FROM pagEnl WHERE IdEnlac = @id ", datos.cn);
                    cm.Parameters.AddWithValue("@id",cb_link.SelectedValue.ToString());
                    SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cm.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    txt_actgrupo.Text = dt.Rows[0][2].ToString().Trim();
                    txt_edlink.Text = dt.Rows[0][1].ToString().Trim();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (cb_link.Text == "Sin grupo")
            {
                txt_edlink.Enabled = false;
              //  txt_edgrupo.Enabled = false;
                btn_del.Enabled = false;
                btn_edit.Enabled = false;
                txt_actgrupo.Enabled = false;
            }
            else
            {
                txt_edlink.Enabled = true;
                txt_edgrupo.Enabled = true;
                btn_del.Enabled = true;
                btn_edit.Enabled = true;
                txt_actgrupo.Enabled = true;

            }

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlCeCommand cm = new SqlCeCommand("DELETE FROM pagEnl WHERE IdEnlac = @id ", datos.cn);
                    cm.Parameters.AddWithValue("@id", txt_id.Text);

                    int col_afect = cm.ExecuteNonQuery();
                    if (col_afect > 0)
                    {

                        MessageBox.Show("Enlace eliminado correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarCombo();
                        txt_actgrupo.Clear();
                        txt_edlink.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Fallo al eliminar el dato", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {

            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("UPDATE pagEnl SET enlace = @enlace, grupo = @grupo WHERE IdEnlac = @id", datos.cn);
                cm.Parameters.AddWithValue("@id", txt_id.Text);
                cm.Parameters.AddWithValue("@enlace", txt_edlink.Text);
                cm.Parameters.AddWithValue("@grupo", txt_edgrupo.Text);

                int col_afect = cm.ExecuteNonQuery();
                if (col_afect > 0)
                {
                    MessageBox.Show("Update realizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Refresh();

                }
                else
                {
                    MessageBox.Show("Update no realizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
 
           
        }
        private void cargarCombo()
        {
            try
            {
               // MessageBox.Show("entro");
                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM pagEnl", datos.cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cb_link.DisplayMember = "grupo";

                    cb_link.DataSource = dt;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_actgrupo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
