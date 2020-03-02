using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication7
{
    public partial class search : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=THISPC\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            String id = textBox1.Text;
            cmd = new SqlCommand("select * from buy where Cast(i_id as varchar)  = @id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataAdapter adtp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adtp.Fill(ds, "dt");
            con.Open();
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                //textBox4.Text = ds.Tables[0].Rows[0][4].ToString();
                textBox5.Text = ds.Tables[0].Rows[0][4].ToString();
                textBox6.Text = ds.Tables[0].Rows[0][5].ToString();
                textBox7.Text = ds.Tables[0].Rows[0][6].ToString();
                textBox8.Text = ds.Tables[0].Rows[0][7].ToString();
                textBox9.Text = ds.Tables[0].Rows[0][8].ToString();
            }

            else
            {
                MessageBox.Show("Data not found");
            }

            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;

        }

        private void search_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
        }
    }
}
