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
using System.Data.SqlServerCe;
using ClosedXML.Excel;
using System.Globalization;
using System.Net;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;



namespace Checador
{
    public partial class crear : Form
    {

        conexion datos = new conexion(); 
        int day = DateTime.Now.Day; //--------------- numero del dia en ingles
        int mes = DateTime.Now.Month;
        int año = DateTime.Now.Year;
        String RutaArchivo = "";
        String RutaArchivo2 = "";
         
        SmtpClient envios = new SmtpClient();

        public crear()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ambos.Checked == true)
            {
                btn_ver.Enabled = false;
            }
            else
            {
                btn_ver.Enabled = true;
            }
        }
        private void generar_Load(object sender, EventArgs e)
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
// ----------------------------------------------------------------------   boton para llenar los archivos excel
        private void btn_llenar_Click(object sender, EventArgs e)
        {

            if (rdb_terceros.Checked == true)
            {

                datos.cn.Open();
                //Creamos el delegado 
                ThreadStart delegado = new ThreadStart(terceros);
                //Creamos la instancia del hilo 
                Thread hilo = new Thread(delegado);
                //Iniciamos el hilo 
                hilo.Start();
                datos.cn.Close();
            }
            else if (rdb_clientes.Checked == true)
            {
                datos.cn.Open();

                //Creamos el delegado 
                ThreadStart delegado = new ThreadStart(clientes);
                //Creamos la instancia del hilo 
                Thread hilo = new Thread(delegado);
                //Iniciamos el hilo 
                hilo.Start();
                datos.cn.Close();

            }
            else if (rdb_ambos.Checked == true)
            {
                datos.cn.Open();
                //Creamos el delegado 
                ThreadStart delegado = new ThreadStart(terceros);
                //Creamos la instancia del hilo 
                Thread hilo = new Thread(delegado);
                //Iniciamos el hilo 
                hilo.Start();
                datos.cn.Close();

            }
        }

//-----------------------------------------------------------------------   boton para enviar el archivo excel
        private void button3_Click(object sender, EventArgs e)
        {
            string fecha = day + "/" + mes + "/" + año;

            //Variables cargadas desde el archivo "parametros.confg"--------------
            string Emisor = ConfigurationManager.AppSettings["emisor"];
            string Password = ConfigurationManager.AppSettings["password"]; ;
            var Mensaje = (ConfigurationManager.AppSettings["mensaje"]) + fecha;
            var Asunto = ConfigurationManager.AppSettings["asunto"];
            //Variables cargadas desde el archivo "parametros.confg"--------------

            foreach (var item in chl_correos.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                var Receptor = Convert.ToString(row["correo"]);

                if (rdb_clientes.Checked == true)
                {
                    MessageBox.Show("Se enviara el archivo Excel de clientess");
                    RutaArchivo= Directory.GetCurrentDirectory() + @"\archivos\clientes.xlsx";
                    enviarCorreo(Emisor, Password, Mensaje, Asunto, Receptor, RutaArchivo);

                }
                else if (rdb_terceros.Checked == true)
                {
                    MessageBox.Show("Se enviara el archivo Excel de terceros");

                    RutaArchivo = Directory.GetCurrentDirectory() + @"\archivos\terceros.xlsx";
                    enviarCorreo(Emisor, Password, Mensaje, Asunto, Receptor, RutaArchivo);
                }
                else if (rdb_ambos.Checked == true)
                {
                    MessageBox.Show("Se enviaran ambos archivos de Excel (Clientes y terceros)");

                    RutaArchivo = Directory.GetCurrentDirectory() + @"\archivos\clientes.xlsx";
                    RutaArchivo2 = Directory.GetCurrentDirectory() + @"\archivos\terceros.xlsx";
                    enviarCorreo2(Emisor, Password, Mensaje, Asunto, Receptor, RutaArchivo, RutaArchivo2);
                }
               
            }
        }

