using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using System.Net;
using System.Data.SqlServerCe;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading;

namespace Checador
{
    public partial class inicio : Form
    {


        //variables para el checado------
        DateTime dia = DateTime.Now;
        conexion datos = new conexion();
        String enlace, nombre, id, tipo, servicio; //-------------------------------- variables para guardar los datos de la consulta que se realiza a la pagina
        string query;
        string prueva = "";
        string tipAna = "";             //variable para el tipo de analisis
        int prueva2;
        string prueva3 = "";
        int mes = DateTime.Now.Month;
        int año = DateTime.Now.Year;

        //variables para el checado------

        public inicio()
        {
            InitializeComponent();
        }
        private void paginasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anadir_pag anadir_pag = new Anadir_pag();
            anadir_pag.ShowDialog();
        }
        private void editarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarEliminar editar = new EditarEliminar();
            editar.ShowDialog();
        }

        public void btn_checar_Click(object sender, EventArgs e)
        {
            if (rb_todos.Checked == false)
            {
                query = "";
                MessageBox.Show("");
            }

            ArrayList lalista = new ArrayList();
            ArrayList lalista_numeros = new ArrayList();
            ArrayList lalista_version = new ArrayList();
            Stopwatch stopWatch = new Stopwatch();


            label2.Text = "";
            if (accesoainternet() == true)
            {
                progressBar1.Visible = true;
                label2.Text = "Realizando analisis ...";
                stopWatch.Start();
                SqlCeCommand cm1 = new SqlCeCommand("SELECT ID_pag, nombre, enlace FROM pagina", datos.cn);
                SqlCeDataAdapter da1 = new SqlCeDataAdapter(cm1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                cm1.ExecuteReader();

                if (dt1.Rows.Count > 0)
                {
                    try
                    {
                        SqlCeCommand cm3 = new SqlCeCommand("SELECT COUNT(id_pag) FROM chec WHERE fecha = @fecha", datos.cn);
                        cm3.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"));
                        SqlCeDataAdapter da3 = new SqlCeDataAdapter(cm3);
                        DataTable dt3 = new DataTable();
                        da3.Fill(dt3);
                        cm3.ExecuteReader();
                        // MessageBox.Show(dt3.Rows[0][0].ToString().Trim());
                        int cantidad = Convert.ToInt16(dt3.Rows[0][0].ToString().Trim());
                        if (cantidad > 0)
                        {
                            SqlCeCommand cm4 = new SqlCeCommand("DELETE FROM chec WHERE fecha = @fecha", datos.cn);
                            cm4.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"));
                            SqlCeDataAdapter da4 = new SqlCeDataAdapter(cm4);
                            DataTable dt4 = new DataTable();
                            da4.Fill(dt4);
                            cm4.ExecuteReader();
                            // MessageBox.Show("haber");
                        }
                        else
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        for (int i = 0; i <= lalista.Count;)
                        {
                            enlace = dt1.Rows[i][2].ToString().Trim();
                            lalista.Add(enlace);
                            i++;
                        }

                    }
                    catch
                    {

                    }
                    var tamaño = lalista.Count;
                    var progreso = 100 / tamaño;
                    var progreso_acu = 0;

                    progressBar1.Minimum = 1;
                    progressBar1.Maximum = tamaño;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;

                    SqlCeCommand cm = new SqlCeCommand("SELECT ID_pag, nombre, enlace, tipo, servicio FROM pagina", datos.cn);
                    SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cm.ExecuteReader();


                    for (int i = 0; i < tamaño;)
                    {

                        id = dt.Rows[i][0].ToString().Trim();
                        nombre = dt.Rows[i][1].ToString().Trim();
                        enlace = dt.Rows[i][2].ToString().Trim();
                        tipo = dt.Rows[i][4].ToString().Trim();
                        servicio = dt.Rows[i][3].ToString().Trim();

                        //lalista.Add(enlace);
                        progreso_acu = progreso_acu + progreso;
                        progressBar1.Text = Convert.ToString(progreso_acu);
                        progressBar1.PerformStep();

                        try
                        {
                            //Creando la HttpWebRequest
                            HttpWebRequest request = WebRequest.Create(enlace) as HttpWebRequest;
                            //Metodo de solicitud HEAD, (tambien se puede usar get).
                            request.Method = "HEAD";
                            //Obteniendo la respuesta.
                            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                            //Retorna TRUE si el codio de estatus es == 200
                            response.Close();
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                //-----IF DENTRO DEL IF STATUSCODE OK------------------------------
                                if (extraer_licencia(extraer_contenido(enlace)) == "false")
                                {
                                    prueva = "Caida";
                                    prueva2 = 1;
                                    lalista_numeros.Add(1);
                                    string contenido = (extraer_contenido(enlace));
                                    prueva3 = extraer_version(contenido);
                                    lalista_version.Add(prueva3);
                                    if ((id == "E00016") || (id == "E00023") || (id == "E08869") || (id == "E00032"))
                                    {
                                        // MessageBox.Show("enlace" + ", " + enlace + ", " + nombre + ", " + prueva + ", " + prueva2 + ", " + prueva3, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        //MessageBox.Show(contenido);
                                    }
                                }
                                else
                                {

                                    prueva = "Estable";
                                    prueva2 = 0;
                                    lalista_numeros.Add(0);
                                    string contenido = (extraer_contenido(enlace));
                                    prueva3 = extraer_version(contenido);
                                    lalista_version.Add(prueva3);
                                    if ((id == "E00016") || (id == "E00023") || (id == "E08869") || (id == "E00032"))
                                    {
                                        //   MessageBox.Show("enlace" + ", " + enlace + ", " + nombre + ", " + prueva + ", " + prueva2 + ", " + prueva3, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        // MessageBox.Show(contenido);
                                    }
                                }

                            }
                        }

                        catch
                        {
                            //    MessageBox.Show("fallo");
                            //Cualquier otra ecepcion retornara false.
                            prueva = "Caida";
                            prueva2 = 1;
                            lalista_numeros.Add(1);
                            prueva3 = "N/A";
                            //lalista_version.Add(prueva3);
                        }
                        try
                        {
                            SqlCeCommand cm2 = new SqlCeCommand("INSERT INTO chec(id_pag, fecha, dia, estado, version, nombre, tipo, servicio, hora) VALUES(@id, @fecha, @dia, @estado, @version, @nombre, @tipo, @servicio, @hora)", datos.cn);
                            cm2.Parameters.AddWithValue("@id", id);
                            cm2.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"));
                            cm2.Parameters.AddWithValue("@dia", Convert.ToString(dia.ToString("dddd", new CultureInfo("es-ES"))));
                            cm2.Parameters.AddWithValue("@estado", prueva2);
                            cm2.Parameters.AddWithValue("@version", prueva3);
                            cm2.Parameters.AddWithValue("@nombre", nombre);
                            cm2.Parameters.AddWithValue("@tipo", tipo);
                            cm2.Parameters.AddWithValue("@servicio", servicio);
                            cm2.Parameters.AddWithValue("@hora", DateTime.Now.ToString("hh:mm:ss"));

                            SqlCeDataAdapter da2 = new SqlCeDataAdapter(cm2);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            // cm2.ExecuteReader();
                            i++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    tamaño = 0;

                    //Final del For----------------------------------------------------

                    Cursor.Current = Cursors.Default;
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}',{1:00}''",
                    ts.Minutes, ts.Seconds);
                    label2.Text = "Analisis finalizado en: " + elapsedTime;
                    elapsedTime = "";
                    //progressBar1.Visible = false;

                    btn_checar.Enabled = false;
                    btn_excel.Enabled = true;
                    chb_analisis.Enabled = true;
                    btn_paginasCaidas.Enabled = true;
                    btn_version.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("Compruebe su conexión a internet", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void inicio_Load(object sender, EventArgs e)
        {
            try
            {
                //Creamos el delegado 
                ThreadStart delegado = new ThreadStart(carExcel);
                //Creamos la instancia del hilo 
                Thread hilo = new Thread(delegado);
                //Iniciamos el hilo 
                hilo.Start();
                gb_ana.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                datos.cn.Open();
                SqlCeCommand cm = new SqlCeCommand("SELECT COUNT(id_pag) FROM chec WHERE fecha = @fecha", datos.cn);
                cm.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"));
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cm.ExecuteReader();
                // MessageBox.Show(dt.Rows[0][0].ToString().Trim());
                int cantidad = Convert.ToInt16(dt.Rows[0][0].ToString().Trim());
                if (cantidad > 0)
                {
                    chb_analisis.Enabled = true;
                    btn_checar.Enabled = false;
                    btn_excel.Enabled = true;

                    btn_paginasCaidas.Enabled = true;
                    btn_version.Enabled = true;
                }
                else
                {
                    btn_excel.Enabled = false;
                    chb_analisis.Enabled = false;

                    btn_paginasCaidas.Enabled = false;
                    btn_version.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cambiarRutaDeAlmacenamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anadirCorreo inicio = new anadirCorreo();
            inicio.ShowDialog();
        }

        private void pb_controlgas_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void editarEliminarCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editarEliminarCorreo inicio = new editarEliminarCorreo();
            inicio.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            /*pruebas nueva = new pruebas();
            nueva.Show();*/
            DateTime thisDate1 = DateTime.Now;
            Console.WriteLine("Today is " + thisDate1.ToString("MM dd, yy") + ".");
        }

        private void reporteMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repDiario rep1 = new repDiario();
            rep1.ShowDialog();
        }

        private void reporteDiarioDePaginasCaidasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            crear inicio = new crear();
            inicio.ShowDialog();
        }

        private void reporteDiarioDePaginasCaidasClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repDiaCaiTer nd = new repDiaCaiTer();
            nd.ShowDialog();
        }

        private void reporteTercerosYClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repDiaCaidas ini = new repDiaCaidas();
            ini.ShowDialog();
        }

        private void reporteDiarioDePaginasCaidasTercerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repDiaCaiCli dd = new repDiaCaiCli();
            dd.ShowDialog();
        }

        private void reporteConsultaDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repConDia con = new repConDia();
            con.ShowDialog();
        }

        private void reporteDiarioDePaginasActivasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDiarioGeneralDePaginasCaidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repDiaActivas inicio = new repDiaActivas();
            inicio.ShowDialog();
        }

        private void reporteDiarioDePaginasActivasClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repDiaActCli inicio = new repDiaActCli();
            inicio.ShowDialog();
        }

        private void reporteDiarioDePaginasActivasTercerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repDiaActTer inicio = new repDiaActTer();
            inicio.ShowDialog();
        }

        private void reporteDePaginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repPagina pagina = new repPagina();
            pagina.ShowDialog();
        }

        private void chb_analisis_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_analisis.Checked == true)
            {
                btn_checar.Enabled = true;
            }
            else
            {
                btn_checar.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public static string extraer_version(string codigo)
        {
            string s2 = "Versión";
            bool b = codigo.Contains(s2);
            if (b)
            {
                int index = codigo.IndexOf(s2);
                if (index >= 0)
                    Console.WriteLine("'{0} begins at character position {1}",
                                      s2, index + 1);
                var s3 = codigo.Substring(index, 13);
                return s3;
            }
            else
            {
                if (b)
                {
                    int index = codigo.IndexOf(s2);
                    if (index >= 0)
                        Console.WriteLine("'{0} begins at character position {1}",
                                          s2, index + 1);
                    var s3 = codigo.Substring(index, 13);
                    return s3;
                }
                else
                {
                    var s3 = "N/A";
                    return s3;
                }
            }
        }

        //-----fUNCIÓN PARA SABER SI LA LICENCIA ESTA VENCIDA----- 
        public static string extraer_licencia(string codigo)
        {
            string s2 = "Licencia Inválida";
            bool b = codigo.Contains(s2);
            if (b)
            {
                return "false";
            }
            else
            {
                if (b)
                {
                    return "false";
                }
                else
                {
                    return "true";
                }
            }
        }
        //-----fUNCIÓN PARA SABER SI LA LICENCIA ESTA VENCIDA----- 

        public string extraer_contenido(string url)
        {
            //Envío petición y recibo la respuesta
            Uri uri = new Uri(url);
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(uri);
            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();
            //Proceso respuesta y convierto el flujo de llegada en cadena de caracteres
            System.IO.StreamReader input = new System.IO.StreamReader(res.GetResponseStream());

            char[] chrBuff = new char[256];
            int intLen = 0;
            string strSource = "";

            do
            {
                intLen = input.Read(chrBuff, 0, 256);
                string strBuff = new string(chrBuff, 0, intLen);
                strSource += strBuff;
            } while (intLen > 0);

            return strSource;
        }

        private bool accesoainternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }


        //public void automatico()
        //{
        //    ArrayList lalista = new ArrayList();
        //    ArrayList lalista_numeros = new ArrayList();
        //    ArrayList lalista_version = new ArrayList();
        //    Stopwatch stopWatch = new Stopwatch();

        //    MessageBox.Show("Entro en automatico");

        //    label2.Text = "";
        //    if (accesoainternet() == true)
        //    {

        //        progressBar1.Visible = true;
        //        label2.Text = "Realizando analisis  ...";
        //        stopWatch.Start();
        //        SqlCeCommand cm1 = new SqlCeCommand("SELECT ID_pag, nombre, enlace FROM pagina", datos.cn);
        //        SqlCeDataAdapter da1 = new SqlCeDataAdapter(cm1);
        //        DataTable dt1 = new DataTable();
        //        da1.Fill(dt1);
        //        cm1.ExecuteReader();

        //        if (dt1.Rows.Count > 0)
        //        {
        //            try
        //            {
        //                SqlCeCommand cm3 = new SqlCeCommand("SELECT COUNT(id_pag) FROM chec WHERE fecha = @fecha", datos.cn);
        //                cm3.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"));
        //                SqlCeDataAdapter da3 = new SqlCeDataAdapter(cm3);
        //                DataTable dt3 = new DataTable();
        //                da3.Fill(dt3);
        //                cm3.ExecuteReader();
        //                // MessageBox.Show(dt3.Rows[0][0].ToString().Trim());
        //                int cantidad = Convert.ToInt16(dt3.Rows[0][0].ToString().Trim());
        //                if (cantidad > 0)
        //                {
        //                    SqlCeCommand cm4 = new SqlCeCommand("DELETE FROM chec WHERE fecha = @fecha", datos.cn);
        //                    cm4.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"));
        //                    SqlCeDataAdapter da4 = new SqlCeDataAdapter(cm4);
        //                    DataTable dt4 = new DataTable();
        //                    da4.Fill(dt4);
        //                    cm4.ExecuteReader();
        //                  //  MessageBox.Show("haber");
        //                }
        //                else
        //                {
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }


        //            try
        //            {
        //                for (int i = 0; i <= lalista.Count;)
        //                {
        //                    enlace = dt1.Rows[i][2].ToString().Trim();
        //                    lalista.Add(enlace);
        //                    i++;
        //                }

        //            }
        //            catch
        //            {

        //            }
        //            var tamaño = lalista.Count;
        //            var progreso = 100 / tamaño;
        //            var progreso_acu = 0;

        //            progressBar1.Minimum = 1;
        //            progressBar1.Maximum = tamaño;
        //            progressBar1.Value = 1;
        //            progressBar1.Step = 1;

        //            SqlCeCommand cm = new SqlCeCommand("SELECT ID_pag, nombre, enlace, tipo, servicio FROM pagina", datos.cn);
        //            SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            cm.ExecuteReader();


        //            for (int i = 0; i < tamaño;)
        //            {

        //                id = dt.Rows[i][0].ToString().Trim();
        //                nombre = dt.Rows[i][1].ToString().Trim();
        //                enlace = dt.Rows[i][2].ToString().Trim();
        //                tipo = dt.Rows[i][4].ToString().Trim();
        //                servicio = dt.Rows[i][3].ToString().Trim();

        //                lalista.Add(enlace);
        //                progreso_acu = progreso_acu + progreso;
        //                progressBar1.Text = Convert.ToString(progreso_acu);
        //                progressBar1.PerformStep();

        //                try
        //                {
        //                    //Creando la HttpWebRequest
        //                    HttpWebRequest request = WebRequest.Create(enlace) as HttpWebRequest;
        //                    //Metodo de solicitud HEAD, (tambien se puede usar get).
        //                    request.Method = "HEAD";
        //                    //Obteniendo la respuesta.
        //                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //                    //Retorna TRUE si el codio de estatus es == 200
        //                    response.Close();

        //                    if (response.StatusCode == HttpStatusCode.OK)
        //                    {
        //                        //-----IF DENTRO DEL IF STATUSCODE OK------------------------------
        //                        if (extraer_licencia(extraer_contenido(enlace)) == "false")
        //                        {
        //                            //MessageBox.Show("Licencia desactualizada" + ", "+ enlace + ", "+nombre, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                            prueva = "Caida";
        //                            prueva2 = 1;
        //                            lalista_numeros.Add(1);
        //                            string contenido = (extraer_contenido(enlace));
        //                            prueva3 = extraer_version(contenido);
        //                            lalista_version.Add(prueva3);
        //                        }
        //                        else
        //                        {
        //                            prueva = "Estable";
        //                            prueva2 = 0;
        //                            lalista_numeros.Add(0);
        //                            string contenido = (extraer_contenido(enlace));
        //                            prueva3 = extraer_version(contenido);
        //                            lalista_version.Add(prueva3);
        //                        }

        //                    }
        //                }

        //                catch
        //                {
        //                    //Cualquier otra ecepcion retornara false.
        //                    prueva = "Caida";
        //                    prueva2 = 1;
        //                    lalista_numeros.Add(1);
        //                    prueva3 = "N/A";
        //                    //lalista_version.Add(prueva3);
        //                }
        //                try
        //                {
        //                    SqlCeCommand cm2 = new SqlCeCommand("INSERT INTO chec(id_pag, fecha, dia, estado, version, nombre, tipo, servicio, hora) VALUES(@id, @fecha, @dia, @estado, @version, @nombre, @tipo, @servicio, @hora)", datos.cn);
        //                    cm2.Parameters.AddWithValue("@id", id);
        //                    cm2.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"));
        //                    cm2.Parameters.AddWithValue("@dia", Convert.ToString(dia.ToString("dddd", new CultureInfo("es-ES"))));
        //                    cm2.Parameters.AddWithValue("@estado", prueva2);
        //                    cm2.Parameters.AddWithValue("@version", prueva3);
        //                    cm2.Parameters.AddWithValue("@nombre", nombre);
        //                    cm2.Parameters.AddWithValue("@tipo", tipo);
        //                    cm2.Parameters.AddWithValue("@servicio", servicio);
        //                    cm2.Parameters.AddWithValue("@hora", DateTime.Now.ToString("hh:mm:ss"));

        //                    SqlCeDataAdapter da2 = new SqlCeDataAdapter(cm2);
        //                    DataTable dt2 = new DataTable();
        //                    da2.Fill(dt2);
        //                    // cm2.ExecuteReader();
        //                    i++;
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message);
        //                }

        //            }

        //            tamaño = 0;

        //            //Final del For----------------------------------------------------
        //            Cursor.Current = Cursors.Default;
        //            stopWatch.Stop();
        //            TimeSpan ts = stopWatch.Elapsed;
        //            string elapsedTime = String.Format("{0:00}',{1:00}''",
        //            ts.Minutes, ts.Seconds);
        //            label2.Text = "Analisis finalizado en: " + elapsedTime;
        //            elapsedTime = "";
        //            //progressBar1.Visible = false;

        //            btn_checar.Enabled = false;
        //            btn_excel.Enabled = true;
        //            chb_analisis.Enabled = true;

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Compruebe su conexión a internet", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            crrm ne = new crrm();
            ne.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGas ss = new addGas();
            ss.ShowDialog();
        }

        private void gasolineraToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void permisoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gasolineraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addGas ee = new addGas();
            ee.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permiso nne = new Permiso();
            nne.Show();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            crmVersion nn = new crmVersion();
            nn.Show();
        }

        private void btn_ayuda_Click(object sender, EventArgs e)
        {
            ayuda ayuda = new ayuda();
            ayuda.ShowDialog();
        }

        public void carExcel()
        {
            var primero = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if (primero == hoy)
            {
                MessageBox.Show("Hoy es primero de mes, por lo que se procedera a llenar el archivo excel para clientes y terceros con los datos de cada pagina, si tiene abiertos los archivo cierrelos.");
                llenCli();
                llenTer();

            }
        }

        public string NombreMes(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("ES-es", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }


        public void llenCli()
        {
            //-------------------------------------------------------------------------------------------- Funcion para llenar clientes
            //--------------------------------------------------------------------------------------------------------------------------------------------- llenado para clientes
            try
            {
                string fileName = Directory.GetCurrentDirectory() + @"\archivos\clientes.xlsx";

                var workbook = new XLWorkbook(fileName);
                var worksheet = workbook.Worksheet(NombreMes(mes));
                int posicion = 3;

                string id_checar = worksheet.Cell(posicion, 3).Value.ToString();

                SqlCeCommand cm1 = new SqlCeCommand("SELECT gasolinera, nombre, id_pag FROM pagina WHERE tipo = 'cliente'", datos.cn);
                //   cm1.Parameters.AddWithValue("@id", id_checar);
                SqlCeDataAdapter da1 = new SqlCeDataAdapter(cm1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                for (int r = 0; r < dt1.Rows.Count; r++)
                {
                    //     MessageBox.Show(dt1.Rows[r][0].ToString().Trim() + "     " + dt1.Rows[r][1].ToString().Trim() + "     " + dt1.Rows[r][2].ToString().Trim());
                    worksheet.Cell("A" + posicion).Value = dt1.Rows[r][0].ToString().Trim();
                    worksheet.Cell("B" + posicion).Value = dt1.Rows[r][1].ToString().Trim();
                    worksheet.Cell("C" + posicion).Value = dt1.Rows[r][2].ToString().Trim();
                    posicion++;
                }
                workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\clientes.xlsx");
                MessageBox.Show("Finalizo de ingresar datos de clientes a documento Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void llenTer()
        {
            //--------------------------------------------------------------------------------------------------------------------------------------------- llenado para terceros
            try
            {
                string fileName = Directory.GetCurrentDirectory() + @"\archivos\terceros.xlsx";

                var workbook = new XLWorkbook(fileName);
                var worksheet = workbook.Worksheet(NombreMes(mes));
                int posicion = 3;
                string id_checar = worksheet.Cell(posicion, 3).Value.ToString();

                SqlCeCommand cm1 = new SqlCeCommand("SELECT gasolinera, nombre, id_pag FROM pagina WHERE tipo = 'tercero'", datos.cn);
                //   cm1.Parameters.AddWithValue("@id", id_checar);
                SqlCeDataAdapter da1 = new SqlCeDataAdapter(cm1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                for (int r = 0; r < dt1.Rows.Count; r++)
                {
                    //MessageBox.Show(dt1.Rows[r][0].ToString().Trim() + "     " + dt1.Rows[r][1].ToString().Trim() + "     " + dt1.Rows[r][2].ToString().Trim());
                    worksheet.Cell("A" + posicion).Value = dt1.Rows[r][0].ToString().Trim();
                    worksheet.Cell("B" + posicion).Value = dt1.Rows[r][1].ToString().Trim();
                    worksheet.Cell("C" + posicion).Value = dt1.Rows[r][2].ToString().Trim();
                    posicion++;
                }
                workbook.SaveAs(Directory.GetCurrentDirectory() + @"\archivos\terceros.xlsx");
                MessageBox.Show("Finalizo de ingresar datos de Terceros a documento Excel");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
