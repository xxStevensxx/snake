using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using SceneSys.Interfaces;
using System.Xml.Linq;
using System;

namespace SceneSys
{
    class Snake : ISnake
    {

        IController controller = new Controller();

        private Queue<(int x, int y)> body = new Queue<(int x, int y)>();
        private enum Direction {NONE, UP, DOWN, LEFT, RIGHT}
        private Direction currentDir = Direction.NONE;
        public bool JusteAte { get; set; } = false;
        private float ateTimer = 0f;
        public bool Drunk { get; set; } = false;
        
       




        public Snake(int startX, int startY, int bodySize, float speed) {

            for (int segment = 0; segment < bodySize; segment++) {
            
                body.Enqueue((startX, startY));
            }

        }

        public void AddSegment() {

            var head = body.Last();
            body.Enqueue((head.x, head.y));
            JusteAte = true;
            ateTimer = 0.5f; // 100ms de "grâce"

        }
        public void DelSegment() {

            if (body.Count > 1)
            {
                body.Dequeue();
            }   
        }

        public Queue<(int x, int y)> GetCurrentPos() {

            return body;
        }


        public void Update() {
           
            controller.KeyDir();
            controller.SnakeDir(this);

            if (this.Drunk)
            {
                controller.RevertDir(); 
            }


            if (ateTimer > 0f){ateTimer -= GetFrameTime();}
            
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
