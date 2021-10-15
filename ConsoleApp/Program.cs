using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        // эгземпляр рандома
        static Random rand = new Random();

        static char AsciiCharacter
        {
            get
            {
                int t = rand.Next(10);
                if (t <= 2)
                    // возврашает номер
                    return (char)('0' + rand.Next(10));
                else if (t <= 4)
                    // возврашает маленькие буквы
                    return (char)('a' + rand.Next(27));
                else if (t <= 6)
                    // возврашает большие буквы
                    return (char)('A' + rand.Next(27));
                else
                    // возврашает любой символ
                    return (char)(rand.Next(32, 255));
            }
        }

        static void Main()
        {
            //задает максимальный размер окна
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.CursorVisible = false;

            int width, height;
            int[] y;

            // задается начальные условие для 'у'
            Initialize(out width, out height, out y, out int size);

            // бесконечный вызов метода марицного дождя
            while (true)
                UpdateAllColumns(width, height, y, size);
        }



        private static void UpdateAllColumns(int width, int height, int[] y, int size)
        {
            int x;

            for (x = 0; x < width; ++x)
            {
                // по умолчанию gray
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(AsciiCharacter);

                // Green значение
                Console.ForegroundColor = ConsoleColor.Green;
                int temp1 = y[x] - 1;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                Console.Write(AsciiCharacter);
                // DarkGreen значение
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp2 = y[x] - 2;
                Console.SetCursorPosition(x, inScreenYPosition(temp2, height));
                Console.Write(AsciiCharacter);

                // случайная длина длина переменного size
                int temp3 = y[x] - (size + size);
                Console.SetCursorPosition(x, inScreenYPosition(temp3, height));
                Console.Write(' ');

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp4 = y[x] + (size);
                Console.SetCursorPosition(x, inScreenYPosition(temp4, height));
                Console.Write(AsciiCharacter);
                // DarkGreen значение
                Console.ForegroundColor = ConsoleColor.Gray;
                int temp5 = y[x] + (size + 1);
                Console.SetCursorPosition(x, inScreenYPosition(temp5, height));
                Console.Write(AsciiCharacter);

                

                // инкримент y
                y[x] = inScreenYPosition(y[x] + 1, height);
            }

            // F5 для рестарта, F11 или любая клавиша для паузы
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.F5)
                    Initialize(out width, out height, out y, out size);
                if (Console.ReadKey().Key == ConsoleKey.F11)
                    System.Threading.Thread.Sleep(1);
            }

        }

        // волидация на позиция 'y' за передели экрана
        public static int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }

        // Передача параметров по значению для 'width' 'height' 'y'
        private static void Initialize(out int width, out int height, out int[] y, out int size)
        {
            //размер высоты
            height = Console.WindowHeight;
            //размер длины
            width = Console.WindowWidth - 1;
            size = 4;

            // 239 для меня.. длина 'y'
            y = new int[width];

            Console.Clear();
            // зацикливаемся на 239 раз
            for (int x = 0; x < width; ++x)
            {
                // получает случайное число от 0 до 63 для меня
                y[x] = rand.Next(height);
                size = rand.Next(5, 10);
            }
        }
    }
}
