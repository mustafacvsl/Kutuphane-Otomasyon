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
    public partial class uyeEkleForm : Form
    {
        public uyeEkleForm()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Close();
        }

        private void uyeEkleForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-9CITR9N\\SQLEXPRESS;Initial Catalog=kütüphane;Integrated Security=True";

            string tc = textBox1.Text;
            string ad = textBox2.Text;
            string soyad = textBox3.Text;

            string adres = textBox4.Text;
            string yas = textBox5.Text;
            string email = textBox6.Text;

            string query = "INSERT INTO table1 (TC,AD,SOYAD,ADRES,YAŞ,GMAİL) VALUES (@tc,@ad,@soyad,@adres,@yaş,@gmail)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parametrelerin eklenmesi
                    command.Parameters.AddWithValue("@tc", tc);
                    command.Parameters.AddWithValue("@ad", ad);
                    command.Parameters.AddWithValue("@soyad", soyad);

                    command.Parameters.AddWithValue("@adres", adres);
                    command.Parameters.AddWithValue("@yaş", yas);
                    command.Parameters.AddWithValue("@gmail", email);

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
                        textBox6.Clear();

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

