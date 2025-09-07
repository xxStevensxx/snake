using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using SceneSys.Interfaces;

namespace SceneSys
{
    class Snake : ISnake
    {

        private Queue<(int x, int y)> segments = new Queue<(int x, int y)>();
        private enum Direction {NONE, UP, DOWN, LEFT, RIGHT}
        private Direction currentDir = Direction.NONE;
        private(int x, int y)[] snakePos;    

        public Snake() {

            segments.Enqueue((6, 1));
            segments.Enqueue((6, 2));
            segments.Enqueue((6, 3));
        }
        public Snake(Queue<(int x, int y)> segment){

            this.segments = segment;
        }

        public void AddSegment() {
            segments.Enqueue((5, 5));
        }
        public void DelSegment() {}


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

        public void Update() {

            Dir();

            var head = segments.Last();
            int newPosX = head.x;
            int newPosY = head.y;


            switch (currentDir) {

                case Direction.UP: newPosY -= 1; break;
                case Direction.DOWN: newPosY += 1;break;
                case Direction.LEFT: newPosX -= 1;break;
                case Direction.RIGHT: newPosX += 1; break;
            }

            segments.Enqueue((newPosX, newPosY));
            segments.Dequeue();
        }

        public void Draw() {

            var head = segments.Last() ;

            foreach (var (row, col) in segments) {

                Color colSnake = (row, col) == head ? Color.Green : Color.DarkGreen;

                var (px, py) = Grid.Instance.CellToScreen(row, col);

                DrawRectangle(px, py, Grid.Instance.getCellSize().cellW, Grid.Instance.getCellSize().cellH, colSnake);

            }

        }

    }
}
