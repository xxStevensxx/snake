using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using SceneSys.Interfaces;

namespace SceneSys
{
    class Snake : ISnake
    {

        private Queue<(int x, int y)> body = new Queue<(int x, int y)>();
        private enum Direction {NONE, UP, DOWN, LEFT, RIGHT}
        private Direction currentDir = Direction.NONE;
        private bool sStarted { get; set; }
        private float speed;
        


        public Snake(int startX, int startY, int bodySize, float speed) {

            for (int segment = 0; segment < bodySize; segment++) {
            
                body.Enqueue((startX, startY));
            }

        }


        //public Snake(Queue<(int x, int y)> body)
        //{

        //    this.body = body;
        //}

        public void AddSegment() {

            var head = body.Last();
            body.Enqueue((head.x, head.y));

        }
        public void DelSegment() {

            if (body.Count > 1)
            {
                body.Dequeue();
            }   
        }


        public void Dir() 
        {

            if (IsKeyPressed(KeyboardKey.Up) && currentDir != Direction.DOWN) {
                currentDir = Direction.UP;
            }
            if (IsKeyPressed(KeyboardKey.Down) && currentDir != Direction.UP) {
                currentDir = Direction.DOWN;
            }
            if (IsKeyPressed(KeyboardKey.Left) && currentDir != Direction.RIGHT) {
                currentDir = Direction.LEFT;
            }
            if (IsKeyPressed(KeyboardKey.Right) && currentDir != Direction.LEFT) {
                currentDir = Direction.RIGHT;
            }
        }


        public Queue<(int x, int y)> GetCurrentPos() {

            return body;
        }
        
        public void Update() {

            Dir();

            var head = body.Last();
            int newPosX = head.x;
            int newPosY = head.y;


            switch (currentDir) {

                case Direction.UP: newPosY -= 1; break;
                case Direction.DOWN: newPosY += 1; break;
                case Direction.LEFT: newPosX -= 1; break;
                case Direction.RIGHT: newPosX += 1; break;
            }

            body.Enqueue((newPosX, newPosY));
            body.Dequeue();
        }

        public void Draw() {

            (int x, int y) head = body.Last() ;

            foreach (var (row, col) in body) {

                Color colSnake = (row, col) == head ? Color.Green : Color.DarkGreen;

                var (px, py) = Grid.Instance.CellToScreen(row, col);

                DrawRectangle(px, py, Grid.Instance.getCellSize().cellW, Grid.Instance.getCellSize().cellH, colSnake);

            }

        }

    }
}
