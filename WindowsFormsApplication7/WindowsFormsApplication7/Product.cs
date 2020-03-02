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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(@"Data Source=THISPC\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            String id = textBox1.Text;
            String nm = textBox2.Text;
            String ity = textBox3.Text;
            String py = textBox4.Text;
            int py1 = Convert.ToInt32(py);
            int qty = Convert.ToInt32(textBox9.Text);
            String dt = textBox5.Text;
            DateTime odate = DateTime.ParseExact(dt, "dd-MM-yyyy", null);
            String dt1 = textBox6.Text;
            DateTime rdate = DateTime.ParseExact(dt1, "dd-MM-yyyy", null);
            String sid = textBox7.Text;
            int supc = Convert.ToInt32(textBox8.Text);
            cmd = new SqlCommand("insert into buy(i_id,i_name,i_type,i_price,i_qty,i_order_date,i_receive_date,i_suplier_id,i_suplier_contact) values(@id,@nm,@ity,@py1,@qty,@odate,@rdate,@sid,@supc)", con);
            cmd.Parameters.AddWithValue(@"id",id);
             cmd.Parameters.AddWithValue(@"nm",nm);
             cmd.Parameters.AddWithValue(@"ity",ity);
             cmd.Parameters.AddWithValue(@"py1",py1);
             cmd.Parameters.AddWithValue(@"qty",qty);
             cmd.Parameters.AddWithValue(@"odate",odate);
             cmd.Parameters.AddWithValue(@"rdate",rdate);
             cmd.Parameters.AddWithValue(@"sid",sid);
             cmd.Parameters.AddWithValue(@"supc",supc);
             con.Open();
            int k= cmd.ExecuteNonQuery();
            if (k != 0)
            {
                MessageBox.Show("Data inserted Sucessfully");
            }
            con.Close();



        }

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockDataSet.buy' table. You can move, or remove it, as needed.
            this.buyTableAdapter.Fill(this.stockDataSet.buy);

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(@"Data Source=THISPC\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            String id = textBox1.Text;
            cmd = new SqlCommand("delete from buy where Cast(i_id as varchar)  = @id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                MessageBox.Show("Data Deleted Successfully");
            }
            con.Close();


        }
    }
}
