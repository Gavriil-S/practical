using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using practica.Forms.Day4_Forms;

namespace practica
{
    public partial class Day4 : Form
    {
        public Day4()
        {
            InitializeComponent();
        }

        List<Call> calls = new List<Call>(); // объявление листа для записи звонков

        // кнопка старта. добавление исходных данных
        private void startButton_Click(object sender, EventArgs e)
        {
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = calls.Where(c => c.Number_Caller.Contains(textBox5.Text) || c.LastName_Caller.Contains(textBox5.Text) || c.Data_Call.Contains(textBox5.Text) || c.Worker.Contains(textBox5.Text)).ToList();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            var worker = sortComboBox.SelectedItem;
            dataGridView2.DataSource = calls.Where(c => c.Worker == worker.ToString()).ToList();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Call DeleteBook = calls.FirstOrDefault(c => c.Id == Id);
            calls.Remove(DeleteBook);
            File.Delete(@"Calls.txt");
            string[] vs = new string[calls.Count];
            int i = 0;
            foreach (var item in calls)
            {
                vs[i] = $"{i + 1} {item.Number_Caller} {item.LastName_Caller} {item.Data_Call} {item.Worker}";
                i++;
            }
            File.WriteAllLines(@"Calls.txt", vs);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = calls;
        }

        //private void addButton_Click(object sender, EventArgs e)
        //{
        //    File.AppendAllText(@"Calls.txt", $"{calls.Count + 1} {textBox1.Text} {textBox2.Text} {textBox3.Text} {textBox4.Text}\n");
        //    Call newcall = new Call();
        //    newcall.Id = calls.Count + 1;
        //    newcall.Number_Caller = textBox1.Text;
        //    newcall.LastName_Caller = textBox2.Text;
        //    newcall.Data_Call = textBox3.Text;
        //    newcall.Worker = textBox4.Text;
        //    calls.Add(newcall);
        //    dataGridView1.DataSource = null;
        //    dataGridView1.DataSource = calls;
        //    textBox1.Clear();
        //    textBox2.Clear();
        //    textBox3.Clear();
        //    textBox4.Clear();
        //    var worker = calls.Select(c => c.Worker).Distinct().ToList();
        //    foreach (var items in worker)
        //    {
        //        sortComboBox.Items.Add(items);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ввод данных из диалогового окна
        private void вДиалогеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAccount account = new AddAccount();
            account.ShowDialog();
        }

        // ввод данных из файла
        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] mas = File.ReadAllLines("Calls.txt");
            foreach (string h in mas)
            {
                Call call = new Call();
                var s = h.Split(' ');
                call.Id = Convert.ToInt32(s[0]);
                call.Number_Caller = s[1];
                call.LastName_Caller = s[2];
                call.Data_Call = s[3];
                call.Worker = s[4];
                calls.Add(call);
            }
            dataGridView1.DataSource = calls;
            var worker = calls.Select(c => c.Worker).Distinct().ToList();
            foreach (var items in worker)
            {
                sortComboBox.Items.Add(items);
            }
        }
    }
}