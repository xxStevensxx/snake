using Raylib_cs;
using SceneSys.Interfaces;
using System;
using System.Numerics;
using static Raylib_cs.Raylib;
using static SceneSys.EnumType;

namespace SceneSys
{
    class SceneGamePlay : IScene
    {
        ISnake snake;
        Food food;
        Grid grid;
        Vector2 mousePos;
        
        public string Name { get; set; }


        public void Show()
        {

            Console.WriteLine($"Show scene{EnumType.Scene.GamePlay}");
        }


        public void Hide()
        {

            Console.WriteLine($"Hide scene{EnumType.Scene.GamePlay}");
        }


        public void Close()
        {

            Console.WriteLine($"Close scene{EnumType.Scene.GamePlay}");

        }

        public void Load() 
        {
            grid = Grid.Instance;
            food = new Food(4, 4);
            snake = new Snake();
        }
        public void Update() {

            mousePos = GetMousePosition();
            snake.Update();
            if (IsKeyPressed(KeyboardKey.M)) {

                GameState.Instance.ChangeScene(EnumType.Scene.Menu);

            }

        }

        public void Draw()
        {
            DrawText("Bonjour je suis le GamePlay", 50, GetScreenHeight() / 2, 35, Color.RayWhite);

            //grid.Draw();
            snake.Draw();
            DrawText(mousePos.ToString(), 10, 10, 50, Color.SkyBlue);

        }



    }
}
