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

    
    public partial class Permiso : Form
    {
        conexion datos = new conexion();
        public Permiso()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("INSERT INTO permisos(permiso) VALUES(@permiso)", datos.cn);
                cm.Parameters.AddWithValue("@permiso", txt_permiso.Text);
                int col_afect = cm.ExecuteNonQuery();
                if (col_afect > 0)
                {
                     MessageBox.Show("Permiso agregado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.cargarCombo();

                    txt_permiso.Clear();
                    txt_permiso.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Permiso_Load(object sender, EventArgs e)
        {
            datos.cn.Open();
            cargarCombo();
        }

        private void cargarCombo()
        {
            try
            {
                // MessageBox.Show("entro");
                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM permisos", datos.cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cb_link.DisplayMember = "permiso";

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

        private void cb_link_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_id.Text = cb_link.SelectedValue.ToString();
            try
            {
                SqlCeCommand cm = new SqlCeCommand("SELECT *FROM permisos WHERE IdPermiso = @id ", datos.cn);
                cm.Parameters.AddWithValue("@id", cb_link.SelectedValue.ToString());
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cm.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    txt_edpermiso.Text = dt.Rows[0][1].ToString().Trim();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("UPDATE permisos SET permiso = @permiso WHERE @id = IdPermiso", datos.cn);
                cm.Parameters.AddWithValue("@id", txt_id.Text);
                cm.Parameters.AddWithValue("@permiso", txt_edpermiso.Text);

                int col_afect = cm.ExecuteNonQuery();
                if (col_afect > 0)
                {
                    MessageBox.Show("Update realizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cargarCombo();

                }
                else
                {
                    MessageBox.Show("Update no realizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlCeCommand cm = new SqlCeCommand("DELETE FROM permisos WHERE IdPermiso = @id ", datos.cn);
                    cm.Parameters.AddWithValue("@id", txt_id.Text);

                    int col_afect = cm.ExecuteNonQuery();
                    if (col_afect > 0)
                    {

                        MessageBox.Show("Enlace eliminado correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarCombo();
                        txt_edpermiso.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Fallo al eliminar el dato", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
