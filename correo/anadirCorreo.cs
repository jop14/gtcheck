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
    public partial class anadirCorreo : Form
    {
        conexion datos = new conexion();
        Regex rex = new Regex(@"^[A-Z]{1}([0-9]{5})?$");
      //  string expresion2 = @"[0-9]{1,9}(\.[0-9]{0,2})?$";

        public anadirCorreo()
        {
            InitializeComponent();
        }
        private void anadirCorreo_Load(object sender, EventArgs e)
        {
            datos.cn.Open();
        }
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text == "")
            {
                MessageBox.Show("Campo nombre no debe de quedar vacio");
                txt_nom.Focus();
            }

            else if (txt_ape.Text == "")
            {
                MessageBox.Show("Campo apellido no debe de quedar vacio");
                txt_ape.Focus();
            }
            else if (txt_referencia.Text == "")
            {
                MessageBox.Show("Campo referencia no debe de quedar vacio");
                txt_referencia.Focus();
            }
            else if (txt_correo.Text == "")
            {
                MessageBox.Show("Campo de correo no debe de quedar vacio");
                txt_correo.Focus();
            }
            else if (email_bien_escrito (txt_correo.Text)== false)
            {
                MessageBox.Show("Inserte una dirección de correo valida");
                txt_correo.Focus();
            }
            else if (txt_numTel.Text == "")
            {
                MessageBox.Show("Campo de numero telefonico no debe de quedar vacio");
                txt_correo.Focus();
            }
            else if (txt_numTel.Text.Length < 10)
            {
                MessageBox.Show("Numero invalido");
            }

            else
                try
            {
                SqlCeCommand cm = new SqlCeCommand("INSERT INTO contacto(nombre, apellidos, correo, referencia, numero, genero) VALUES(@nombre, @apellidos, @correo, @referencia, @numero, @genero)", datos.cn);
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
                    cm.Parameters.AddWithValue("@tipo", "mujer");
                }
                try
                {
                    int col_afect = cm.ExecuteNonQuery();
                    if (col_afect > 0)
                    {
                        MessageBox.Show("Contacto registrado correctamente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_ape.Clear();
                        txt_correo.Clear();
                        txt_nom.Clear();
                        txt_numTel.Clear();
                        txt_referencia.Clear();
                        rdb_hombre.Checked = true;
                        txt_nom.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Fallo al registrar el contacto.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_nom_TextChanged(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------------------------------- Funcion para validar email
        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //------------------------------------------------------------------------------------- validacoin para solo permitir numeros en el textbox de numero telefonico
        private void txt_numTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
