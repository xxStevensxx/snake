using Raylib_cs;
using SceneSys.Interfaces;
using static Raylib_cs.Raylib;
using static SceneSys.EnumType;

namespace SceneSys
{
    class SceneMenu : IScene
    {

        //button DIP
        IGui<Button> playButton;
        IGui<Button> optionButton;
        IGui<Button> quitButton;

        public string Name { get; set; }

        public SceneMenu()
        {
            playButton = new Button();
            optionButton = new Button();
            quitButton = new Button();
        }

        public void Draw() {

            DrawText("Bonjour je suis le Menu ", 50, GetScreenHeight() / 2, 35, Color.RayWhite);

        }

        public void Show()
        {
            Console.WriteLine($"Show scene{EnumType.Scene.Menu}");
        }


        public void Hide() {

            Console.WriteLine($"Hide scene{EnumType.Scene.Menu}");
        }


        public void Close() {

            Console.WriteLine($"Close scene{EnumType.Scene.Menu}");

        }


        public void Update()
        {

            if (IsKeyPressed(KeyboardKey.G)) {

                GameState.Instance.ChangeScene(EnumType.Scene.GamePlay);

            }

            if (IsKeyPressed(KeyboardKey.O))
            {

                GameState.Instance.ChangeScene(EnumType.Scene.Option);

            }
        }
        
    }
}
