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

            playButton = new Button { Rect = new Rectangle(((GetScreenWidth() / 2) - GameConst.WIDTH_BUTTON / 2),((GetScreenHeight() / 2) - GameConst.HEIGHT_BUTTON / 2) - GameConst.SPACEBETWEEN, GameConst.WIDTH_BUTTON, GameConst.HEIGHT_BUTTON), Txt = "Play", Clr = Color.Magenta };
            optionButton = new Button { Rect = new Rectangle(((GetScreenWidth() / 2) - GameConst.WIDTH_BUTTON / 2), ((GetScreenHeight() / 2) - GameConst.HEIGHT_BUTTON / 2) + GameConst.SPACEBETWEEN, GameConst.WIDTH_BUTTON, GameConst.HEIGHT_BUTTON), Txt = "Options", Clr = Color.Magenta }; 
            quitButton = new Button { Rect = new Rectangle(((GetScreenWidth() / 2) - GameConst.WIDTH_BUTTON / 2), ((GetScreenHeight() / 2) - GameConst.HEIGHT_BUTTON / 2) + GameConst.SPACEBETWEEN * 2, GameConst.WIDTH_BUTTON, GameConst.HEIGHT_BUTTON), Txt = "Quitter", Clr = Color.Magenta};

            buttonsList.AddButton((Button)playButton);
            //buttonsList.AddButton((Button)optionButton);
            buttonsList.AddButton((Button)quitButton);

        }

        public void Draw() {

            buttonsList.Draw();
            DrawText("Snaaaaaaaaaaaaaake SSSSS", GetScreenWidth() / 2, 10, 35, Color.Magenta);

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


            if (optionButton.IsClicked())
            {

                GameState.Instance.ChangeScene(EnumType.Scene.Option);
            }

            if (quitButton.IsClicked())
            {

                CloseWindow(); 
                Environment.Exit(0);

            }

        }
        
    }
}
