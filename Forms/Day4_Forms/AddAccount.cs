using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using practica.Forms;

namespace practica.Forms.Day4_Forms
{
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        List<Call> calls = new List<Call>();



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText(@"Calls.txt", $"{calls.Count + 1} {textBox1.Text} {textBox2.Text} {textBox3.Text} {textBox4.Text}\n");
            Call newcall = new Call();
            newcall.Id = calls.Count + 1;
            newcall.Number_Caller = textBox1.Text;
            newcall.LastName_Caller = textBox2.Text;
            newcall.Data_Call = textBox3.Text;
            newcall.Worker = textBox4.Text;
            calls.Add(newcall);
            //var worker = calls.Select(c => c.Worker).Distinct().ToList();
            //foreach (var items in worker)
            //{
            //    sortComboBox.Items.Add(items);
            //}
            MessageBox.Show("Данные добавлены!");
        }
    }
}
