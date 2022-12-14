

using Raylib_CsLo;

namespace Konsole;

public class Konsole
{
    const string Resources = @"../../../resources";

    public static void Main()
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(1000, 500, "Konsole");
        var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture($"{Resources}/Habicht.png"));
        Raylib.SetWindowIcon(icon);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            //begin code
            
            //end code
            Raylib.ClearBackground(Raylib.GOLD);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
        Raylib.UnloadImage(icon);
    }

}