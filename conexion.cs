using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace Checador
{
    class conexion{
        
        public string cadena = @"Data Source = " + Directory.GetCurrentDirectory() + @"\db\CGCheck.sdf; Password = 1234";
        public SqlCeConnection cn;
        public SqlCeCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlCeDataAdapter da;

        private void conectar()
        {
            cn = new SqlCeConnection(cadena);
        }
        public conexion()
        {
            conectar();
        }
        public DataTable select(string tabla)
        {
            string sql = "select  * from " + tabla;
            da = new SqlCeDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
        public DataTable select_condicion(string tabla, string condicion)
        {
            string sql = "select  * from " + tabla + "where" + condicion;
            da = new SqlCeDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
        public void consulta(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SqlCeDataAdapter(sql, cn);
            cmb = new SqlCeCommandBuilder(da);
            da.Fill(ds, tabla);
        }
    }
}
