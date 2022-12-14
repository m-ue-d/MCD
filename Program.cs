

using Raylib_CsLo;

public class Konsole
{

    public static void Main()
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(1000, 500, "Konsole");
        var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture("resources/Habicht.png"));
        Raylib.SetWindowIcon(icon);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            //code
            Raylib.ClearBackground(Raylib.GOLD);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
        Raylib.UnloadImage(icon);
    }

}