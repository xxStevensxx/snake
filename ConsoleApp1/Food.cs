using Raylib_cs;
using static Raylib_cs.Raylib;
using SceneSys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SceneSys
{
    class Food : IGameLoop
    {
        private static Random rnd = new Random((int)DateTime.Now.Ticks);
        private int posX;
        private int posY;
        private EnumType.FoodType type;

        public Food()
        {
            this.posX = rnd.Next(Grid.Instance.getGridSize().row);
            this.posY = rnd.Next(Grid.Instance.getGridSize().column);
            this.type = RandomFood();
        }


        // bon mon charabia je renvoi l'index de maniere random de mon tableau d'enum de type FoodType
        public EnumType.FoodType RandomFood() {

            var value = Enum.GetValues<EnumType.FoodType>();
            int index = rnd.Next(value.Count());
            return value[index];

        }

        public (int x, int y) GetFoodPos()
        {
            return (posX, posY);
        }


        public void resPawnFood() 
        {
            type = RandomFood();
            posX = rnd.Next(Grid.Instance.getGridSize().row);
            posY = rnd.Next(Grid.Instance.getGridSize().column);
            Console.WriteLine("Food Eaten");
            
        }

        public void Update() {}


        public void Draw() {
            Color foodColor = type == (EnumType.FoodType.NORMAL) ? Color.Red : Color.Magenta;  
            var (px, py) = Grid.Instance.CellToScreen(posX, posY);
            DrawRectangle(px, py, Grid.Instance.getCellSize().cellW, Grid.Instance.getCellSize().cellH, foodColor);    
        }

    }
}
