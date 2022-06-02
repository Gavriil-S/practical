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
    public partial class Day2 : Form
    {
        public Day2()
        {
            InitializeComponent();
        }

        // кнопка старта
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Random rand_size = new Random();
                Random random = new Random();
                int size = rand_size.Next(8, 20);
                int[] mas = new int[size];
                for (int s = 0; s < size; s++)
                {
                    mas[s] = random.Next(-20, 20);
                    int number = mas[s];
                    listBox1.Items.Add(number);
                }

                // индекс минимального элемента массива
                int idx = Array.IndexOf(mas, mas.Min()) + 1;
                textBox1.Text = idx.ToString() + " -ый/-ой";

                // сумма элементов массива, расположенных между первым и вторым отрицательным элементом
                int count = 0;
                for (int a = 0; a < size; a++)
                {
                    if (mas[a] < 0)
                    {
                        count++;
                    }
                }
                if (count >= 2)
                {
                    int i = 0, sum = 0;
                    while (mas[i] >= 0) i++;
                    while (mas[++i] >= 0) sum += mas[i];
                    textBox2.Text = Convert.ToString(sum);
                }

                // сортировка массива. сначала элементы, модуль которых не превышает единицу
                var sorted = mas.OrderBy(n => Math.Abs(n) > 1);
                foreach (var z in sorted)
                {
                    listBox2.Items.Add(z.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Попробуйте ещё раз!");
            }
        }

        // кнопка очистки
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            listBox2.Items.Clear();
        }

        // кнопка перехода на главную форму
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}