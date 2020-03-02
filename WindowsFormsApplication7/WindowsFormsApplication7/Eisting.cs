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
    public partial class Eisting : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Eisting()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
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
            con.Close();
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            button3.Visible = false;

        }

        private void Eisting_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text;
            String nm = textBox2.Text;
            String ity = textBox3.Text;
            String py = textBox4.Text;
            int py1 = Convert.ToInt32(py);
            int qty = Convert.ToInt32(textBox5.Text);
            String dt = textBox6.Text;
            DateTime odate = DateTime.ParseExact(dt, "dd-MM-yyyy HH:mm:ss tt", null);
            String dt1 = textBox7.Text;
            DateTime rdate = DateTime.ParseExact(dt1, "dd-MM-yyyy HH:mm:ss tt", null);
            String sid = textBox8.Text;
            int supc = Convert.ToInt32(textBox9.Text);
            cmd = new SqlCommand("Update buy set[i_name]=@nm,[i_type]=@ity,[i_price]=@py1,[i_qty]=@qty,[i_order_date]=@odate,[i_receive_date] =@rdate,[i_suplier_id]=@sid,[i_suplier_contact]=@supc where Cast(i_id as varchar)  = @id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.Parameters.AddWithValue(@"nm", nm);
            cmd.Parameters.AddWithValue(@"ity", ity);
            cmd.Parameters.AddWithValue(@"py1", py1);
            cmd.Parameters.AddWithValue(@"qty", qty);
            cmd.Parameters.AddWithValue(@"odate", odate);
            cmd.Parameters.AddWithValue(@"rdate", rdate);
            cmd.Parameters.AddWithValue(@"sid", sid);
            cmd.Parameters.AddWithValue(@"supc", supc);
            con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                MessageBox.Show("Data inserted Sucessfully");
            }
            con.Close();
        }
    }
}
