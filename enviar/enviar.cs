using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Data.SqlServerCe;

namespace Checador
{
    public partial class enviar : Form
    {
        conexion datos = new conexion();
        SmtpClient envios = new SmtpClient();

        String RutaArchivo = "";
        int day = DateTime.Now.Day; //--------------- numero del dia en ingles
        int mes = DateTime.Now.Month;
        int año = DateTime.Now.Year;


        public enviar()
        {
            InitializeComponent();
        }

        private void enviar_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand cm1 = new SqlCeCommand("SELECT nombre + ' ' + apellidos AS nombre, correo FROM contacto", datos.cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm1);
                DataSet ds = new DataSet();
                da.Fill(ds, "contacto");
                chl_correos.DataSource = ds.Tables[0];
                chl_correos.DisplayMember = "nombre";
                chl_correos.ValueMember = "correo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta, int puerto, string host)
        {
            MailMessage correos = new MailMessage();
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = (mensaje);
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                //System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);

                correos.Attachments.Add( new Attachment (GetStreamFile(ruta), Path.GetFileName(ruta), "application/pdf"));


                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                //Datos importantes no modificables para tener acceso a las cuentas
                envios.Host = host;
                envios.Port = puerto;
                envios.EnableSsl = true;
                envios.Send(correos);
                MessageBox.Show("El mensaje fue enviado correctamente");
               // correos.Attachments.Remove(archivo);
                correos.Attachments.Clear();
                RutaArchivo = "";
                correos.To.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            string fecha = day + "/" + mes + "/" + año; 

            foreach (var item in chl_correos.CheckedItems)
            {
                //Variables cargadas desde el archivo "parametros.confg"--------------
                //envios.Dispose();

                string Emisor = ConfigurationManager.AppSettings["emisor"];
                string Password = ConfigurationManager.AppSettings["password"];
                int puerto = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                string host = ConfigurationManager.AppSettings["host"];

                var Mensaje = txt_mensaje.Text.Replace("\r\n", "<br />");
                var Asunto = txt_asunto.Text;

                var row = (item as DataRowView).Row;
                    var Receptor = Convert.ToString(row["correo"]);
                    RutaArchivo = Directory.GetCurrentDirectory() + @"\archivos\reporte.pdf";
                    enviarCorreo(Emisor, Password, Mensaje, Asunto, Receptor, RutaArchivo, puerto, host);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        public Stream GetStreamFile(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                return memStream;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_asunto.Enabled = true;
            txt_mensaje.Enabled=true;
        }
    }
}