//-----------------------------------------------------------------------   boton para cerrar ventana
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
//-----------------------------------------------------------------------   boton para abrir excel
        private void btn_ver_Click(object sender, EventArgs e)
        {
            if (rdb_terceros.Checked == true)
            {
                abrirexcel(Directory.GetCurrentDirectory() + @"\archivos\terceros.xlsx");
            }
            else if (rdb_clientes.Checked == true)
            {
                abrirexcel(Directory.GetCurrentDirectory() + @"\archivos\clientes.xlsx");
            }
        }
        private void rdb_clientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ambos.Checked == true)
            {
                btn_ver.Enabled = false;
            }
            else
            {
                btn_ver.Enabled = true;
            }
        }

        private void rdb_ambos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ambos.Checked == true)
            {
                btn_ver.Enabled = false;
            }
            else
            {
                btn_ver.Enabled = true;
            }
        }

        /*
         * 
         * 
         * 
         * 
         * -------------------------------------         inician las funciones
         * 
         * 
         * 
         * 
         * 
         * 
        */
        //------------------------------------------------------- funcion para enviar el archivo por correo
        public void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
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

                System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);

                correos.Attachments.Add(archivo);


                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                //Datos importantes no modificables para tener acceso a las cuentas
                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;
                envios.Send(correos);
                MessageBox.Show("El mensaje fue enviado correctamente");
                correos.Attachments.Clear();
                RutaArchivo = "";
                correos.To.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void enviarCorreo2(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta, string ruta2)
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

                System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);
                System.Net.Mail.Attachment archivo2 = new System.Net.Mail.Attachment(ruta2);

                correos.Attachments.Add(archivo);
                correos.Attachments.Add(archivo2);

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                //Datos importantes no modificables para tener acceso a las cuentas
                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;
                envios.Send(correos);
                MessageBox.Show("El mensaje fue enviado correctamente");

                RutaArchivo = "";
                RutaArchivo2 = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//------------------------------------------------------- funcion para buscar en que columna insertar los datos
        public string celda_dia(int day)
        {
            var retornar = "";
            switch (day)
            {
                case 1:
                    retornar = "D";
                    break;
                case 2:
                    retornar = "E";
                    break;
                case 3:
                    retornar = "F";
                    break;
                case 4:
                    retornar = "G";
                    break;
                case 5:
                    retornar = "H";
                    break;
                case 6:
                    retornar = "I";
                    break;
                case 7:
                    retornar = "J";
                    break;
                case 8:
                    retornar = "K";
                    break;
                case 9:
                    retornar = "L";
                    break;
                case 10:
                    retornar = "M";
                    break;
                case 11:
                    retornar = "N";
                    break;
                case 12:
                    retornar = "O";
                    break;
                case 13:
                    retornar = "P";
                    break;
                case 14:
                    retornar = "Q";
                    break;
                case 15:
                    retornar = "R";
                    break;
                case 16:
                    retornar = "S";
                    break;
                case 17:
                    retornar = "T";
                    break;
                case 18:
                    retornar = "U";
                    break;
                case 19:
                    retornar = "V";
                    break;
                case 20:
                    retornar = "W";
                    break;
                case 21:
                    retornar = "X";
                    break;
                case 22:
                    retornar = "Y";
                    break;
                case 23:
                    retornar = "Z";
                    break;
                case 24:
                    retornar = "AA";
                    break;
                case 25:
                    retornar = "AB";
                    break;
                case 26:
                    retornar = "AC";
                    break;
                case 27:
                    retornar = "AD";
                    break;
                case 28:
                    retornar = "AE";
                    break;
                case 29:
                    retornar = "AF";
                    break;
                case 30:
                    retornar = "AG";
                    break;
                case 31:
                    retornar = "AH";
                    break;
            }
            return retornar;
        }
