using System.Numerics;
using Konsole.konsole.control;
using Konsole.konsole.view;
using Raylib_CsLo;

namespace Konsole.konsole;

public class Konsole
{
    const string Resources = @"../../../konsole/resources";
    private static ConsoleBuffer? _buffer;
    public static Font Font_;

    public static void Main()
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(1000, 500, "Konsole");
        var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture($"{Resources}/icon.png"));
        Raylib.SetWindowIcon(icon);
        _buffer = new ConsoleBuffer(Raylib.GetScreenWidth()/10,Raylib.GetScreenHeight()/10);    //initialize console-buffer
        InputHandler.Init(_buffer);

        
        
        
        //TODO: START of temporary
        //fill buffer
        for (var i = 0; i < _buffer.Length; i++)
        {
            _buffer.Set(i, new BuffChar(new Random().Next().ToString().ToCharArray()[0],0xFFFFFFFF));
        }
        //TODO: END of temporary

        
        
        
        
        Font_ = Raylib.LoadFontEx($"{Resources}/Monocraft.otf", 96, 0);// set font to a monospaced-font
        while (!Raylib.WindowShouldClose())
        {
            _buffer.OnUpdate();
            
            Raylib.BeginDrawing();
            //begin code
            
            InputHandler.Listen();

            BuffToScreen.DrawBuffer(_buffer);

            //end code
            Raylib.ClearBackground(Raylib.BLACK);
            Raylib.EndDrawing();
        }
        Raylib.UnloadFont(Font_);
        Raylib.CloseWindow();
        Raylib.UnloadImage(icon);
    }
}