using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Diagnostics;
using SceneSys.Interfaces;


namespace SceneSys
{
    class GameState : IGameLoop
    {

        //Singleton
        private static GameState? instance;

        private IScene? currentScene;

        // Init GameState Instance
        public static GameState Instance => instance ??= new GameState();


        private Dictionary<Enum, IScene> scenes;

        //Constructeur
        public GameState() {

            scenes = new Dictionary<Enum, IScene>();

        }

        public void RegisterScene(Enum eName, IScene scene) {

            scenes[eName] = scene;
  
        }

        public void ChangeScene(Enum enumId)
        {


            if (currentScene != null) {

                currentScene.Hide(); 
                

            }
            if (scenes.ContainsKey(enumId))
            {
                scenes[enumId].Show();
                currentScene = scenes[enumId];
                

                Debug.WriteLine($"current scene {enumId}");
                Debug.WriteLine($"Changement de Scene: {enumId} ");
                
            }
            else
            {
                string error = $"scene {enumId} non trouvé dans le dico";
                Debug.WriteLine(error);
            }
        }

        public string getCurrentSceneName()
        {
            return (currentScene?.Name ?? "No Scene").ToString();
        }   

        public void RemoveScene()
        {

            foreach (KeyValuePair<Enum, IScene> scene in scenes)
            {

                scene.Value.Close();
            }

        }

        public void Update()
        {

            currentScene?.Update();
        }

        public void Draw()
        {
            currentScene?.Draw();
        }

    }
}
