﻿using System;
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
    public partial class Form3Sil : Form
    {
        public Form3Sil()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9CITR9N\\SQLEXPRESS;Initial Catalog=kütüphane;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void listele(String veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from table1 where AD =@adi", baglanti);
            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.ExecuteNonQuery();
            listele("Select * From table1");
            baglanti.Close();

            textBox1.Clear();


        }

        private void Form3Sil_Load(object sender, EventArgs e)
        {

            

                }

        private void button4_Click(object sender, EventArgs e)
        {
            listele("Select * From table1");
        }
    }
        }
    
