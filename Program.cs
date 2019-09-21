using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication11
{
    public class Matrix
    {
        double[,] matrix;

        public int Row { get; protected set; }
        public int Column { get; protected set; }

        public Matrix(int row, int column)
        {
            Row = row;
            Column = column;
            matrix = new double[row, column];
        }

        public Matrix Multiple(Matrix value)
        {
            Matrix result = new Matrix(Row, value.Column);
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < value.Column; j++)
                    for (int k = 0; k < value.Row; k++)
                        result.matrix[i, j] += matrix[i, k] * value.matrix[k, j];
            return result;
        }

        public void Read()
        {
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                {
                    Console.Write("Введите элемент [{0},{1}]: ", i + 1, j + 1);
                    matrix[i, j] = System.Convert.ToDouble(Console.ReadLine());
                }
        }

        public void Print()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                    Console.Write("{0:f2} ", matrix[i, j]);
                Console.WriteLine();
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Matrix vector = new Matrix(1, 4);
            Matrix matrix = new Matrix(4, 4);
            Console.Clear();
            Console.WriteLine("Ввод вектора");
            vector.Read();
            Console.WriteLine("\nВвод матрицы");
            matrix.Read();
            Console.Clear();
            Matrix result = vector.Multiple(matrix);
            Console.WriteLine("Вектор");
            vector.Print();
            Console.WriteLine("\nМатрица");
            matrix.Print();
            Console.WriteLine("\nРезультат умножения матрицы на вектор");
            result.Print();
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы");
            Console.ReadKey(true);
        }
    }
}