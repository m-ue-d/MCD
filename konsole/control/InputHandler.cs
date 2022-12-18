using System.Numerics;
using Raylib_CsLo;

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
            _buffer?.Set(x,y, new BuffChar('@',0xFF0000FF));
        }
    }
}