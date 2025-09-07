using SceneSys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SceneSys
{
    class Food : IGameLoop
    {
        private static Random rnd = new Random((int)DateTime.Now.Ticks);
        private int posX;
        private int posY;
        private string type;
        public Food(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.type = RandomFood();
        }


        // bon mon charabia je renvoi l'index de maniere random de mon tableau d'enum de type FoodType
        public string RandomFood() {

            var value = Enum.GetValues<EnumType.FoodType>();
            int index = rnd.Next(value.Count());
            return value[index].ToString();

        }

        public void Update() {}
        public void Draw() {}

    }
}
