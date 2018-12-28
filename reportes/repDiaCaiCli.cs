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

namespace Checador
{
    public partial class repDiaCaiCli : Form
    {
        conexion datos = new conexion();
        public repDiaCaiCli()
        {
            InitializeComponent();
        }

        private void pag_caidasdia_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("SELECT a.Id_pag AS ID,b.gasolinerA AS GRUPO, a.nombre AS NOMBRE, b.servicio AS TIPO, a.hora AS HORA, b.enlace AS ENLACE, b.linkGas AS [INDEX] FROM chec a INNER JOIN pagina b ON a.id_pag = b.Id_pag WHERE fecha = '" + DateTime.Now.ToString("dd/MM/yy") + "' and estado = 'true' and b.tipo = 'cliente' ORDER BY b.gasolinera ", datos.cn);
                //  cm.Parameters.AddWithValue("@id", txt_idbusc.Text);
                //  cm.Parameters.AddWithValue("@nombre", txt_idbusc.Text);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtg_vista.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos que mostrar");
                    btn_guardar.Visible = false;
                    btn_enviar.Visible = false;
                }
                else
                {
                    dtg_vista.Columns[0].Width = 60;
                    dtg_vista.Columns[1].Width = 150;
                    dtg_vista.Columns[2].Width = 200;
                    dtg_vista.Columns[3].Width = 50;
                    dtg_vista.Columns[4].Width = 70;
                    
                    btn_guardar.Visible = true;
                    btn_enviar.Visible = true;

                }
                datos.cn.Close();
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

                Chunk chunk = new Chunk("Reporte diario de paginas caidas para usuarios de tipo Cliente", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
                doc.Add(new Paragraph(chunk));
                doc.Add(new Paragraph("                       "));
                // doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------------------------"));
                doc.Add(new Paragraph("Reporte con los datos generados de paginas caidas de Clientes."));
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
                        Chunk portText = new Chunk("link");

                        if (j == 5 )
                        {
                            try
                            {
                               
                                portText.SetAnchor(new Uri(dtg_vista[j, i].Value.ToString()));
                                Paragraph p = new Paragraph();
                                p.Add(portText);
                                datatable.AddCell(new Phrase(p));
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                         }else if (j == 6)
                        {
                           // MessageBox.Show("es", Convert.ToString( j));
                            try
                            {
                              //MessageBox.Show(dtg_vista[j, i].Value.ToString());
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

                        Chunk chunk = new Chunk("Reporte diario de paginas caidas para usuarios de tipo Cliente", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
                        doc.Add(new Paragraph(chunk));
                        doc.Add(new Paragraph("                       "));
                        // doc.Add(new Paragraph("                       "));
                        doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------------------------"));
                        doc.Add(new Paragraph("Reporte con los datos generados de paginas caidas de Clientes."));
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
                System.Diagnostics.Process.Start("Chrome.exe", dtg_vista.Rows[e.RowIndex].Cells[4].Value.ToString());

            }
            catch 
            {
                try
                {
                    System.Diagnostics.Process.Start( dtg_vista.Rows[e.RowIndex].Cells[4].Value.ToString());

                }
                catch (Exception exx)
                {
                    MessageBox.Show("A ocurrido un erro al abrir el navegador, " + exx.Message);
                }
            }
        }
    }
}
