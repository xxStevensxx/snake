using Raylib_cs;
using SceneSys;
using static Raylib_cs.Raylib;
using static SceneSys.SceneManager;


class Program()
{

    public static int Main()
    {

        InitWindow(1200, 800, "Scene");
        SceneManager.Instance.Load();
        SetTargetFPS(5);
        SetExitKey(KeyboardKey.Null);
       

        
        while (!WindowShouldClose()) {

            BeginDrawing();
            SceneManager.Instance.Update();
            ClearBackground(Color.Black);
            SceneManager.Instance.Draw();
            EndDrawing();

        }

        SceneManager.Instance.RemoveScene();
        CloseWindow();
        return 0;
    }

}