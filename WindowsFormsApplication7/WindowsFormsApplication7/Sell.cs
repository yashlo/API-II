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
    public partial class Sell : Form
    {
        SqlConnection con;
        SqlCommand cmd;
  
        public Sell()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sell_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
                textBox2.Visible = true;
                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                MessageBox.Show("Item id "+@id+" isnot available");
            }

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
                String totq = ds.Tables[0].Rows[0][4].ToString();
                int quan = Convert.ToInt32(totq);
                int rquan = Convert.ToInt32(textBox4.Text);
                if (quan > rquan)
                {
                    MessageBox.Show("Allowed");
                    String id1 = textBox1.Text;
                    String nm = textBox2.Text;
                    int sellp = Convert.ToInt32(textBox3.Text);
                    String selldt = textBox5.Text;
                    DateTime sdate = DateTime.ParseExact(selldt, "dd-MM-yyyy", null);
                    String sid = textBox6.Text;
                    cmd = new SqlCommand("insert into Sells(i_id,i_name,sell_price,sell_qty,sell_date,sell_id) values(@id1,@nm,@sellp,@rquan,@sdate,@sid)", con);
                    cmd.Parameters.AddWithValue(@"id1", id1);
                    cmd.Parameters.AddWithValue(@"nm", nm);
                    cmd.Parameters.AddWithValue(@"sellp", sellp);
                    cmd.Parameters.AddWithValue(@"rquan", rquan);
                    cmd.Parameters.AddWithValue(@"sdate", sdate);
                    cmd.Parameters.AddWithValue(@"sid", sid);
                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {
                        MessageBox.Show("Data inserted Sucessfully");
                        int req = quan - rquan;
                        cmd = new SqlCommand("Update buy set[i_qty]=@qty where Cast(i_id as varchar)  = @id", con);
                        cmd.Parameters.AddWithValue(@"id", id);
                        cmd.Parameters.AddWithValue(@"qty", req);
                        int k1 = cmd.ExecuteNonQuery();
                        if (k1 != 0)
                        {
                            MessageBox.Show("Done");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something wrong in sell");
                    }

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Not Allowed");
                }
            }

            else
            {
                MessageBox.Show("Item id " + @id + " isnot available");
            }

        }
    }
}
