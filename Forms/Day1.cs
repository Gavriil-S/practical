using System;
using System.Windows.Forms;

namespace practica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // считывание и конвертация вводных значений перменных из textbox'ов
        static double Convertation(TextBox textBox)
        {
            return Convert.ToDouble(textBox.Text);
        }

        // метод для очистки полей
        static void ClearTB(TextBox textBox)
        {
            textBox.Text = "";
        }

        // очистка первой вкладки
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearTB(textBox1);
            ClearTB(textBox2);
            ClearTB(textBox3);
            ClearTB(textBox4);
        }

        // очистка второй вкладки
        private void button3_Click(object sender, EventArgs e)
        {
            ClearTB(textBox5);
            ClearTB(textBox7);
        }

        // очистка третьей вкладки
        private void button5_Click(object sender, EventArgs e)
        {
            ClearTB(textBox6);
            ClearTB(textBox8);
            ClearTB(textBox9);
        }

        // первое задание
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // задаётся Х и Y
                double x = Convertation(textBox1);
                double y = Convertation(textBox2);

                if (x >= 100000 || y >= 100000)
                {
                    MessageBox.Show("Число слишком велико!!! =(");
                }
                else
                {
                    //первый пример
                    double cos_x, cos_y, sin_2x, division;
                    cos_x = Math.Cos(x);
                    cos_y = Math.Cos(y);
                    cos_x = Math.Pow(cos_x, 4);
                    cos_y = Math.Pow(cos_y, 2);
                    double res_one = cos_x - cos_y;
                    sin_2x = Math.Sin(2 * x);
                    sin_2x = Math.Pow(sin_2x, 2);
                    division = sin_2x / 4;
                    res_one = res_one + division;
                    textBox3.Text = Convert.ToString(Math.Round(res_one, 3));

                    //второй пример
                    double sin_one, sin_tue;
                    sin_one = Math.Sin(y + x);
                    sin_tue = Math.Sin(y - x);
                    double res_tue = sin_one * sin_tue;
                    textBox4.Text = Convert.ToString(Math.Round(res_tue, 3));
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Попробуйте ввести переменные снова.");
            }
        }

        // второе задание
        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = solution();
        }

        // метод решения второго задания
        public string solution()
        {
            try
            {
                double x = Convertation(textBox5);

                if (x < -10 || x > 8)
                {
                    MessageBox.Show("Заданная точка выходит за пределы графика!!!");
                }
                else
                {
                    if ((x >= -10) && (x <= (-6)))
                    {
                        x = x + 8;
                        double res = Math.Sqrt(4 - x * x) - 2;
                        return res.ToString();
                    }
                    if ((x >= -6) && (x < 2))
                    {
                        double res = (1 / 2) * x + 1;
                        return res.ToString();
                    }
                    if ((x >= 2) && (x < 6))
                    {
                        double res = 0;
                        return res.ToString();
                    }
                    if ((x >= 6) && (x <= 8))
                    {
                        double res = Math.Pow(x - 6, 2);
                        return res.ToString();
                    }
                }   
            }
            catch
            {
                MessageBox.Show("Ошибка! Попробуйте ввести переменные снова.");
            }
            return "";
        }

        // третье задание
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double r = Convertation(textBox6);
                double x = Convertation(textBox8);
                double y = Convertation(textBox9);

                if (r >= 100000 || x >= 100000 || y >= 100000)
                {
                    MessageBox.Show("Данные слишком велики!");
                }
                else
                {
                    if (r <= 0)
                        MessageBox.Show("Вы ввели отрицательный или нулевой радиус!");
                    else if (x >= 0 && y <= r && x <= r && y * (-1) <= r)
                        MessageBox.Show("Точка попадает в заданную область");
                    else if (x <= 0 && y <= x && y >= -x)
                        MessageBox.Show("Точка попадает в заданную область");
                    else if (x <= 0 && y >= 0 && -x <= y && -y <= r)
                        MessageBox.Show("Точка попадает в заданную область");
                    else if (-x <= -y && y <= r && -y <= r)
                        MessageBox.Show("Точка попадает в заданную область");
                    else
                        MessageBox.Show("Точка не попадает в заданную область");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Попробуйте ввести переменные снова.");
            }
        }

        // кнопка выхода на стартовую форму
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}