//------------------------------------------------------- funcion para obtener el nombre del mes
        public string NombreMes(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("ES-es", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
//------------------------------------------------------- Funcion para insertar los datos en el archivo excel para los servicios ofrecidos a terceros
        public void terceros()
        {
            try
            {
              
               
                string fileName = Directory.GetCurrentDirectory() + @"\archivos\terceros.xlsx";

                var workbook = new XLWorkbook(fileName);
                var worksheet = workbook.Worksheet(NombreMes(mes));
                int posicion = 3;

                string id_checar = worksheet.Cell(posicion, 3).Value.ToString();

                var numerocelda = 1;
                var hoy = celda_dia(day);

                while (id_checar != "")
                {
                    // MessageBox.Show(posicion + "    " + id_checar); mostrar la posicion del excel y el identificador rescatado
                    id_checar = worksheet.Cell(posicion, 3).Value.ToString();
                    if ((id_checar == "") || (worksheet.Cell(posicion, 3).Style.Fill.BackgroundColor == XLColor.Yellow))
                    {
                        //
                    }
                    else
                    {
                        //MessageBox.Show("bandera");
                        numerocelda = numerocelda + 1;
                        //SqlCeCommand cm1 = new SqlCeCommand("SELECT estado, version FROM chec WHERE id_pag = @id and servicio = 'tercero' and fecha =   '02/08/18'", datos.cn);
        
                      
                        SqlCeCommand cm1 = new SqlCeCommand("SELECT a.estado, a.version, b.enlace FROM chec a INNER JOIN pagina b ON a.id_pag = b.Id_pag WHERE a.id_pag = @id and a.servicio = 'tercero' and a.fecha = '" + DateTime.Now.ToString("dd/MM/yy") + "'", datos.cn);
                        cm1.Parameters.AddWithValue("@id", id_checar);
                        SqlCeDataAdapter da1 = new SqlCeDataAdapter(cm1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        string con = dt1.Rows[0][0].ToString().Trim();
                        string ver = dt1.Rows[0][1].ToString().Trim();
                        string linTer = dt1.Rows[0][2].ToString().Trim();
                         //MessageBox.Show(dt1.Rows[0][3].ToString().Trim() + " " + linTer); //mostrar version en cada insert al excel------ > descomentar
                        if (dt1.Rows.Count > 0)
                        {
                            if (con == "True")
                            {
                                // MessageBox.Show(con + " --- " + ver);

                                worksheet.Cell(hoy + posicion).Value = 1;
                                worksheet.Cell("AJ" + posicion).Value = ver;
                                worksheet.Cell("Ak" + posicion).Value = linTer;

                            }
                            else
                            {
                                worksheet.Cell(hoy + posicion).Value = 0;
                                worksheet.Cell("AJ" + posicion).Value = ver;
                                worksheet.Cell("Ak" + posicion).Value = linTer;

                            }
                        }
                    }

                    posicion++; // contador para aumentar la posicion en el barrido del doc excel
                }
                workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\terceros.xlsx");
                MessageBox.Show("Se a terminado de crear documento excel para terceros");

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //     workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\prueba.xlsx");

            }

            if (rdb_ambos.Checked == true)
            {
                clientes();
            }


            }
//------------------------------------------------------- Funcion para insertar los datos en el archivo excel para los servicios ofrecidos a clientes
        public void clientes()
        {
            try
            {
                string fileName = Directory.GetCurrentDirectory() + @"\archivos\clientes.xlsx";

                var workbook = new XLWorkbook(fileName);
                var worksheet = workbook.Worksheet(NombreMes(mes));
                int posicion = 3;
                string id_checar = worksheet.Cell(posicion, 3).Value.ToString();
                var numerocelda = 1;
                var hoy = celda_dia(day);

                while (id_checar != "")
                {
                    // MessageBox.Show(posicion + "    " + id_checar);
                    id_checar = worksheet.Cell(posicion, 3).Value.ToString();
                    if ((id_checar == "") || (worksheet.Cell(posicion,3).Style.Fill.BackgroundColor == XLColor.Yellow))
                    {
                       // MessageBox.Show("es amarillo");
                     
                    }
                    else
                    {
                        numerocelda = numerocelda + 1;
                        //SqlCeCommand cm1 = new SqlCeCommand("SELECT estado, version FROM chec WHERE id_pag = @id and servicio = 'cliente' and fecha =   '02/08/18'", datos.cn);

                        SqlCeCommand cm1 = new SqlCeCommand("SELECT a.estado, a.version, b.enlace FROM chec a INNER JOIN pagina b ON a.id_pag = b.Id_pag WHERE a.id_pag = @id and a.servicio = 'cliente' and a.fecha = '" + DateTime.Now.ToString("dd/MM/yy") + "'", datos.cn);
                        cm1.Parameters.AddWithValue("@id", id_checar);
                        SqlCeDataAdapter da1 = new SqlCeDataAdapter(cm1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        string con = dt1.Rows[0][0].ToString().Trim();
                        string ver = dt1.Rows[0][1].ToString().Trim();
                        string linTer = dt1.Rows[0][2].ToString().Trim();
                        //MessageBox.Show(dt1.Rows[0][3].ToString().Trim() + " " + linTer); //mostrar version en cada insert al excel------ > descomentar
                        if (dt1.Rows.Count > 0)
                        {
                            if (con == "True")
                            {
                                // MessageBox.Show(con + " --- " + ver);

                                worksheet.Cell(hoy + posicion).Value = 1;
                                worksheet.Cell("AJ" + posicion).Value = ver;
                                worksheet.Cell("Ak" + posicion).Value = linTer;

                            }
                            else
                            {
                                worksheet.Cell(hoy + posicion).Value = 0;
                                worksheet.Cell("AJ" + posicion).Value = ver;
                                worksheet.Cell("Ak" + posicion).Value = linTer;

                            }
                        }
                    }

                    posicion++; // contador para aumentar la posicion en el barrido del doc excel
                }
                workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\clientes.xlsx");
                MessageBox.Show("Se a terminado de crear documento excel para clientes");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //     workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\prueba.xlsx");

            }
        }

//------------------------------------------------------- funcion para abrir excel
        static void abrirexcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = @"""" + f + @"""";
            Process.Start(startInfo);
        }
    }
}
