using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    // Здесь нужно определить параметры кораблей (например: клетки, координаты, состояние клетки (битая/не битая))
    // Возможно имеет смысл добавить ещё один класс "cell" - клетка?
    public class Ships
    {
        public static int battlecruiser = 4; //линкор
        public static int destroyer = 3; //крейсера
        public static int gunboat = 2; //эсминцы
        public static int torpedoboat = 1; //торпедные катера

       public static int[] shipsamount = new int[2] {4,3};

    }

}