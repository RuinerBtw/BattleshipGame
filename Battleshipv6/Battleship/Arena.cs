using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Arena
    {
        public int Row { get; set; }
        public int Column { get; set; }


        // TODO: перенести сюда все методы для работы с полем:
        // метод для создания пустого поля
        const int gridSize = 10;
        public static char[,] grid = new char[gridSize, gridSize];
        public static char[,] p1map = new char[gridSize, gridSize];
        public static char[,] p2map = new char[gridSize, gridSize];
        /// <summary>
        /// Заполнение карты нач значением
        /// </summary>
        /// <param name="grid"></param>
        public static void InitializeGrid(char[,] grid)
        {
            int size = 10;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = '~';
                }
            }
        }
        /// <summary>
        /// Вывод карты на консоль
        /// </summary>
        /// <param name="grid"></param>
        public static void DrawGrid(char[,] grid)
        {
            int size = 10;
            Console.WriteLine("|0 1 2 3 4 5 6 7 8 9 ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(i);
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{grid[i, j]} ");
                }
                Console.WriteLine();

            }

        }
        public static void DrawGridforplay(char[,] grid1, char[,] grid2)
        {
            int size = 10;

            // Выводим нумерацию столбцов для первой сетки
            Console.Write("|0 1 2 3 4 5 6 7 8 9 ");

            // Выводим нумерацию столбцов для второй сетки
            Console.WriteLine("    |0 1 2 3 4 5 6 7 8 9");

            for (int i = 0; i < size; i++)
            {
                Console.Write(i); // Выводим нумерацию строк

                // Выводим содержимое ячеек первой сетки
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{grid1[i, j]} ");
                }

                // Добавляем пробел между двумя сетками
                Console.Write("     ");

                // Выводим содержимое ячеек второй сетки
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{grid2[i, j]} ");
                }

                Console.WriteLine(); // Переходим на следующую строку после вывода строки ячеек
            }
        }


        /// <summary>
        /// Метод Добавления корабля на карту по вертикали или горизонтали
        /// </summary>
        /// <param name="grid"></param>
        public static void shipPlace(char[,] grid)
        {

        restart:
            Console.WriteLine("Как поставить корабль Вертикально - 1 Горизонтально - 2"); //запрос на расстаовку корабля 
            string horizontal = (Console.ReadLine());
            bool digit = true;
            foreach (char c in horizontal)
            {
                if (!char.IsDigit(c))
                {
                    digit = false;
                    goto restart;
                }
                else if (digit)
                {
                    foreach (int size in Ships.shipsamount)
                    {
                        int numrow = 0;
                        int numcol = 0;
                        Console.WriteLine("Введите Ряд по Вертикали корабля от 0-9");
                        string shiprow = Console.ReadLine();
                        Console.WriteLine("Введите Столбец по Горизонтали корабля 0-9");
                        string shipcol = Console.ReadLine();
                        if (!int.TryParse(shiprow, out numrow) || (!int.TryParse(shipcol, out numcol)))
                        {
                            Console.WriteLine("Введите цифру");
                        }
                        else
                        {
                            bool validShip = true;

                            if (int.Parse(horizontal) == 1)
                            {
                                for (int i = numrow; i < numrow + size; i++)
                                {
                                    if (grid[i, numcol] == '#')
                                    {
                                        validShip = false;
                                        Console.WriteLine("Корабль перекрывает другой корабль. Попробуйте еще раз.");
                                        break;
                                    }
                                    else { grid[i, numcol] = '#'; }
                                }
                            }
                            else if (int.Parse(horizontal) == 2)
                            {
                                for (int i = numcol; i < numcol + size; i++)
                                {
                                    if (grid[numrow, i] == '#')
                                    {
                                        validShip = false;
                                        Console.WriteLine("Корабль перекрывает другой корабль. Попробуйте еще раз.");
                                        break;
                                    }
                                    else { grid[numrow, i] = '#'; }
                                }
                            }
                            else
                            {
                                if (numrow + size > Arena.grid.GetLength(0))   //Проверка выхода за пределы карты 
                                {
                                    if (numcol + size > Arena.grid.GetLength(0))
                                    {
                                        Console.WriteLine("Неверное расположение");
                                        break;
                                    }
                                }
                                Console.WriteLine("Неверное расположение");
                            }

                        }
                        DrawGrid(grid);
                        Console.WriteLine("Как поставить корабль Вертикально - 1 Горизонтально - 2");
                        horizontal = (Console.ReadLine());


                        // сделать так чтобы была одно выставление корабля и был выбор расстановки заного чтобы вернулся в начало метода 

                        //    if (int.Parse(horizontal) == 1) //Если Вертикально 
                        //    {

                        //    }
                        //else if (int.Parse(horizontal) == 2) //Если Горизонтально 
                        //{


                    }
                }
                else { Console.WriteLine("Неверный ввод: Введите число"); }


            }





        }
        /// <summary>
        /// Отметки выстрелов на карте 
        /// </summary>
        /// <param name="grid"></param>
        public static void hitMark(char[,] grid)
        {
            Console.WriteLine($"Выберете координаты для выстрела ");
            Console.WriteLine($"Выберете Ряд для выстрела 0-9 ");
            string rowhit = Console.ReadLine();
            Console.WriteLine($"Выберете Столбец для выстрела 0-9 ");
            string colhit = Console.ReadLine();
            int hitin = Convert.ToInt32(rowhit);
            int colin = Convert.ToInt32(colhit);
            if (hitin > grid.GetLength(0) || colin > grid.GetLength(1))
            {
                Console.WriteLine($"Выстрел за предел карты");
            }
            else
            {
                if (grid[hitin, colin] == '#')
                {
                    Console.WriteLine("Попадание");
                    grid[hitin, colin] = 'X';
                }
                else if (grid[hitin, colin] == 'X')
                {
                    Console.WriteLine("Промах Вы уже стреляли сюда");

                }
                else
                {
                    grid[hitin, colin] = '*';
                    Console.WriteLine("Мимо!");
                }
            }
        }

        
    

        
        /// <summary>
        /// Проверка на попадание по части корабля
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="rowhit"></param>
        /// <param name="colhit"></param>
        /// <returns></returns>
        public static bool shipSunk(char[,] grid, int rowhit, int colhit)
        {
            bool rowSunk = true;
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[rowhit, i] == '#')
                {
                    rowSunk = false;
                    break;
                }
            }
            bool colSunk = true;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, colhit] == '#')
                {
                    colSunk = false;
                    break;
                }
            }

            return rowSunk || colSunk;

        }
        public static bool allShipsSunk(char[,] grid)
        {
            foreach (char cell in grid)
            {
                if (cell == '#')
                {
                    return false; // Найден непотопленный корабль
                }
            }
            return true;

        }
        public static void allShipsisSunk(char[,] p1map, char[,] p2map)
        {
            bool player1= true;
            while (!allShipsSunk(p1map) && !allShipsSunk(p2map))
            {
                if (player1) 
                {
                    Console.Clear();
                    Console.WriteLine("Ход Первого игрока");
                    hitMark(p2map);
                    DrawGridforplay(grid, p1map);


                }
                else 
                {
                    Console.WriteLine("Ход Второго игрока");
                    hitMark(p1map);
                    DrawGridforplay(grid, p2map);
                }
                player1 = !player1;
                    
            }
            if (allShipsSunk(p1map)) { Console.WriteLine("Все корабли игрока 2 потоплены ПОБЕДА"); }
            else { Console.WriteLine("Все корабли игрока 1 потоплены ПОБЕДА"); }
        }
    }
}

// Сделать проверку после выстрела передача другому игроку если есть попадание передеть на след ход если все корабли потоплены написать победа 

