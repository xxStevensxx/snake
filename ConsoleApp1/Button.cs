using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using SceneSys.Interfaces;

namespace SceneSys
{
    class Button : IGui<Button>
    {

        public Rectangle Rect { get; private set; }
        public string? Txt { get; private set; }
        public Color Clr { get; set; }
        public string Name { get; set; }
    }

    class ButtonList : IGui<Button>, IScene
    {
        private List<Button> buttons = new List<Button>();
        public string Name { get ; set; }


        public void AddElement(Button button) {

            buttons.Add(button);

        }

        public void Update() {}
        public void Draw() {}
    }
}
