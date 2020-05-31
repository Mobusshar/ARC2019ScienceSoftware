using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PH ph1 = new PH();
            ph1.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GAS gas1 = new GAS();
            gas1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MOISTURE moisture1 = new MOISTURE();
            moisture1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            COLOR color1 = new COLOR();
            color1.Show();
        }
    }
}
