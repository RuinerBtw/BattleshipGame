using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    // Для чего здесь наследование от sips? Нужно ли оно?
    /// <summary>
    /// Класс описывающий игрока
    /// </summary>
    public class Players
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string FirstName { set; get; }

        /// <summary>
        /// Фамилия игрока
        /// </summary>
        public string LastName { set; get; }


        // В этом классе нужно создать параметры определяющие пользователя (имя, и возможно поле area)
        public static void inPlayer1()
        {
            // Здесь, в комментариях опиши алгоритм твоей программы. Просто словами. Например (!):
            // Выводим приветствие
            Console.WriteLine("Добро пожаловать, в игру Морской Бой!");
            // Запрашиваем ФИО первого игрока
            Players p1 = new Players();
            Console.WriteLine("Игрок, введите имя");
            p1.FirstName = Console.ReadLine();
            Console.WriteLine($"{p1.FirstName}, введите фамилию");
            p1.LastName = Console.ReadLine();
            Console.WriteLine($"{p1.FirstName} {p1.LastName}, приятно познакомиться! \nДавайте расставим корабли.");
        }
        public static void inPlayer2()
        {
            // Здесь, в комментариях опиши алгоритм твоей программы. Просто словами. Например (!):
            // Выводим приветствие
            Console.WriteLine("Добро пожаловать, в игру Морской Бой!");
            // Запрашиваем ФИО первого игрока
            Players p2 = new Players();
            Console.WriteLine("Первый игрок, введите имя");
            p2.FirstName = Console.ReadLine();
            Console.WriteLine($"{p2.FirstName}, введите фамилию");
            p2.LastName = Console.ReadLine();
            Console.WriteLine($"{p2.FirstName} {p2.LastName}, приятно познакомиться! \nДавайте расставим корабли.");
        }


      
       

    }







}
