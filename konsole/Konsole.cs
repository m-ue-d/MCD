using System.Numerics;
using Konsole.konsole.control;
using Konsole.konsole.view;
using Raylib_CsLo;

namespace Konsole.konsole;

public class Konsole
{
    const string Resources = @"../../../konsole/resources";
    public static ConsoleBuffer? Buffer;
    public static Font Font_;

    public static void Main()
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(1000, 500, "Konsole");
        var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture($"{Resources}/icon.png"));
        Raylib.SetWindowIcon(icon);
        Buffer = new ConsoleBuffer(100,50);    //initialize console-buffer
        InputHandler.Init(Buffer);

        
        
        
        //TODO: START of temporary
        //fill buffer
        for (var i = 0; i < Buffer.Length; i++)
        {
            Buffer.Set(i, new BuffChar(new Random().Next().ToString().ToCharArray()[0],0xFFFFFFFF));
        }
        //TODO: END of temporary

        
        
        
        
        Font_ = Raylib.LoadFontEx($"{Resources}/Monocraft.otf", 96, 0);// set font to a monospaced-font
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            //begin code

            InputHandler.Listen();

            BuffToScreen.DrawBuffer(Buffer);

            //end code
            Raylib.ClearBackground(Raylib.BLACK);
            Raylib.EndDrawing();
        }
        Raylib.UnloadFont(Font_);
        Raylib.CloseWindow();
        Raylib.UnloadImage(icon);
    }

}