using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL_MrPhuong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showDataSet();
        }
        private void Show()
        {
            string connstring = @"Data Source=DESKTOP-1GG0LVP;Initial Catalog=QLSV;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connstring);
            string query = textBox1.Text;
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("MSSV"),
                    new DataColumn("NameSV"),
                    new DataColumn("Gender", typeof(bool)),
                    new DataColumn("NS", typeof(DateTime)),
                    new DataColumn("ID_Lop", typeof(int))
            });
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["MSSV"] = r["MSSV"];
                dr["NameSV"] = r["NameSV"];
                dr["Gender"] = r["Gender"];
                dr["NS"] = r["NS"];
                dr["ID_Lop"] = r["ID_Lop"];
                dt.Rows.Add(dr);
            }
            //textBox1.Text = ((int)(cmd.ExecuteScalar())).ToString();
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public void showDataSet()
        {
            string connstring = @"Data Source=DESKTOP-1GG0LVP;Initial Catalog=QLSV;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connstring);
            string query = "select * from SV where MSSV = @M";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@M", SqlDbType.NVarChar);
            cmd.Parameters["@M"].Value = textBox1.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
