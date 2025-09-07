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
    }

    class ButtonList : IGui<Button>
    {
        private List<Button> buttons = new List<Button>();
        public string Name { get ; set; }


        public void AddButton(Button button) {

            buttons.Add(button);

        }

        public void Update() {}
        public void Draw() 
        {
            foreach (Button button in buttons) {

                DrawRectangleRec(button.Rect, button.Clr);
                DrawRectangleLinesEx(button.Rect, 5, Color.White);
                DrawText(button.Txt, (int)button.Rect.X + 20, (int)button.Rect.Y + 10, 30, Color.Black);
            }
        }
    }
}
