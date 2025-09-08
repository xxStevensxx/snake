using Raylib_cs;
using SceneSys.Interfaces;

//using System;
using static Raylib_cs.Raylib;
//using static SceneSys.EnumType;

namespace SceneSys
{
    class SceneOption : IScene
    {
        public string Name { get; set; }


        public void Draw()
        {

        }

        public void Show()
        {
            DrawText($"Bonjour je suis le {EnumType.Scene.Option}", 50, GetScreenHeight() / 2, 35, Color.Magenta);
            Console.WriteLine($"Show scene{EnumType.Scene.Option}");

        }


        public void Hide()
        {

            Console.WriteLine($"Hide scene{EnumType.Scene.Option}");
        }


        public void Close()
        {

            Console.WriteLine($"Close scene{EnumType.Scene.Option}");

        }
        public void Update()
        {
            //if (IsKeyPressed(KeyboardKey.Escape))
            //{
            //    GameState.Instance.ChangeScene(EnumType.Scene.Menu);
            //    Name = EnumType.Scene.Menu.ToString();
            //    Console.WriteLine($"name: {Name}");
            //}
        }
    }
}
