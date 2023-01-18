using System.Drawing;
using System.Numerics;
using Konsole.konsole.utility;
using Raylib_CsLo;
using Color = System.Drawing.Color;

namespace Konsole.konsole.control;

public static class InputHandler
{
    public const int CameraMovementSpeed = 2;

    public static void Hey_Listen()    //Navi reference xD
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F1))   //Fullscreen
        {
            Util.ToggleFullscreen();
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            var r = new Random();
            for (var i = 0; i < Konsole.Canvas.Length; i++)
            {
                Konsole.Canvas[i] = new Character("#",Raylib.GetColor((uint)r.Next(0,0xFFFFFFF)*0xF));
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT_SHIFT))
        {
            Konsole.CharSize++;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT))
        {
            if(Konsole.CharSize>1)
                Konsole.CharSize--;
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            Konsole.YOffset+=CameraMovementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            Konsole.YOffset-=CameraMovementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            Konsole.XOffset+=CameraMovementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            Konsole.XOffset-=CameraMovementSpeed;
        }
    }
}