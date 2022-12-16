using Konsole.konsole.control;
using Konsole.konsole.view;
using Raylib_CsLo;

namespace Konsole.konsole;

public class Konsole
{
    const string Resources = @"../../../konsole/resources";
    public static ConsoleBuffer? Buffer;
    public static BuffToScreen? BuffScreen;

    public static void Main()
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(1000, 500, "Konsole");
        var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture($"{Resources}/icon.png"));
        Raylib.SetWindowIcon(icon);
        //init control
        Buffer = new ConsoleBuffer(500,100);    //initialize console-buffer
        BuffScreen = new BuffToScreen();


        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            //begin code
            BuffScreen.ScreenWidth = Raylib.GetScreenWidth();
            BuffScreen.ScreenHeight = Raylib.GetScreenHeight();
            
            //end code
            Raylib.ClearBackground(Raylib.DARKGRAY);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
        Raylib.UnloadImage(icon);
    }

}