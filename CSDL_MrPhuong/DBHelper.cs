using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_MrPhuong
{
    class DBHelper
    {
        private SqlConnection conn;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string conns = @"Data Source=DESKTOP-1GG0LVP;Initial Catalog=QLSV;Integrated Security=True";
                    _Instance = new DBHelper(conns);
                }
                return _Instance;
            }
            private set { }
        }
        private static DBHelper _Instance;
        private DBHelper(string s)
        {
            conn = new SqlConnection(s);
        }
        public DataTable GetRecords(string _query)
        {
            string query = _query;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public void ExcutedDB(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
