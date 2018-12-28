using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using ClosedXML.Excel;
using System.Globalization;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;

namespace Checador
{
    public partial class EditarEliminar : Form
    {
        conexion datos = new conexion();
        string ID;
        int mes = DateTime.Now.Month;
        string ruta;
        Regex rex = new Regex(@"^[A-Z]{1}([0-9]{5})?$");

        public EditarEliminar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarEliminar_Load(object sender, EventArgs e)
        {
            datos.cn.Open();

            dg_bus.Enabled = true;
            dg_bus.Refresh();
            txt_link.Enabled = false;
            txt_id.Enabled = false;
            txt_engasolinera.Enabled = false;
            txt_nombre.Enabled = false;
            gb_usuarios.Enabled = false;
            gb_servicios.Enabled = false;
            btn_ver.Enabled = false;
            btn_registrar.Enabled = false;
            btn_eliminar.Enabled = false;

            btn_ver2.Enabled = false;
            cb_link.Enabled = false;

            pb_equis.Visible = false;
            pb_palomita.Visible = false;

            cb_permiso.Enabled = false;

            cargarCombo();
            cargarComboPermiso();

        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void cb_resultados_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void EditarEliminar_Shown(object sender, EventArgs e)
        {

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
                        cm.Parameters.AddWithValue("@nombre", "%" + txt_idbusc.Text + "%" );
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

        private void dg_bus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dg_bus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pb_palomita.Visible = false;
            pb_equis.Visible = false;
            String id_est = this.dg_bus.CurrentRow.Cells["ESTACION"].Value.ToString();

            try
            {
                SqlCeCommand cm = new SqlCeCommand("SELECT *FROM pagina WHERE Id_pag = @id", datos.cn);
            cm.Parameters.AddWithValue("@id", id_est);
            SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cm.ExecuteReader();
              // MessageBox.Show(dt.Rows[0][0].ToString().Trim() + "--" + dt.Rows[0][1].ToString().Trim() + "--" + dt.Rows[0][2].ToString().Trim() + "--" + dt.Rows[0][3].ToString().Trim() + "--" + dt.Rows[0][4].ToString().Trim() + "--" + dt.Rows[0][5].ToString().Trim() + "--" + dt.Rows[0][6].ToString().Trim() + "--" + dt.Rows[0][7].ToString().Trim());
           
                ID = dt.Rows[0][0].ToString().Trim();

                txt_id.Text = dt.Rows[0][0].ToString().Trim();
                txt_nombre.Text = dt.Rows[0][1].ToString().Trim();
                txt_engasolinera.Text = dt.Rows[0][6].ToString().Trim();
                txt_link.Text = dt.Rows[0][3].ToString().Trim();
                cb_link.Text = dt.Rows[0][5].ToString().Trim();

                if (dt.Rows[0][7].ToString().Trim() == "")
                {
                    cb_permiso.SelectedValue = 1;
                }
                else
                {
                    cb_permiso.SelectedValue = dt.Rows[0][7].ToString().Trim();

                }
                btn_ver.Enabled = true;

                if(dt.Rows[0][2].ToString().Trim() == "cliente")
                {
                    rdb_cliente.Checked = true;
                }
                else
                {
                    rdb_terceros.Checked = true;
                }
                if (dt.Rows[0][4].ToString().Trim() == "fe")
                {
                    rdb_fe.Checked = true;
                }
                else
                {
                    rdb_control.Checked = true;
                }

                dg_bus.Enabled = true;
                txt_link.Enabled = true;
                txt_id.Enabled = true;
                txt_engasolinera.Enabled = true;
                txt_nombre.Enabled = true;
                gb_usuarios.Enabled = true;
                gb_servicios.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_registrar.Enabled = true;

                cb_permiso.Enabled = true;

                btn_ver2.Enabled = true;
                cb_link.Enabled = true;
            }
            catch (Exception ex)
            {
             // MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e) 
        {
            //borrar tupla en la bd
            SqlCeCommand cm = new SqlCeCommand("DELETE FROM pagina WHERE Id_pag = @id ", datos.cn);
            cm.Parameters.AddWithValue("@id", txt_id.Text);
            try
            {
                int col_afect = cm.ExecuteNonQuery();
                if (col_afect > 0)
                {
                    if (rdb_cliente.Checked == true)
                    {
                        ruta = "clientes";
                    }
                    else
                    {
                        ruta = "terceros";
                    }

                    borrarfilaexcel(ruta);

                    MessageBox.Show("Pagina eliminada correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dg_bus.Refresh();

                    dg_bus.Enabled = true;
                    txt_link.Enabled = false;
                    txt_id.Enabled = false;
                    txt_engasolinera.Enabled = false;
                    txt_nombre.Enabled = false;
                    gb_servicios.Enabled = false;
                    gb_usuarios.Enabled = false;

                    txt_link.Clear();
                    txt_id.Clear();
                    txt_engasolinera.Clear();
                    txt_nombre.Clear();
                    rdb_cliente.Checked = true;
                    rdb_control.Checked = true;
                    btn_registrar.Enabled = false;
                    btn_eliminar.Enabled = false;
                    btn_ver.Enabled = false;
                    btn_ver2.Enabled = false;
                    cb_link.Enabled = false;


                }
                else
                {
                    MessageBox.Show("Fallo al eliminar la pagina", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            // actualizar dg
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

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "") {
                MessageBox.Show("Campo Id no debe de quedar vacio");
                txt_id.Focus();
            } else {
                if (txt_engasolinera.Text == "")
                {
                    MessageBox.Show("Campo Gasolinera no debe de quedar vacio");
                }
                else
                {
                    if (txt_nombre.Text == "")
                    {
                        MessageBox.Show("Campo Nombre no debe de quedar vacio");
                    }
                    else
                    {
                        if (txt_link.Text == "")
                        {
                            MessageBox.Show("Campo enlace no debe de quedar vacio");
                        }
                        else
                        {

                            SqlCeCommand cm = new SqlCeCommand("UPDATE pagina SET Id_pag = @newid, nombre = @nombre, enlace = @enlace, tipo = @tipo, gasolinera = @gasolinera, servicio = @servicio, linkgas = @linkgas, permiso = @permiso  WHERE Id_pag = @id", datos.cn);
                            cm.Parameters.AddWithValue("@id", ID);
                            cm.Parameters.AddWithValue("@newid",txt_id.Text);
                            cm.Parameters.AddWithValue("@nombre", txt_nombre.Text);
                            cm.Parameters.AddWithValue("@enlace", txt_link.Text);
                            cm.Parameters.AddWithValue("@gasolinera", cb_link.Text);
                            cm.Parameters.AddWithValue("@linkGas", txt_engasolinera.Text);
                            cm.Parameters.AddWithValue("@permiso",cb_permiso.SelectedValue.ToString()); ;


                            if (rdb_cliente.Checked == true)
                            {
                                cm.Parameters.AddWithValue("@tipo", "cliente");
                                ruta = "clientes";
                            }
                            else
                            {
                                cm.Parameters.AddWithValue("@tipo", "tercero");
                                ruta = "terceros";
                            
                            }

                            if (rdb_fe.Checked == true)
                            {
                                cm.Parameters.AddWithValue("@servicio", "fe");

                            }
                            else
                            {
                                cm.Parameters.AddWithValue("@servicio", "cdf");
                            }

                            try
                            {
                                int col_afect = cm.ExecuteNonQuery();
                                if (col_afect > 0)
                                {
                                    modificarfilaexcel(ruta);
                                    MessageBox.Show("Update realizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dg_bus.Enabled = true;
                                    dg_bus.Refresh();
                                    
                                    txt_link.Enabled = false;
                                    txt_id.Enabled = false;
                                    txt_engasolinera.Enabled = false;
                                    txt_nombre.Enabled = false;
                                    gb_usuarios.Enabled = false;
                                    gb_servicios.Enabled = false;
                                    btn_ver.Enabled = false;
                                    btn_registrar.Enabled = false;
                                    btn_eliminar.Enabled = false;
                                    


                                    txt_link.Clear();
                                    txt_id.Clear();
                                    txt_idbusc.Clear();
                                    txt_nombre.Clear();
                                    txt_engasolinera.Clear();
                                    rdb_cliente.Checked = true;
                                    rdb_control.Checked = true;

                                    btn_ver2.Enabled = false;
                                    cb_link.Enabled = false;


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

                    }
                }
            }
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Chrome.exe", txt_link.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un erro al abrir Google Chrome, " + ex.Message);
            }
        }

        private void txt_idbusc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_bus.PerformClick();
            }
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            if (txt_id.TextLength < 6)
            {
                btn_registrar.Enabled = false;
                pb_palomita.Visible = false;
                pb_equis.Visible = false;

            }
            else
            {
                if (rex.IsMatch(txt_id.Text))
                {

                    try
                    {
                        int repetido = 0;
                        SqlCeCommand cm = new SqlCeCommand("SELECT * FROM pagina WHERE Id_pag = @id ", datos.cn);
                        cm.Parameters.AddWithValue("@id", txt_id.Text);
                        SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            repetido = 1;
                        }
                        else
                        {
                            repetido = 0;
                        }

                        if (repetido == 0 || dt.Rows[0][0].ToString().Trim() == ID)
                        {
                            pb_palomita.Visible = true;
                            pb_equis.Visible = false;
                            btn_registrar.Enabled = true;
                        }
                        else
                        {
                            pb_equis.Visible = true;
                            pb_palomita.Visible = false;
                        }

                    }
                    catch
                    {

                    }
                }
                else
                {
                    btn_registrar.Enabled = false;
                }
            }
        }

        private void txt_idbusc_TextChanged(object sender, EventArgs e)
        {

        }


        public int borrarfilaexcel(string ruta)
        {
            string fileName = Directory.GetCurrentDirectory() + @"\archivos\" + ruta + ".xlsx";
            var workbook = new XLWorkbook(fileName);
            var worksheet = workbook.Worksheet(NombreMes(mes));

            for (int r = 2; r < 201; r++)
            {
                if (worksheet.Cell(r, 3).GetString() == txt_id.Text)
                {
                    for (int aux = 1; aux < 38; aux++)
                    {
                        worksheet.Cell(r, aux).Style.Fill.BackgroundColor = XLColor.Yellow;
                    }
                    break;
                }
            }
            workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\" + ruta + ".xlsx");
            return 1;
        }

        //---------------------------------------------------------------------------------------
        public int modificarfilaexcel(string ruta)
        {
            string fileName = Directory.GetCurrentDirectory() + @"\archivos\" + ruta + ".xlsx";
            var workbook = new XLWorkbook(fileName);
            var worksheet = workbook.Worksheet(NombreMes(mes));
            for (int r = 2; r < 201; r++)
            {
                if (worksheet.Cell(r, 3).GetString() == txt_id.Text)
                {
                    worksheet.Cell(r, "A").Value = cb_link.Text;
                    worksheet.Cell(r, "B").Value = txt_nombre.Text;
                    worksheet.Cell(r, "C").Value = txt_id.Text;
                    break;
                }
            }
            workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\" + ruta + ".xlsx");
            return 1;
        }

        //------------------------------------------------------- funcion para obtener el nombre del mes
        public string NombreMes(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("ES-es", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
        public void cargarCombo()
        {
            try
            {

                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM pagEnl ORDER BY IdEnlac ASC", datos.cn);
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

        private void cb_link_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_engasolinera.Text = cb_link.SelectedValue.ToString();
        }

        private void btn_link_Click(object sender, EventArgs e)
        {
            datos.cn.Close();
            addGas sns = new addGas();
            sns.FormClosing += EditarEliminar_Load;

            sns.Show();

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Chrome.exe", txt_engasolinera.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un erro al abrir Google Chrome, " + ex.Message);
            }
        }

        public void cargarComboPermiso()
        {
            try
            {

                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM permisos ORDER BY IdPermiso ASC", datos.cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cb_permiso.DisplayMember = "permiso";
                    cb_permiso.DataSource = dt;
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


    }
}
