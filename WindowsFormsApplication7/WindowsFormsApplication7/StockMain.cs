using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class StockMain : Form
    {

        public StockMain()
        {
            InitializeComponent();
        }

        private void StockMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Demo page");
        }

        private void StockMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product pro = new Product();
            pro.MdiParent = this;
            pro.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search pro = new search();
            pro.MdiParent = this;
            pro.Show();
        }

        private void existingItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eisting pro = new Eisting();
            pro.MdiParent = this;
            pro.Show();
        }

        private void itemReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemReturn pro = new ItemReturn();
            pro.MdiParent = this;
            pro.Show();
        }

        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sell pro = new Sell();
            pro.MdiParent = this;
            pro.Show();
        }

    }
}
