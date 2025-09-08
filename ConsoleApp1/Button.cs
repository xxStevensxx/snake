using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using SceneSys.Interfaces;

namespace SceneSys
{
    class Button : IGui<Button>
    {

        public Rectangle Rect { get; set; }
        public string? Txt { get; set; }
        public Color Clr { get; set; }
        public string Name { get; set; }
        public bool isClicked { get; set; }

        public Color originalClr;

        public bool IsClicked()
        {
            return isClicked;
        }
    }

    class ButtonList : IGui<Button>
    {
        private List<Button> buttons = new List<Button>();
        public string Name { get ; set; }


        public void AddButton(Button button) {

            button.originalClr = button.Clr;
            buttons.Add(button);

        }


        public void Clicked() 
        {
            Vector2 mousePos = GetMousePosition();

            
            foreach (Button button in buttons)
            {
                button.isClicked = false;
                if (CheckCollisionPointRec(mousePos, button.Rect))
                {

                    button.Clr = Color.Orange;
                    Console.WriteLine("Hover"); 
                    if (IsMouseButtonPressed(MouseButton.Left)) 
                    { 
                        button.isClicked = true;
                        Console.WriteLine("Clicked");
                    }
                }
                else
                {

                    button.Clr = button.originalClr;
                }
            }
        }

        public void Update() 
        {
            Clicked();
        }
        public void Draw() 
        {
            foreach (Button button in buttons) {

                DrawRectangleRec(button.Rect, button.Clr);
                DrawRectangleLinesEx(button.Rect, 5, Color.Orange);
                DrawText(button.Txt, (int)button.Rect.X + 20, (int)button.Rect.Y + 10, 30, Color.Black);
            }
        }
    }
}
