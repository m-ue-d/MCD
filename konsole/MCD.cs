using System.Numerics;
using Konsole.konsole.control;
using Raylib_CsLo;

namespace Konsole.konsole;

public static class Mcd
{
    const string Resources = @"../../../konsole/resources";
    public static int ScreenW { get; set; } = 1;    //Width of the Window
    public static int ScreenH { get; set; } = 1;    //Height of the Window
    
    public static int CharSize { get; set; } = 5;

    #region Includes extra character (possibly outside the viewport or cut off) 
    // public static int CanvasW => (int) Math.Ceiling(ScreenW / (double) CharSize);
    // public static int CanvasH => (int) Math.Ceiling(ScreenH / (double) CharSize);
    #endregion
    
    #region Excludes characters outside the viewport (safe option)
    public static int CanvasW => ScreenW / CharSize;    //Amount of chars that fit into the screen-width
    public static int CanvasH => ScreenH / CharSize;    //Amount of chars that fit into the screen-height
    #endregion

    public static int CameraY { get; set; } = 0;
    public static int CameraX { get; set; } = 0;
    public static int Zoom { get; set; } = 0;

    public static float Spacing { get; set; } = 1;

    public static Character[] Canvas { get; set; } = Array.Empty<Character>();

    public static Font Font { get; set; }
    public static Color BackgroundColor { get; set; } = Raylib.BLACK;

    public static void Main() {
        Init();
        while (!Raylib.WindowShouldClose()) {
            Update();
        }
        Close();
    }
    
    private static void Init()
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(ScreenW, ScreenH, "MCD");
        Raylib.SetWindowSize(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()) / 2, Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()) / 2);
        Raylib.SetWindowPosition(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()) / 2 - Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()) / 4, 
            Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()) / 2 - Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()) / 4);
        //var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture($"{Resources}/icon.png"));    //TODO: Change Resources Location to get the File form the ddl
        //Raylib.SetWindowIcon(icon);
        //Raylib.UnloadImage(icon);
        Raylib.SetTargetFPS(60);
        Raylib.InitAudioDevice();
        Font = Raylib.GetFontDefault();
    }
    
    private static void Update() {
        ScreenW = Raylib.GetScreenWidth();
        ScreenH = Raylib.GetScreenHeight();
        ActionHandler.Hey_Listen();
        Raylib.BeginDrawing();
        {
            Raylib.ClearBackground(BackgroundColor);

            var x = 0;
            var y = 0;

            foreach (var character in Canvas) {
                var pos = new Vector2(x, y) * (CharSize+Zoom) * Spacing + new Vector2(CameraX, CameraY);
                Raylib.DrawTextCodepoint(Font, character.Value, pos, CharSize+Zoom, character.Color);

                if (++x >= CanvasW) {
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
    
    
    //several buffer operations
    public static void ClearBuff()
    {
        var size = Canvas.Length;
        Canvas = new Character[size];
    } 
    public static void Resize(int size)
    {
        Raylib.SetWindowSize(CanvasW*CharSize, CanvasH*CharSize);
        if(Canvas.Length==size)
            return;
        
        var tmp = new Character[size];
        Array.Copy(Canvas,tmp, Math.Min(tmp.Length,Canvas.Length));
        Canvas = tmp;

        Console.WriteLine($"{ScreenW} / {CharSize} = {CanvasW}");
    }

    public static int PosAtPos(int x, int y)
    {
        return y * CanvasW + x;
    }
}
