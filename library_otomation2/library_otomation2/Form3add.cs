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
    public partial class Form3add : Form
    {
        public Form3add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-9CITR9N\\SQLEXPRESS;Initial Catalog=kütüphane;Integrated Security=True";

            string Ad = textBox1.Text;
            string Soyad = textBox2.Text;
            string Sayfa = textBox3.Text;

            string Tür = textBox4.Text;
            string Basım = textBox5.Text;
            

            string query = "INSERT INTO table3 (kitapAd,kitapYazar,kitapSayfa,kitapTürü,basımTarihi) VALUES (@ad,@soyad,@sayfa,@tür,@bt)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parametrelerin eklenmesi
                    command.Parameters.AddWithValue("@ad", Ad);
                    command.Parameters.AddWithValue("@soyad", Soyad);
                    command.Parameters.AddWithValue("@sayfa", Sayfa);

                    command.Parameters.AddWithValue("@tür", Tür);
                    command.Parameters.AddWithValue("@bt", Basım);
                    

                    try
                    {
                        // Bağlantıyı açma ve komutu çalıştırma
                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Üye başarıyla eklendi.");

                        // Alanları temizleme
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Üye eklenirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }
    }
}
