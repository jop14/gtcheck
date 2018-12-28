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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Collections.Specialized;

namespace Checador
{
    public partial class crrm : Form
    {
        conexion datos = new conexion();

        int day = DateTime.Now.Day; //--------------- numero del dia en ingles
        int mes = DateTime.Now.Month;
        int año = DateTime.Now.Year;


        public crrm()
        {
            InitializeComponent();
        }

        private void pag_caidasdia_Load(object sender, EventArgs e)
        {
            general();
            datos.cn.Open();
            dtg_vista.Columns[0].Width = 50;
            dtg_vista.Columns[1].Width = 200;
            dtg_vista.Columns[2].Width = 200;
            dtg_vista.Columns[3].Width = 50;
            dtg_vista.Columns[4].Width = 40;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            crear_pdf();
        }
        //--------------------------------------------------------------- > crear y dar formato de pdf
        private void crear_pdf()
        {
            Document doc = new Document(PageSize.A4, 15, 15, 15, 15); //--- tipo de hoja y margenes
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }

            if (filename.Trim() != "")
            {
                FileStream file = new FileStream(filename,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.ReadWrite);
                PdfWriter.GetInstance(doc, file);
                doc.Open();
                // string remito = "Autorizo: Roberto espinoza";
                string envio = "Fecha:" + DateTime.Now.ToString();
                // Creamos la imagen y le ajustamos el tamaño
                iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(Directory.GetCurrentDirectory() + @"\img\logo.png");
                imagen.BorderWidth = 0;

                imagen.Alignment = Element.ALIGN_RIGHT;
                float percentage = 0.0f;
                percentage = 150 / imagen.Width;
                imagen.ScalePercent(percentage * 100);

                // Insertamos la imagen en el documento
                doc.Add(imagen);

                Chunk chunk = new Chunk("Reporte diario de paginas caidas", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
                doc.Add(new Paragraph(chunk));
                doc.Add(new Paragraph("                       "));
                // doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------------------------"));
                doc.Add(new Paragraph("Reporte con los datos generados de paginas caidas de Clientes y Terceros del dia."));
                doc.Add(new Paragraph("Gt soluciones"));
                // doc.Add(new Paragraph(remito));
                doc.Add(new Paragraph("Reporte generado: " + DateTime.Now.ToString()));
                doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------------------------"));
                doc.Add(new Paragraph("                       "));
                GenerarDocumento(doc);
                doc.AddCreationDate();
                doc.Add(new Paragraph("                       "));
                doc.Close();
                // Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
            }
        }
        public void GenerarDocumento(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dtg_vista.ColumnCount);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = GetTamañoColumnas(dtg_vista);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 2;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dtg_vista.ColumnCount; i++)
            {
                datatable.AddCell(dtg_vista.Columns[i].HeaderText);
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dtg_vista.Rows.Count; i++)
            {
                for (j = 0; j < dtg_vista.Columns.Count; j++)
                {
                    if (dtg_vista[j, i].Value != null)
                    {
                        if (j == 4)
                        {
                            try
                            {
                                Chunk portText = new Chunk("link");
                                portText.SetAnchor(new Uri(dtg_vista[j, i].Value.ToString()));
                                Paragraph p = new Paragraph();
                                p.Add(portText);
                                datatable.AddCell(new Phrase(p));
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            datatable.AddCell(new Phrase(dtg_vista[j, i].Value.ToString()));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                        }
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            enviar_pdf();
            enviar enviar = new enviar();
            enviar.ShowDialog();
        }

        private void enviar_pdf()
        {
            try
            {
                Document doc = new Document(PageSize.A4, 15, 15, 15, 15); //--- tipo de hoja y margenes

                string filename = Directory.GetCurrentDirectory() + @"\archivos\reporte.pdf";

                if (filename.Trim() != "")
                {
                    using (FileStream file = new FileStream(filename,
                      FileMode.OpenOrCreate,
                      FileAccess.ReadWrite,
                      FileShare.ReadWrite))
                    {
                        PdfWriter.GetInstance(doc, file);
                        doc.Open();
                        // string remito = "Autorizo: Roberto espinoza";
                        string envio = "Fecha:" + DateTime.Now.ToString();

                        // Creamos la imagen y le ajustamos el tamaño
                        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(Directory.GetCurrentDirectory() + @"\img\logo.png");
                        imagen.BorderWidth = 0;

                        imagen.Alignment = Element.ALIGN_RIGHT;
                        float percentage = 0.0f;
                        percentage = 150 / imagen.Width;
                        imagen.ScalePercent(percentage * 100);

                        // Insertamos la imagen en el documento
                        doc.Add(imagen);

                        Chunk chunk = new Chunk("Reporte diario de paginas caidas", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
                        doc.Add(new Paragraph(chunk));
                        doc.Add(new Paragraph("                       "));
                        // doc.Add(new Paragraph("                       "));
                        doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------------------------"));
                        doc.Add(new Paragraph("Reporte con los datos generados de paginas caidas de Clientes y Terceros del dia."));
                        doc.Add(new Paragraph("Gt soluciones"));
                        // doc.Add(new Paragraph(remito));
                        doc.Add(new Paragraph("Reporte generado: " + DateTime.Now.ToString()));
                        doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------------------------"));
                        doc.Add(new Paragraph("                       "));
                        GenerarDocumento(doc);
                        doc.AddCreationDate();
                        doc.Add(new Paragraph("                       "));
                        doc.Close();
                        // Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void dtg_vista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dtg_vista_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Chrome.exe", dtg_vista.Rows[e.RowIndex].Cells[5].Value.ToString());
            }
            catch
            {
                try
                {
                    System.Diagnostics.Process.Start(dtg_vista.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                catch (Exception exx)
                {
                    MessageBox.Show("A ocurrido un erro al abrir el navegador, " + exx.Message);
                }
            }
        }

        private void btn_crm_Click(object sender, EventArgs e)
        {

            try
            {
                string value1, value2, value3, value4, value5, value6, value7, value8, value9;
                string fecha = day + "/" + mes + "/" + año;

                //Variables cargadas desde el archivo "parametros.confg"--------------
                //envios.Dispose();

                foreach (DataGridViewRow row in dtg_vista.SelectedRows)
                {
                    value1 = row.Cells[0].Value.ToString();                     // ID  de estacion
                    value9 = row.Cells[3].Value.ToString();                    // Hora de revision


                    SqlCeCommand cm = new SqlCeCommand("SELECT *FROM pagina WHERE Id_pag = @id", datos.cn);
                    cm.Parameters.AddWithValue("@id", value1);
                    SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cm.ExecuteReader();

                   // MessageBox.Show(dt.Rows[0][0].ToString().Trim() + "  1- " + dt.Rows[0][1].ToString().Trim() + " 2- " + dt.Rows[0][2].ToString().Trim() + " 3- " + dt.Rows[0][3].ToString().Trim() + " 4- " + dt.Rows[0][4].ToString().Trim() + " 5- " + dt.Rows[0][5].ToString().Trim() + " 6- " + dt.Rows[0][6].ToString().Trim() + " 7- " + dt.Rows[0][7].ToString().Trim());
                    value2 = dt.Rows[0][1].ToString().Trim();                   //nombre de la estacion      
                    value3 = dt.Rows[0][2].ToString().Trim();                   //tipo
                    value4 = dt.Rows[0][3].ToString().Trim();                   //link de la pagina

                    value6 = dt.Rows[0][5].ToString().Trim();                   //gasolinera - grupo
                    value7 = dt.Rows[0][6].ToString().Trim();                   //Link gasolinera
                    value8 = dt.Rows[0][7].ToString().Trim();                   //permiso 

                    if (dt.Rows[0][4].ToString().Trim() == "cdf")
                    {
                        value5 = "Control de flotillas";
                    }
                    else
                    {
                        value5 = "Factrua electronica";
                    }

                    var Asunto = "";
                    if (value3 == "tercero")
                    {
                        Asunto = "Monitoreo de pagina web B: Link caido - " + value2;
                    }
                    else
                    {
                        Asunto = "Monitoreo de pagina web A: Link caido - " + value2;

                    }
                    var Mensaje = "<head><meta http-equiv=\"Content - Type\" content=\"text / html; charset = utf - 8\"/> </head>" +
                                   "Detalles de la pagina: " +
                                   " <br />Id: " + value1 +
                                   " <br /> Nombre: " + value2 +
                                   " <br /> Fecha y hora de la revision: " + fecha + " " + value9 +
                                   " <br /> Enlace de la pagina: " + value4 +
                                   " <br /> Servicio: " + value5 +
                                   " <br /> Grupo gasolinero: " + value6 +
                                   " <br /> Link de grupo gasolinero: " + value7 +
                                   " <br /> Permiso: " + value8;

                    var Receptor = ConfigurationManager.AppSettings["soporte"];
                   // MessageBox.Show(Mensaje);
                    //MessageBox.Show(value3);
                    string Emisor = ConfigurationManager.AppSettings["emisor"];
                    string Password = ConfigurationManager.AppSettings["password"];
                    int puerto = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                    string host = ConfigurationManager.AppSettings["host"];
                    MessageBox.Show("Levantando ticket.");
                    enviarCorreo(Emisor, Password, Mensaje, Asunto, Receptor, puerto, host);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El mensaje no fue enviado."+ ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cambios();
        }

        public void general()
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("SELECT a.Id_pag AS ID, b.gasolinera AS GRUPO, a.nombre AS NOMBRE, a.hora AS HORA, b.servicio AS TIPO, b.linkGas AS [ENLACE PRINCIPAL] FROM chec a INNER JOIN pagina b ON a.id_pag = b.Id_pag WHERE fecha = '" + DateTime.Now.ToString("dd/MM/yy") + "' and estado = 'true' ORDER BY b.gasolinera", datos.cn);
                //  cm.Parameters.AddWithValue("@id", txt_idbusc.Text);
                //  cm.Parameters.AddWithValue("@nombre", txt_idbusc.Text);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtg_vista.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos que mostrar");

                    btn_crm.Visible = false;
                }
                else
                {
                    btn_crm.Visible = true;
                }


                // dtg_vista.DataSource = ds.Tables["chec"].DefaultView;
                dtg_vista.RowHeadersVisible = false;
                dtg_vista.AllowUserToAddRows = false;
                dtg_vista.AllowUserToDeleteRows = false;
                dtg_vista.AllowUserToOrderColumns = false;
                dtg_vista.AllowUserToResizeColumns = false;
                dtg_vista.AllowUserToResizeRows = false;
                // dtg_vista.AutoResizeColumns();
                dtg_vista.BorderStyle = BorderStyle.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void clientes()
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("SELECT a.Id_pag AS ID, b.gasolinera AS GRUPO, a.nombre AS NOMBRE, a.hora AS HORA, b.servicio AS TIPO, b.linkGas AS [ENLACE PRINCIPAL] FROM chec a INNER JOIN pagina b ON a.id_pag = b.Id_pag WHERE fecha = '" + DateTime.Now.ToString("dd/MM/yy") + "' and estado = 'true' and a.servicio = 'cliente' ORDER BY b.gasolinera", datos.cn);
                //  cm.Parameters.AddWithValue("@id", txt_idbusc.Text);
                //  cm.Parameters.AddWithValue("@nombre", txt_idbusc.Text);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtg_vista.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos que mostrar");

                    btn_crm.Visible = false;
                }
                else
                {
                    dtg_vista.Columns[1].Width = 200;

                    btn_crm.Visible = true;

                }
                // dtg_vista.DataSource = ds.Tables["chec"].DefaultView;
                dtg_vista.RowHeadersVisible = false;
                dtg_vista.AllowUserToAddRows = false;
                dtg_vista.AllowUserToDeleteRows = false;
                dtg_vista.AllowUserToOrderColumns = false;
                dtg_vista.AllowUserToResizeColumns = false;
                dtg_vista.AllowUserToResizeRows = false;
                // dtg_vista.AutoResizeColumns();
                dtg_vista.BorderStyle = BorderStyle.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void terceros()
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("SELECT a.Id_pag AS ID, b.gasolinera AS GRUPO, a.nombre AS NOMBRE, a.hora AS HORA, b.servicio AS TIPO, b.linkGas AS [ENLACE PRINCIPAL] FROM chec a INNER JOIN pagina b ON a.id_pag = b.Id_pag WHERE fecha = '" + DateTime.Now.ToString("dd/MM/yy") + "' and estado = 'true' and a.servicio = 'tercero' ORDER BY b.gasolinera", datos.cn);
                //  cm.Parameters.AddWithValue("@id", txt_idbusc.Text);
                //  cm.Parameters.AddWithValue("@nombre", txt_idbusc.Text);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtg_vista.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos que mostrar");

                    btn_crm.Visible = false;
                }
                else
                {
                    dtg_vista.Columns[1].Width = 200;

                    btn_crm.Visible = true;

                }
                // dtg_vista.DataSource = ds.Tables["chec"].DefaultView;
                dtg_vista.RowHeadersVisible = false;
                dtg_vista.AllowUserToAddRows = false;
                dtg_vista.AllowUserToDeleteRows = false;
                dtg_vista.AllowUserToOrderColumns = false;
                dtg_vista.AllowUserToResizeColumns = false;
                dtg_vista.AllowUserToResizeRows = false;
                // dtg_vista.AutoResizeColumns();
                dtg_vista.BorderStyle = BorderStyle.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cambios()
        {
            if (rdb_general.Checked == true)
            {
                general();
            }
            else if (rdb_clientes.Checked == true)
            {
                clientes();
            }
            else if (rdb_terceros.Checked == true)
            {
                terceros();
            }
        }

        private void rdb_clientes_CheckedChanged(object sender, EventArgs e)
        {
            cambios();
        }

        private void rdb_terceros_CheckedChanged(object sender, EventArgs e)
        {
            cambios();
        }

        public void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, int puerto, string host)
        {
            MailMessage correos = new MailMessage();
            SmtpClient envios = new SmtpClient();

            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = (mensaje);
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                //Datos importantes no modificables para tener acceso a las cuentas
                envios.Host = host;
                envios.Port = puerto;
                envios.EnableSsl = true;
                envios.Send(correos);
                correos.Attachments.Clear();
                correos.To.Clear();
                MessageBox.Show("Ticket enviado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }
    }
}
