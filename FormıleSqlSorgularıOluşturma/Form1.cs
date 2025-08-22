using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormıleSqlSorgularıOluşturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ABDULLAH;Initial Catalog=DbOgrenciNot;Integrated Security=True;Encrypt=False;");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sorgu;
                sorgu = richTextBox1.Text;
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorgunuzu kontrol ediniz...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkleSilGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;
            
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM TBL_NOTLAR", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorgunuzu kontrol ediniz...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
