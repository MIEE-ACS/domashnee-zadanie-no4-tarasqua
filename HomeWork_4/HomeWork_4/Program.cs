using System;

namespace HomeWork_4
{
    class Program
    {
        static void ShowArray(double[] array, int size)
        {
            Console.WriteLine("Заполненный массив:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        static void ChooseAction()
        {
            Console.Write("\n\n0 - Выйти из программы." +
                "\n1 - Вычислить номер минимального по модулю элемента массива." +
                "\n2 - Вычислить сумму модулей элементов массива, расположенных после первого отрицательного элемента." +
                "\n3 - Сжать массив, удалив из него все элементы, величина которых находится в интервали от a до b. Освободившиеся в конце элементы заполнить нулями." +
                "\n4 - Произвести все операции." +
                "\n\nВыберите нужный пункт меню: ");
        }

        static void Main(string[] args)
        {
            //_________________________________________________________________________________________________________________________________
            //РАБОТА С МАССИВОМ:
            Random random = new Random();
            int size, maxr, minr, swi, a, b;

            while (true)
            {
                Console.Write("Введите размерность массива: ");
                if (int.TryParse(Console.ReadLine(), out size) && size > 0)
                    break;
                else
                {
                    Console.WriteLine("Некорректно введенный размер! (Для повторного ввода нажмите любую клавишу)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            double[] mas = new double[size];
            Console.Clear();

            int choose = 0;
            while (true)
            {
                Console.Write("1 - Заполнить массив вручную" +
                "\n2 - Заполнить массив случайными числами" +
                "\n\nВыберите нужный пункт меню: ");
                if (int.TryParse(Console.ReadLine(), out choose) && (choose == 1 || choose == 2))
                    break;
                else
                {
                    Console.WriteLine("Введите 1 или 2! (Для повторного ввода нажмите любую клавишу)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            switch (choose)
            {
                case 1:
                    Console.Clear();
                    for (int i = 0; i < size; i++)
                    {
                        while (true)
                        {
                            Console.Write("Massiv[" + i + "]: ");
                            if (double.TryParse(Console.ReadLine(), out mas[i]))
                                break;
                            else
                            {
                                Console.WriteLine("Введите число! (Для повторного ввода нажмите любую клавишу)");
                                Console.ReadKey();
                            }
                        }
                    }
                    break;
                case 2:
                    Console.Clear();
                    while (true)
                    {
                        while (true)
                        {
                            Console.Write("Введите минимальное возможное значение случайного числа при заполнении массива: ");
                            if (int.TryParse(Console.ReadLine(), out minr))
                                break;
                            else
                            {
                                Console.WriteLine("Введите число! (Для повторного ввода нажмите любую клавишу)");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        while (true)
                        {
                            Console.Write("Введите максимальное возможное значение случайного числа при заполнении массива: ");
                            if (int.TryParse(Console.ReadLine(), out maxr))
                                break;
                            else
                            {
                                Console.WriteLine("Введите число! (Для повторного ввода нажмите любую клавишу)");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        if (minr < maxr) break;
                        else Console.WriteLine("Максимальное значение не может быть меньше минимального!");
                    }
                    
                    for (int i = 0; i < size; i++)
                    {
                        mas[i] = Math.Round(random.Next(minr, maxr - 1) + random.NextDouble(), 3);
                    }
                    break;
            }
            Console.Clear();
            ShowArray(mas, size);

            //_________________________________________________________________________________________________________________________________
            //ХОД РЕШЕНИЯ:
            do
            {
                while (true)
                {
                    ChooseAction();
                    if (int.TryParse(Console.ReadLine(), out swi) && (swi == 0 || swi == 1 || swi == 2 || swi == 3 || swi == 4))
                        break;
                    else
                    {
                        Console.WriteLine("Введите одно из предложенных чисел! (Для повторного ввода нажмите любую клавишу)");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                switch (swi)
                {
                    case 1:
                        Console.Clear();
                        ShowArray(mas, size);

                        double min = Math.Abs(mas[0]);
                        int index = 0;
                        for (int i = 0; i < size; i++)
                        {
                            if (min > Math.Abs(mas[i]))
                            {
                                min = Math.Abs(mas[i]);
                                index = i;
                            }
                        }
                        Console.WriteLine("\n\nИндекс минимального по модулю элемента: {0}", index);
                        break;
                    case 2:
                        Console.Clear();
                        ShowArray(mas, size);

                        double sum = 0;
                        bool f = false;
                        for (int i = 0; i < size; i++)
                        {
                            if (f)
                                sum += Math.Abs(mas[i]);
                            if (mas[i] < 0)
                                f = true;
                        }
                        Console.WriteLine("\n\nСумма модулей элементов массива, расположенных после первого отрицательного элемента: " + sum);
                        break;
                    case 3:
                        Console.Clear();
                        ShowArray(mas, size);
                        Console.WriteLine();

                        while (true)
                        { 
                            Console.Write("Введите A (левая граница интервала сжатия): ");
                            if (int.TryParse(Console.ReadLine(), out a))
                                break;
                            else
                            {
                                Console.WriteLine("Введите число! (Для повторного ввода нажмите любую клавишу)");
                                Console.ReadKey();
                            }
                        }

                        while (true)
                        {
                            Console.Write("Введите B (правая граница интервала сжатия): ");
                            if (int.TryParse(Console.ReadLine(), out b))
                                break;
                            else
                            {
                                Console.WriteLine("Введите число! (Для повторного ввода нажмите любую клавишу)");
                                Console.ReadKey();
                            }
                        }

                        for (int i = 0; i < size; i++)
                        {
                            if ((mas[i] >= a) & (mas[i] <= b))
                            {
                                mas[i] = 0;
                            }
                        }

                        int countNull = 0;
                        int l = size;
                        for (int i = 0; i < l; i++)
                        {
                            if (mas[i] == 0)
                            {
                                for (int j = i; j < size - 1; j++)
                                    mas[j] = mas[j + 1]; //сдвигаем весь массив     
                                i--; //возвращаемся на одну позицию назад, на случай если два нуля подряд
                                l--; //тогда и проверять будем на одну назад
                                countNull++; //считаем сколько было нулей, чтобы потом их дописать с конца
                            }
                        }

                        for (int i = size - 1; i > 0 && countNull > 0; i--, countNull--) //пишем нули с конца массива столько раз, сколько было нулей
                        {
                            mas[i] = 0;
                        }

                        Console.WriteLine("Сжатый массив:");
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write(mas[i] + " ");
                        }
                        break;

                    case 4:
                        Console.Clear();
                        ShowArray(mas, size);
                        Console.WriteLine();

                        //____________________________________________________________________________________________________________________________________________________
                        double minFour = Math.Abs(mas[0]);
                        int indexFour = 0;
                        for (int i = 0; i < size; i++)
                        {
                            if (minFour > Math.Abs(mas[i]))
                            {
                                minFour = Math.Abs(mas[i]);
                                indexFour = i;
                            }
                        }

                        //____________________________________________________________________________________________________________________________________________________
                        double sumFour = 0;
                        bool fFour = false;
                        for (int i = 0; i < size; i++)
                        {
                            if (fFour)
                                sumFour += Math.Abs(mas[i]);
                            if (mas[i] < 0)
                                fFour = true;
                        }
                        //____________________________________________________________________________________________________________________________________________________

                        while (true)
                        {
                            Console.Write("Введите A (левая граница интервала сжатия): ");
                            if (int.TryParse(Console.ReadLine(), out a))
                                break;
                            else
                            {
                                Console.WriteLine("Введите число! (Для повторного ввода нажмите любую клавишу)");
                                Console.ReadKey();
                            }
                        }

                        while (true)
                        {
                            Console.Write("Введите B (правая граница интервала сжатия): ");
                            if (int.TryParse(Console.ReadLine(), out b))
                                break;
                            else
                            {
                                Console.WriteLine("Введите число! (Для повторного ввода нажмите любую клавишу)");
                                Console.ReadKey();
                            }
                        }

                        for (int i = 0; i < size; i++)
                        {
                            if ((mas[i] >= a) & (mas[i] <= b))
                            {
                                mas[i] = 0;
                            }
                        }

                        int countNullFour = 0;
                        int lFour = size;
                        for (int i = 0; i < lFour; i++)
                        {
                            if (mas[i] == 0)
                            {
                                for (int j = i; j < size - 1; j++)
                                    mas[j] = mas[j + 1]; //сдвигаем весь массив     
                                i--; //возвращаемся на одну позицию назад, на случай если два нуля подряд
                                lFour--; //тогда и проверять будем на одну назад
                                countNullFour++; //считаем сколько было нулей, чтобы потом их дописать с конца
                            }
                        }

                        for (int i = size - 1; i > 0 && countNullFour > 0; i--, countNullFour--) //пишем нули с конца массива столько раз, сколько было нулей
                        {
                            mas[i] = 0;
                        }



                        Console.WriteLine("\nСжатый массив:");
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write(mas[i] + " ");
                        }
                        
                        Console.WriteLine("\nИндекс минимального по модулю элемента (в массиве без изменений): {0}", indexFour);

                        Console.WriteLine("Сумма модулей элементов массива, расположенных после первого отрицательного элемента (в массиве без изменений): " + sumFour);
                        break;
                }
            }
            while (swi != 0);

            Console.WriteLine("\nДля выхода из программы нажмите [Enter]");
            Console.ReadLine();
            //_________________________________________________________________________________________________________________________________
        }
    }
}
