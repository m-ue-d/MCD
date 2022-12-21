using System.Drawing;
using System.Numerics;
using Raylib_CsLo;
using Color = System.Drawing.Color;

namespace Konsole.konsole.control;

public static class InputHandler
{
    private static ConsoleBuffer? _buffer;

    public static void Init(ConsoleBuffer? b)
    {
        _buffer = b;
    }

    public static void Listen()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_X))
        {
            var x = new Random().Next(0,_buffer?.Width??0);
            var y = new Random().Next(0,_buffer?.Height??0);
            _buffer?.Set(x,y, new BuffChar('@',((uint)new Random().Next(0,0xFFFFFFF))*0xF));
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
        {
            for (var i = 0; i < _buffer?.Length; i++)
            {
                _buffer.Set(i, new BuffChar('X',0xFFFFFFFF));
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
        {
            Console.WriteLine(Raylib.GetScreenWidth()+"   "+_buffer?.Width);
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
        {
            Bitmap map = new Bitmap(@"C:\Users\fabia\Desktop\babyyoda.jpg");

            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Color pixel = map.GetPixel(j,i);
                    string hex = pixel.R.ToString("X2") + pixel.G.ToString("X2") + pixel.B.ToString("X2")+"FF";
                    _buffer?.Set(j,i,new BuffChar('X',
                        Convert.ToUInt32(hex,16)));
                }
            }
        }
    }
}