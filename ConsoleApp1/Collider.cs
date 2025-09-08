using SceneSys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneSys
{
    class Collider : IGameLoop
    {
        private int row;    
        private int col;
        public Collider(int row, int col)
        {
            
            this.row = row;
            this.col = col; 

        }

        public bool WallCollider((int x, int y) head) {

            return head.x < 0 || head.y < 0 || head.x > row || head.y > col;
        }

        public bool ItSelfCollider(Queue<(int x, int y)> head, Queue<(int x, int y)> body) {

            //TODO
            return false;

        }


        public bool FoodCollider((int x, int y) head, (int x, int y) food)
        {
            return head.x == food.x && head.y == food.y;
        }

    }
}
