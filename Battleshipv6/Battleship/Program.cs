﻿// See https://aka.ms/new-console-template for more information


using System;
using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    class Program0
    {

        static void Main()
        {

            // Создаём пустое поле
            //Players.inPlayer1();
            //Players.inPlayer2();
            Arena.InitializeGrid(Arena.grid);
            Arena.InitializeGrid(Arena.p1map);
            Arena.InitializeGrid(Arena.p2map);
            //Arena.DrawGrid(Arena.grid);
            //Arena.DrawGrid(Arena.p1map);
            Arena.DrawGridforplay(Arena.grid, Arena.grid);


            ////Запрашиваем размещение всех кораблей первого типа 
            Console.WriteLine("Расстановка Первого игрока");
            Arena.shipPlace(Arena.p1map);
            Console.WriteLine("Расстановка Второго игрока");
            Arena.shipPlace(Arena.p2map);
            Arena.allShipsisSunk(Arena.p1map, Arena.p2map);
            Arena.DrawGrid(Arena.grid);





            //1.Доработать цикл расстановки кораблей, чтобы было больше чем четыре палубы, а сколь угодно много.
            //2.Схлопнуть весь код расстановки кораблей, до одного метода, который на входе будет принимать размеры корабля, в виде параметра.

            // Запрашиваем размещение всех кораблей второго типа
            // Запрашиваем размещение всех кораблей третьего типа
            // Запрашиваем размещение всех кораблей четвертого типа типа
            // Сохранения позиций кораблей
            // Показываем карту с расставленными кораблями
            // Запрашиваем ФИО второго игрока
            // Создаём пустое поле для второго игрока
            // Запрашиваем размещение всех кораблей первого типа
            // Запрашиваем размещение всех кораблей второго типа
            // Запрашиваем размещение всех кораблей третьего типа
            // Запрашиваем размещение всех кораблей четвертого типа типа
            // Сохранения позиций кораблей
            // Объявление игры для первого игрока
            // Инициализация выстрела первого игрока 
            // Объявления результата выстрела
            // Если попадание показать урон на карте 
            // Если промах показать промах на карте 
            // Передача управления след игроку
            // Инициализация выстрела второго игрока 
            // Объявления результата выстрела
            // Если попадание показать урон на карте 
            // Если промах показать промах на карте
            // Объявление победителя

            // И т.д.


            Console.ReadKey();
            Console.Clear();

        }
    }
}


