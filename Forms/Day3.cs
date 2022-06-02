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
    public partial class Day3 : Form
    {
        Random random = new Random();

        // размеры матрицы и datagridview
        int a = 10;
        int b = 10;

        public Day3()
        {
            InitializeComponent();

            // задаем размеры datagridview
            dataGridView1.RowCount = a;
            dataGridView1.ColumnCount = b;

            // считаем и заполняем все
            ComputeAll();
        }

        // заполняет матрицу числами от -100 до 100
        public int[,] FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(-100, 100);

            return matrix;
        }

        // работает не трогай
        static int[,] CompactArray(int[,] rectangular)
        {
            // номера строк с ненулевыми ячейками
            int[] rows = Enumerable.Range(0, rectangular.GetLength(0)).Where(row => Enumerable.Range(0, rectangular.GetLength(1)).Select(col => rectangular[row, col]).Any(elem => elem != 0)).Select(row => row).ToArray();

            // номера столбцов с ненулевыми ячейками
            int[] cols = Enumerable.Range(0, rectangular.GetLength(1)).Where(col => Enumerable.Range(0, rectangular.GetLength(0)).Select(row => rectangular[row, col]).Any(elem => elem != 0)).Select(col => col).ToArray();

            int[,] compactRectangularArray = new int[rows.Length, cols.Length];

            int newRow = 0;
            foreach (int oldRow in rows)
            {
                int newCol = 0;
                foreach (int oldCol in cols)
                {
                    compactRectangularArray[newRow, newCol] = rectangular[oldRow, oldCol];

                    newCol++;
                }

                newRow++;
            }

            return compactRectangularArray;
        }

        // все вычисления
        private void ComputeAll()
        {
            // задаем матрицы
            int[,] matr = new int[a, b];
            // заполняем матрицу
            var matrix = FillMatrix(matr);

            // выводим изначальную матрицу
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];

            // ищем первую строку с положительным числом и выводим ее номер
            int firstPositive = FindFirstPositiveRow(matrix);
            if (firstPositive == -1) textBox1.Text = "В матрице нет положительных элементов";
            else textBox1.Text = firstPositive.ToString();

            // сжимаем матрицу
            var compactMatrix = CompactArray(matrix);

            // задаем параметры datagridview
            dataGridView2.RowCount = compactMatrix.GetLength(0);
            dataGridView2.ColumnCount = compactMatrix.GetLength(1);

            // выводим в этот же datagridview
            for (int i = 0; i < compactMatrix.GetLength(0); i++)
                for (int j = 0; j < compactMatrix.GetLength(1); j++)
                    dataGridView2.Rows[i].Cells[j].Value = matrix[i, j];
        }

        // нахождение первой строки, в которой есть положительный элемент
        public int FindFirstPositiveRow(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0) return i;
            return -1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ComputeAll();
        }

        // процедура задание 1
        public void SortMatrix(int[,] matrix, int size)
        {
            int i, j;
            int flag = 1;
            while (flag == 1)
            {
                flag = 0;

                for (i = 0; i < size - 1; i++)
                {
                    double sum1 = 0, sum2 = 0;
                    for (j = 0; j < size; j++)
                    {
                        if (matrix[j, i] < 0 && matrix[j, i] % 2 != 0)
                        {
                            sum1 += Math.Abs(matrix[j, i]);
                        }
                        if (matrix[j, i + 1] < 0 && matrix[j, i + 1] % 2 != 0)
                        {
                            sum2 += Math.Abs(matrix[j, i + 1]);
                        }
                    }
                    if (sum1 > sum2)
                    {
                        for (j = 0; j < size; j++)
                        {
                            int tmp = matrix[j, i];
                            matrix[j, i] = matrix[j, i + 1];
                            matrix[j, i + 1] = tmp;
                        }
                        flag = 1;
                    }
                }
            }
            // чисто вывод
            string p;
            for (i = 0; i < size; i++)
            {
                p = "";
                for (j = 0; j < size; j++)
                {
                    p += (matrix[i, j]).ToString() + "\t";
                }
                //listBox2.Items.Add(p); // здесь был вывод в листбокс
            }
        }

        //// функция задание 2
        //public double SummMatrix(int[,] mass, int size)
        //{
        //    try
        //    {
        //        int i, j;
        //        for (i = 0; i < size; i++)
        //        {
        //            double sum = 0;
        //            for (j = 0; j < size; j++)
        //            {
        //                if (mass[j, i] < 0)
        //                {
        //                    for (j = 0; j < size; j++)
        //                    {
        //                        sum += mass[j, i];
        //                    }
        //                }
        //            }
        //            listBox3.Items.Add(sum);
        //        }
        //    return 0;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка! Попробуйте ввести переменные снова.");
        //    }
        //    return 0;
        //}

        // кнопка очистки
        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            //listBox2.Items.Clear();
            listBox3.Items.Clear();
        }

        // кнопка перехода на главную форму
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}