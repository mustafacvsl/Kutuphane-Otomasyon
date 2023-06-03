using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_otomation2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" && textBox2.Text=="")
            {
                MessageBox.Show("Kulanıcı Adı veya şifre boş geçilemez!!");
            }
            else
            {
                if (textBox1.Text == "admin" && textBox2.Text == "12345") ;
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
