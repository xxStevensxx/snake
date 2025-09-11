using Raylib_cs;
using SceneSys.Interfaces;
using System.ComponentModel;
using System.Numerics;
using static Raylib_cs.Raylib;



namespace SceneSys
{
    class SceneManager : IGameLoop
    {

        IScene sceneGamePlay;
        IScene sceneMenu;
        IScene sceneOption;
        IScene sceneGameOver;
        IScene currentScene;

        GameState gameState;

        //singleton
        private static SceneManager? instance;
       
        public static SceneManager Instance => instance ??= new SceneManager();



        // constructeur qui bloque les instanciation ext
        private SceneManager(){

            // dip dependecy inversion principe les modules haut et bas ne doivent dépendre que d'abstraction
            sceneMenu = new SceneMenu();
            sceneGamePlay = new SceneGamePlay();
            sceneOption = new SceneOption();
            sceneGameOver = new SceneGameOver();

            //Singleton
            gameState = GameState.Instance;

            gameState.RegisterScene(EnumType.Scene.Menu, sceneMenu);
            gameState.RegisterScene(EnumType.Scene.GamePlay, sceneGamePlay);
            gameState.RegisterScene(EnumType.Scene.Option, sceneOption);
            gameState.RegisterScene(EnumType.Scene.GameOver, sceneGameOver);
            gameState.ChangeScene(EnumType.Scene.Menu);


        }

        public void OnInit(){}

        public void Load() 
        {
            sceneGamePlay.Load();
        }
        public void Update()
        {
            gameState.Update();
            //sceneGamePlay.Update();

        }

        public void Draw()
        {
            gameState.Draw();
            //sceneGamePlay.Draw();

        }

        public void RemoveScene()
        {
            gameState.RemoveScene();

        }

    }
}
