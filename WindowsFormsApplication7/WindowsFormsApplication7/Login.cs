using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
//using System.Data.SqlClient.SqlDataAdapter;
namespace WindowsFormsApplication7
{
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
          

        }
        private void Login_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=THISPC\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            con.Open();




        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                cmd = new SqlCommand("select * from Login Where Cast(userid as varchar)  ='" + textBox1.Text + "'and Cast(password as varchar) ='" + textBox2.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Login");
                    StockMain sm = new StockMain();
                    sm.Show();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("" + e1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
