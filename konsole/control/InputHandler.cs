using System.Drawing;
using System.Numerics;
using Konsole.konsole.utility;
using Raylib_CsLo;
using Color = System.Drawing.Color;

namespace Konsole.konsole.control;

public static class InputHandler
{
    public static int CameraMovementSpeed { get; set; }= 2;
    public static Action<Einpacker> Listen { get; set; }

    public static void Hey_Listen()    //Navi reference xD
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F1))   //Fullscreen
        {
            Util.ToggleFullscreen();
        }
        Listen(new Einpacker
        {
            Start = Vector2.Zero,                               // 0, 0
            Size = new Vector2(Mcd.CanvasW, Mcd.CanvasH)  // 2, 5d k.h 
        });

        /*if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT_SHIFT))
        {
            Mcd.CharSize++;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT))
        {
            if(Mcd.CharSize>1)
                Mcd.CharSize--;
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            Mcd.YOffset+=CameraMovementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            Mcd.YOffset-=CameraMovementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            Mcd.XOffset+=CameraMovementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            Mcd.XOffset-=CameraMovementSpeed;
        }*/
    }
}