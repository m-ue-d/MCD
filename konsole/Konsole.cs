using System.Numerics;
using Konsole.konsole.control;
using Raylib_CsLo;

namespace Konsole.konsole;

public static class Konsole
{
    const string Resources = @"../../../konsole/resources";
    public static int ScreenW { get; set; } = 1100;
    public static int ScreenH { get; set; } = 620;
    
    public static int CharSize { get; set; } = 5;
    
    public static int CanvasW => ScreenW / CharSize;
    public static int CanvasH => ScreenH / CharSize;

    public static int YOffset { get; set; } = 0;
    public static int XOffset { get; set; } = 0;

    public static Character[] Canvas { get; set; } = { };

    public static Font Font { get; set; }
    
    public static void Main() {
        Init();
        while (!Raylib.WindowShouldClose()) {
            Update();
        }
        Close();
    }
    
    private static void Init() {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(ScreenW, ScreenH, "MCD");
        var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture($"{Resources}/icon.png"));
        Raylib.SetWindowIcon(icon);
        Raylib.SetTargetFPS(60);
        Raylib.InitAudioDevice();

        //Font = Raylib.LoadFontEx($"{Resources}/Monocraft.otf", 96, 0);
        
        Canvas = new Character[500000];
        /*for (var i = 0; i < Canvas.Length; i++) {
            var randColor = Raylib.GetRandomValue(0, 5) switch {
                0 => Raylib.WHITE,
                1 => Raylib.RED,
                2 => Raylib.GREEN,
                3 => Raylib.BLUE,
                4 => Raylib.YELLOW,
                5 => Raylib.PURPLE,
            };
            Canvas[i] = new Character('#', randColor);
        }*/
    }
    
    private static void Update() {
        ScreenW = Raylib.GetScreenWidth();
        ScreenH = Raylib.GetScreenHeight();
        InputHandler.Listen();
        Raylib.BeginDrawing();
        {
            Raylib.ClearBackground(Raylib.BLACK);

            var x = 0;
            var y = 0;
            foreach (var character in Canvas) {
                var pos = new Vector2(x * CharSize+XOffset, y * CharSize+YOffset);
                if(character.Value!="\n")
                    Raylib.DrawTextEx(Font, character.Value, pos, CharSize, 0, character.Color);
                
                if (++x > CanvasW || character.Value == "\n") {
                    y++;
                    x = 0;
                }
            }
        }
        Raylib.EndDrawing();
    }
    
    private static void Close() {
        Console.WriteLine("Disposing engine...");
        Raylib.CloseWindow();
        Raylib.CloseAudioDevice();
    }
}