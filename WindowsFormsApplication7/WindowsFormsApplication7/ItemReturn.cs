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
    public partial class ItemReturn : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        int t;
        public ItemReturn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ItemReturn_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=THISPC\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            String id = textBox1.Text;
            cmd = new SqlCommand("select * from Sells where Cast(sell_id as varchar)  = @id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataAdapter adtp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adtp.Fill(ds, "dt");
             con.Open();
             if (ds.Tables[0].Rows.Count > 0)
             {
                 textBox2.Text = ds.Tables[0].Rows[0][4].ToString();
                 textBox3.Text = ds.Tables[0].Rows[0][3].ToString();
                 textBox2.Visible = true;
                 t = Convert.ToInt32(textBox3.Text);
             }
             else
             {
                 MessageBox.Show("Sell id"+@id+"Not found");
             }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int q = 0;
            con = new SqlConnection(@"Data Source=THISPC\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            String id = textBox1.Text;
            int rquan = Convert.ToInt32(textBox3.Text);
            String detail = textBox5.Text;
            cmd = new SqlCommand("insert into dmage2(sell_id,detail,return_qty) values(@id,@detail,@rquan)", con);
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.Parameters.AddWithValue(@"rquan", rquan);
            cmd.Parameters.AddWithValue(@"detail", detail);
            con.Open();
               int k = cmd.ExecuteNonQuery();
               if (k != 0)
               {
                   MessageBox.Show("Data inserted Sucessfully");
                   q = t - rquan;
                   cmd = new SqlCommand("Update Sells set [sell_qty]=@q  where Cast(sell_id as varchar)  = @id", con);
                   cmd.Parameters.AddWithValue(@"id", id);
                   cmd.Parameters.AddWithValue(@"q", q);
                   int k1 = cmd.ExecuteNonQuery();
                   if (k1 != 0)
                   {
                       MessageBox.Show("Done");
                   }
                   else
                   {
                       
                   }

                   
               }
               else
               {
                   MessageBox.Show("Product is not add");
               }




        }

    }
}
