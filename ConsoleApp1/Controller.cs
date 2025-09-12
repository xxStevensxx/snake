using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using SceneSys.Interfaces;

namespace SceneSys
{
    class Controller : IController
    {
        private enum Direction { NONE, UP, DOWN, LEFT, RIGHT }
        private Direction currentDir = Direction.NONE;
        float timer = 0;
        float interval = 0.1f;

        public void KeyDir() {

            if (IsKeyPressed(KeyboardKey.Up) && currentDir != Direction.DOWN)
            {
                currentDir = Direction.UP;
            }
            if (IsKeyPressed(KeyboardKey.Down) && currentDir != Direction.UP)
            {
                currentDir = Direction.DOWN;
            }
            if (IsKeyPressed(KeyboardKey.Left) && currentDir != Direction.RIGHT)
            {
                currentDir = Direction.LEFT;
            }
            if (IsKeyPressed(KeyboardKey.Right) && currentDir != Direction.LEFT)
            {
                currentDir = Direction.RIGHT;
            }
        }

        public void SnakeDir(Snake snake) 
        {

            Queue<(int x, int y)> snakeBody = snake.GetCurrentPos();
            KeyDir();
            timer += GetFrameTime();


            if (timer >= interval)
            {
                timer = 0;

                var head = snakeBody.Last();
                int newPosX = head.x;
                int newPosY = head.y;



                switch (currentDir)
                {

                    case Direction.UP: newPosY -= 1; break;
                    case Direction.DOWN: newPosY += 1; break;
                    case Direction.LEFT: newPosX -= 1; break;
                    case Direction.RIGHT: newPosX += 1; break;
                }

                snakeBody.Enqueue((newPosX, newPosY));
                snakeBody.Dequeue();

            }

        }  


    }
}
