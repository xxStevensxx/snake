using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using SceneSys.Interfaces;
using System.ComponentModel;

namespace SceneSys
{
    class Grid : IGrid
    {


        //singleton
        private static Grid? instance;


        //Bodied Expression instance est null ? oui garde la valeur sinon instancie le
        public static Grid Instance => instance ??= new Grid(12, 8, 90, 90);

        private int row;
        private int column;
        private int cellW;
        private int cellH;
        private Vector2 size;
        private int spaceBetween = 5;

        public Grid(int row, int column, int cellW, int cellH) {

            this.row = row;
            this.column = column;
            this.cellW = cellW;
            this.cellH = cellH;
            this.size = new Vector2(this.row * (this.cellW + spaceBetween), this.column * (this.cellH + spaceBetween));
        }

        public (int x, int y) CellToScreen(int r, int c) {


            int offSetX = GetScreenWidth() / 2 - (int)size.X / 2;
            int offSetY = GetScreenHeight() / 2 - (int)size.Y / 2;

            int x = offSetX + r * (cellW + spaceBetween);
            int y = offSetY + c * (cellH + spaceBetween);

            return (x, y);

        }

        public (int cellW, int cellH) getCellSize() {
        
            return (cellW, cellH);

        }


        public (int row, int column) getGridSize()
        {
            return (row, column);
        }


        public void Draw()
        {

            for (int r = 0; r < row; r++)
            {

                for (int c = 0; c < column; c++)
                {

                    var (x, y) = CellToScreen(r, c);

                    DrawRectangleLines(x, y, cellW, cellH, Color.Magenta);
                    //DrawText($"posX: {r}, posY: {c}", x, y, 3, Color.Gold);
                    //DrawText($"X pix: {x}, Y pix: {y}", x, y + 15, 3, Color.Gold);

                }

            }

        }
    }
}
