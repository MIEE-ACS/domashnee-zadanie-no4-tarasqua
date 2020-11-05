using System;
using System.Collections.Generic;

namespace HomeWork_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            //______________________________________________________________________________
            //ПРОВЕРОЧНАЯ МАТРИЦА:
            //int[,] mas = {
            //                {-3,-5,0,-8,-1,0},
            //                 {2,1,0,-9,-5,0},
            //                 {0,0,0,0,0,0},
            //                 {7,8,0,-3,3,0},
            //                 {0,0,0,0,0,0},
            //                 {9,1,0,-9,-5,0},
            //                 {0,0,0,0,0,0},
            //            };

            //// получаем кол-во строк 
            //int length1 = mas.GetLength(0);
            //// получаем кол-во столбцов 
            //int length2 = mas.GetLength(1);
            //______________________________________________________________________________

            //______________________________________________________________________________
            //МАТРИЦА С РАНДОМНЫМИ ЗНАЧЕНИЯМИ
            int length1;
            int length2;

            while (true)
            {
                Console.WriteLine("Введите количество строк:");
                if (int.TryParse(Console.ReadLine(), out length1))
                    break;
                else
                {
                    Console.WriteLine("Неверно введенное количество строк! (Для повторного ввода нажмите любую клавишу)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            while (true)
            {
                Console.WriteLine("Введите количество столбцов:");
                if (int.TryParse(Console.ReadLine(), out length2))
                    break;
                else
                {
                    Console.WriteLine("Неверно введенное количество столбцов! (Для повторного ввода нажмите любую клавишу)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            int[,] mas = new int[length1, length2];
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    mas[i, j] = random.Next(-3, 3);
                }
            }
            //______________________________________________________________________________

            //______________________________________________________________________________
            //ХОД РЕШЕНИЯ:

            //объявляем коллекции для хранения нулевых строк и столбцов
            List<int> ls1 = new List<int>();
            List<int> ls2 = new List<int>();

            Console.WriteLine("Исходная матрица:\n");
            // выводим матрицу на консоль и находим нулевые строки
            for (int i = 0; i < length1; ++i)
            {
                bool b = false;
                for (int j = 0; j < length2; ++j)
                {
                    if (mas[i, j] >= 0)
                        Console.Write("  " + mas[i, j]);
                    else Console.Write(" " + mas[i, j]);
                    if (mas[i, j] != 0) b = true;
                }

                if (!b) ls1.Add(i);
                Console.WriteLine();
            }

            //находим нулевые столбцы
            for (int i = 0; i < length2; ++i)
            {
                bool b = false;
                for (int j = 0; j < length1; ++j)
                {

                    if (mas[j, i] != 0) b = true;
                }
                if (!b) ls2.Add(i);
            }

            //Удаляем нулевые строки и столбцы и находим номер первой из строк (начиная с нуля),
            //содержащих хотя бы один положительный элемент
            bool B = false; int? Istr = null;
            Console.WriteLine("\nУдаляем нулевые строки и столбцы\n");
            for (int i = 0; i < length1; ++i)
            {
                if (!ls1.Contains(i))
                {
                    for (int j = 0; j < length2; ++j)
                    {
                        if (!ls2.Contains(j))
                        {
                            if (mas[i, j] >= 0)
                            {
                                if (!B)
                                {
                                    Istr = i;
                                    B = true;
                                }
                                Console.Write("  " + mas[i, j]);
                            }
                            else Console.Write(" " + mas[i, j]);
                        }

                    }
                }
                if (!ls1.Contains(i))
                    Console.WriteLine();
            }
            Console.WriteLine("\nHомер первой из строк (начиная с нуля), содержащих хотя бы один положительный элемент -> {0}", Istr);
            Console.ReadKey();
            //___________________________________________________________________________________________________________________________
        }
    }
}
