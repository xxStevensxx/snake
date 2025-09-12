using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace SceneSys
{
    class Animator
    {
        //Singelton
        private static Animator? instance;
        public static Animator Instance => instance ??= new Animator();


        private float shakeTime = 0.0f;
        private float shakeDuration = 0.5f;
        private float shakeMagnitude = 5.0f;
        private Random rnd = new Random();

        public void ShakeTimer() {

            shakeTime = shakeDuration;
        }
        public Camera2D GetCam()
        {

            Vector2 camOffset = Vector2.Zero;
            //shakeTime = shakeDuration;?

            if (shakeTime > 0)
            {
                shakeTime -= GetFrameTime();
                float offsetX = (float)(rnd.NextDouble() * 2 - 1) * shakeMagnitude;
                float offsetY = (float)(rnd.NextDouble() * 2 - 1) * shakeMagnitude;
                camOffset = new Vector2(offsetX, offsetY);
            }

            //shakeTime = 0f;
            return new Camera2D
            {
                Target = Vector2.Zero,
                Offset = camOffset,
                Zoom = 1f,
                Rotation = 0f,

            };

            
        }
    }
}
