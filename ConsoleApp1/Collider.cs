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
        //private var head;
        //private var segment;


        public Collider(int row, int col)
        {
            
            this.row = row;
            this.col = col; 

        }

        public void WallCollider((int x, int y) head) {


            if (head.x < 0 || head.y < 0 || head.x > row || head.y > col) {


                GameState.Instance.Restart(GameState.Instance.getCurrentSceneName());
                GameState.Instance.ChangeScene(EnumType.Scene.GameOver);
            }

            
        }

        public bool ItSelfCollider(ISnake snake) {

            Queue<(int x, int y)> body = snake.GetCurrentPos();
            bool justAte = snake.JusteAte;

            if (body.Count > 3 && !justAte)
            {

                var head = body.Last();
                var bodyWithoutHead = body.Take(body.Count - 1);

                foreach (var segment in bodyWithoutHead)
                {
                    if (head.x == segment.x && head.y == segment.y)
                    {
                        Console.WriteLine("je suis pas cannibal");
                        GameState.Instance.Restart(GameState.Instance.getCurrentSceneName());
                        GameState.Instance.ChangeScene(EnumType.Scene.GameOver);
                        
                    }
                }
            }

            return false;

        }


        public void FoodCollider(ISnake snake, Food food)
        {
            Queue<(int x, int y)> snakeBody = snake.GetCurrentPos();

            (int x, int y) foodPos = food.GetFoodPos();

            (int x, int y) head = snakeBody.Last();

            if ( head.x == foodPos.x && head.y == foodPos.y) {

                
                snake.AddSegment();
                Score.Instance.addPoints(food.GetFoodType(food));

                if (food.GetFoodType(food) == EnumType.FoodType.VENIMOUS)
                {
                    snake.Drunk = true;
                }
                else {
                      snake.Drunk = false;
                }
                Animator.Instance.ShakeTimer();
                food.RandomFood();
                food.resPawnFood();

            }
;
        }


        public void Update() { }
    }
}
