using SceneSys.Interfaces;
using Raylib_cs;
using SceneSys.Interfaces;
using static Raylib_cs.Raylib;
using static SceneSys.EnumType;

namespace SceneSys
{
    class Score : IGameLoop
    {

        private static Score? instance;

        public static Score Instance => instance ??= new Score();

        private int points;

        public void addPoints(FoodType type)
        {
            points += type switch
            {

                FoodType.NORMAL => 10,
                FoodType.VENIMOUS => 20,
                _ => 0
            };
        }

        public void Restart()
        {
            points = 0;
        }


        //public void Update() { }

        public void Draw()
        {
            DrawText($"Score : {points}", 10, 10, 30, Color.SkyBlue);
        }

    }
}
