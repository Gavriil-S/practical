using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 day1 = new Form1();
            day1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Day2 day2 = new Day2();
            day2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Day3 day3 = new Day3();
            day3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Day4 day4 = new Day4();
            day4.Show();
        }
    }
}
