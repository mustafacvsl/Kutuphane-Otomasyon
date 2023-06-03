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

namespace library_otomation2
{
    public partial class FormBook : Form
    {
        public FormBook()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-9CITR9N\\SQLEXPRESS;Initial Catalog=kütüphane;Integrated Security=True";
            string query = "SELECT * FROM table3";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Veri tablosu oluşturma
                    DataTable dataTable = new DataTable();

                    try
                    {
                        // Veri adaptörü aracılığıyla verileri doldurma
                        adapter.Fill(dataTable);

                        // DataGridView'e veri tablosunu atama
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veriler getirilirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}