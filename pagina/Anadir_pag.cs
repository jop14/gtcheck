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
using System.IO;
using ClosedXML.Excel;
using System.Globalization;

namespace Checador
{
    public partial class Anadir_pag : Form
    {
        conexion datos = new conexion();
        Regex rex = new Regex(@"^[A-Z]{1}([0-9]{5})?$");
        int mes = DateTime.Now.Month;
        string ruta;

        public Anadir_pag()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_id.Text == "")
            {
                MessageBox.Show("Campo de Id no debe de quedar vacio");
                txt_id.Focus();
            }
            else
            {
                if (txt_engasolinera.Text == "")
                {
                    MessageBox.Show("El campo de gasolinera no debe de quedar vacio");
                    txt_engasolinera.Focus();
                }
                else
                {
                    if (txt_nombre.Text == "")
                    {
                        MessageBox.Show("Campo de nombre no debe de quedar vacio");
                        txt_nombre.Focus();
                    }
                    else
                    {
                        if (txt_link.Text == "")
                        {
                            MessageBox.Show("el campo link no debe de quedar vacio");
                            txt_link.Focus();
                        }
                        else if (ValidaUrl(txt_link.Text) == false)
                        {
                            MessageBox.Show("Inserte una direción URL valida");
                        }
                        
                        else
                        {
                            SqlCeCommand cm = new SqlCeCommand("INSERT INTO pagina(Id_pag, nombre, enlace, tipo, servicio, gasolinera, linkGas, permiso) VALUES(@id, @nombre, @enlace, @tipo, @servicio, @gasolinera, @linkgas, @permiso)", datos.cn);
                            cm.Parameters.AddWithValue("@id", txt_id.Text);
                            cm.Parameters.AddWithValue("@nombre", txt_nombre.Text);
                            cm.Parameters.AddWithValue("@enlace", txt_link.Text);
                            cm.Parameters.AddWithValue("@gasolinera", cb_link.Text);
                            cm.Parameters.AddWithValue("@permiso", cblink_permiso.SelectedValue.ToString());

                            //   cm.Parameters.AddWithValue("@gas", cb_link.Text);
                            cm.Parameters.AddWithValue("@linkgas", txt_engasolinera.Text);

                            
                            if (rdb_cliente.Checked == true){
                                cm.Parameters.AddWithValue("@tipo", "cliente");
                                ruta = "clientes";
                            }
                           else{
                                cm.Parameters.AddWithValue("@tipo", "tercero");
                                ruta = "terceros";
                            }
                            if (rdb_control.Checked == true){
                                cm.Parameters.AddWithValue("@servicio", "cdf");
                            }
                            else{
                                cm.Parameters.AddWithValue("@servicio", "fe");
                            }
                            
                            try
                            {
                                int col_afect = cm.ExecuteNonQuery();
                                if (col_afect > 0)
                                {
                                    nuevafilaexcel(ruta);

                                    MessageBox.Show("Gasolinera registrada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    txt_id.Clear();
                                    txt_link.Clear();
                                    txt_nombre.Clear();
                                    rdb_cliente.Checked = true;
                                    rdb_control.Checked = true;
                                    txt_id.Focus();
                                    cb_link.SelectedValue = "Sin enlace";
                                }
                                else
                                {
                                    MessageBox.Show("Fallo al registrar.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                   }

        private void Anadir_pag_Shown(object sender, EventArgs e)
        {
            try
            {
                datos.cn.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void txt_link_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdb_terceros_CheckedChanged(object sender, EventArgs e)
        {

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

                        if (repetido ==0)
                        {
                            pb_palomita.Visible = true;
                            pb_equis.Visible = false;
                            btn_registrar.Enabled = true;
                        }else
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

        public void Anadir_pag_Load(object sender, EventArgs e)
        {
            pb_equis.Visible = false;
            pb_palomita.Visible = false;
            
            cargarCombo();
            cargarComboPermiso();
            cb_link.DropDownStyle = ComboBoxStyle.DropDownList;
            cblink_permiso.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", txt_link.Text);
        }

        public static bool ValidaUrl(string url)
        {
            if (url == null || url == "") return false;

            Regex oRegExp = new Regex(@"(http|ftp|https)://([\w-]+\.)+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase);
            return oRegExp.Match(url).Success;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString( ValidaUrl(txt_link.Text)));
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
        //---------------------------------------------------------------------------------------
        public int nuevafilaexcel(string ruta)
        {
            string fileName = Directory.GetCurrentDirectory() + @"\archivos\" + ruta + ".xlsx";
            var workbook = new XLWorkbook(fileName);
            var worksheet = workbook.Worksheet(NombreMes(mes));

            for (int r = 2; r < 201; r++)
            {
                if (worksheet.Cell(r, 1).GetString() == "")
                {
                    worksheet.Cell(r, "A").Value = new[]{
                    new { Gasolinera=txt_engasolinera.Text, Nombre=txt_nombre.Text, Identificador=txt_id.Text},
                    };
                    worksheet.Cell(r, "A").Style.Fill.BackgroundColor = XLColor.FromArgb(192,224,180);
                    break;
                }
            }
            workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\" + ruta + ".xlsx");
            return (0);
        }


        //------------------------------------------------------- funcion para obtener el nombre del mes
        public string NombreMes(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("ES-es", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        private void btn_link_Click(object sender, EventArgs e)
        {
            addGas pag = new addGas();
            pag.FormClosing += Anadir_pag_Load;
            pag.Show();
        }

        private void cb_link_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cb_link.SelectedIndex.ToString());
            MessageBox.Show(cb_link.SelectedValue.ToString());
            //MessageBox.Show(cb_link.ValueMember);
        }


        public void cargarCombo()
        {
            try
            {

                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM pagEnl ORDER BY IdEnlac ASC ", datos.cn);
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
                    cblink_permiso.DisplayMember = "permiso";
                    cblink_permiso.DataSource = dt;
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


        private void txt_gasolinera_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_link_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txt_engasolinera.Text = cb_link.SelectedValue.ToString();
        }

        private void form_cerrado()
        {
            cargarCombo();
        }


    }
}
