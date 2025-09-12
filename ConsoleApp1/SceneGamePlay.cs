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
        Collider collider;
        //Vector2 mousePos;
        Queue<(int x, int y)> snakePos;
        Camera2D cam2D;


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

        public void Restart() {
            Score.Instance.Restart();
            Load();
        }

        public void Load() 
        {
            
            grid = Grid.Instance;
            food = new Food();
            snake = new Snake(6, 1, 3, 5);
            collider = new Collider(grid.getGridSize().row, grid.getGridSize().column);
        }
        public void Update() {

            //mousePos = GetMousePosition();
            snake.Update();
            snakePos = snake.GetCurrentPos();
            collider.ItSelfCollider(snake);
            collider.WallCollider(snakePos.Last());
            collider.FoodCollider(snake, food);
            food.Update();

        }

        public void Draw()
        {

            cam2D = Animator.Instance.GetCam();   
            Score.Instance.Draw();
            BeginMode2D(cam2D);
            snake.Draw();
            food.Draw();
            grid.Draw();
            EndMode2D();
            //DrawText(mousePos.ToString(), 10, 10, 50, Color.SkyBlue);
        }


    }
}
