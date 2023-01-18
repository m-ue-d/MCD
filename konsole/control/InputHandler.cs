using System.Drawing;
using System.Numerics;
using Konsole.konsole.utility;
using Raylib_CsLo;
using Color = System.Drawing.Color;

namespace Konsole.konsole.control;

public static class InputHandler
{
    
    public static void Listen()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_X))
        {
            var x = new Random().Next(0,Konsole.Canvas.Length);
            Konsole.Canvas[x] = new Character("@", Raylib.GetColor((uint)new Random().Next(0,0xFFFFFFF)*0xF));
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            for (var i = 0; i < Konsole.Canvas.Length; i++)
            {
                Konsole.Canvas[i] = new Character("#",Raylib.GetColor((uint)new Random().Next(0,0xFFFFFFF)*0xF));
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
            Konsole.YOffset+=2;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            Konsole.YOffset-=2;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            Konsole.XOffset+=2;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            Konsole.XOffset-=2;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_I))
        {
            int steps = 1;
            
#pragma warning disable CA1416
            var bm = new Bitmap(@"C:\Users\fabia\Desktop\test.jpg");

            Konsole.Canvas = new Character[(bm.Width / steps) * (bm.Height / steps)];
            
            for (var i = 0; i < bm.Height/steps; i++)
            {
                for (var j = 1; j < bm.Width/steps; j++)
                {
                    var pixel = Color.White;
                    if(i*steps<bm.Width && j*steps<bm.Height)
                        pixel = bm.GetPixel(j*steps,i*steps);
                    string hex = pixel.R.ToString("X2") + pixel.G.ToString("X2") + pixel.B.ToString("X2") + "FF";
                    Raylib_CsLo.Color color = Raylib.GetColor(Convert.ToUInt32(hex,16));
                    if(Konsole.Canvas.Length > (i*bm.Height/steps+j) && (i*bm.Height/steps+j) >= 0)
                        Konsole.Canvas[i*bm.Height/steps+j] =new Character(Util.GetCharByBrightness(color.GetBrightness()), color);
                }
                if(Konsole.Canvas.Length > (i*(bm.Height-1)/steps) && (i*(bm.Height-1)/steps)>=0)
                    Konsole.Canvas[i*(bm.Height-1)/steps] = new Character("\n",Raylib.WHITE);
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_T)) //Testing
        {
            Konsole.Canvas[0] = new Character("a", Raylib.WHITE);
            Konsole.Canvas[1] = new Character("b", Raylib.WHITE);
            Konsole.Canvas[2] = new Character("c", Raylib.WHITE);
            Konsole.Canvas[3] = new Character("d", Raylib.WHITE);
            Konsole.Canvas[4] = new Character("a", Raylib.WHITE);
            Konsole.Canvas[5] = new Character("b", Raylib.WHITE);
            Konsole.Canvas[6] = new Character("c", Raylib.WHITE);
            Konsole.Canvas[7] = new Character("d", Raylib.WHITE);
            
            string hex = "FF0000FF";
            Raylib_CsLo.Color color = Raylib.GetColor(Convert.ToUInt32(hex,16));
            Console.WriteLine(color.GetBrightness());
        }
    }
}