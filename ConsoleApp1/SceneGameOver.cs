using Raylib_cs;
using SceneSys.Interfaces;
using static Raylib_cs.Raylib;
using static SceneSys.EnumType;


namespace SceneSys
{
    class SceneGameOver : IScene
    {
        //button DIP
        private IGui<Button> restartButton;
        private IGui<Button> menuButton;
        private IGui<Button> quitButton;
        private IGui<Button> buttonsList = new ButtonList();

        public string Name { get; set; }

        public SceneGameOver()
        {


            menuButton = new Button { Rect = new Rectangle(((GetScreenWidth() / 2) - 100), ((GetScreenHeight() / 2) - 10), 200, 40), Txt = "Menu", Clr = Color.Magenta };
            restartButton = new Button { Rect = new Rectangle(((GetScreenWidth() / 2) - 100), ((GetScreenHeight() / 2) - 45), 200, 40), Txt = "Restart", Clr = Color.Magenta };     
            quitButton = new Button { Rect = new Rectangle(((GetScreenWidth() / 2) - 100), ((GetScreenHeight() / 2) - 20) + 90, 200, 40), Txt = "Quitter", Clr = Color.Magenta };

            buttonsList.AddButton((Button)restartButton);
            buttonsList.AddButton((Button)menuButton);
            buttonsList.AddButton((Button)quitButton);

        }

        public void Draw()
        {

            buttonsList.Draw();
            DrawText("Game Over", GetScreenWidth() / 2, 10, 35, Color.Red);

        }

        public void Show()
        {
            Console.WriteLine($"Show scene{EnumType.Scene.Menu}");
        }


        public void Hide()
        {

            Console.WriteLine($"Hide scene{EnumType.Scene.Menu}");
        }


        public void Close()
        {

            Console.WriteLine($"Close scene{EnumType.Scene.Menu}");

        }


        public void Update()
        {

            buttonsList.Update();

            if (restartButton.IsClicked())
            {
                GameState.Instance.Restart(GameState.Instance.getCurrentSceneName());
                GameState.Instance.ChangeScene(EnumType.Scene.GamePlay);
            }


            if (menuButton.IsClicked())
            {
                GameState.Instance.Restart(GameState.Instance.getCurrentSceneName());
                GameState.Instance.ChangeScene(EnumType.Scene.Menu);
            }

            if (quitButton.IsClicked())
            {

                CloseWindow();
                Environment.Exit(0);

            }

        }

    }
}

