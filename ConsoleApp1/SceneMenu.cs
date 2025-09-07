using Raylib_cs;
using SceneSys.Interfaces;
using static Raylib_cs.Raylib;
using static SceneSys.EnumType;

namespace SceneSys
{
    class SceneMenu : IScene
    {

        //button DIP
        private IGui<Button> playButton;
        private IGui<Button> optionButton;
        private IGui<Button> quitButton;
        private IGui<Button> buttonsList = new ButtonList();

        public string Name { get; set; }

        public SceneMenu()
        {

            playButton = new Button { Rect = new Rectangle(10, 40, 200, 40), Txt = "Play", Clr = Color.Yellow };
            optionButton = new Button { Rect = new Rectangle(10, 90, 200, 40), Txt = "Options", Clr = Color.Blue }; 
            quitButton = new Button { Rect = new Rectangle(10, 140, 200, 40), Txt = "Quitter", Clr = Color.Green};

            buttonsList.AddButton((Button)playButton);
            buttonsList.AddButton((Button)optionButton);
            buttonsList.AddButton((Button)quitButton);

        }

        public void Draw() {

            buttonsList.Draw();
            //DrawText("Bonjour je suis le Menu ", 50, GetScreenHeight() / 2, 35, Color.RayWhite);

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

            buttonsList.Update();

            if (playButton.IsClicked()) {

                GameState.Instance.ChangeScene(EnumType.Scene.GamePlay);    
            }

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
