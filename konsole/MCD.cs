﻿using System.Numerics;
using Konsole.konsole.control;
using Raylib_CsLo;

namespace Konsole.konsole;

public static class Mcd
{
    const string Resources = @"../../../konsole/resources";
    public static int ScreenW { get; set; } = 1;
    public static int ScreenH { get; set; } = 1;
    
    public static int CharSize { get; set; } = 5;
    
    public static int CanvasW => ScreenW / CharSize;
    public static int CanvasH => ScreenH / CharSize;

    public static int YOffset { get; set; }
    public static int XOffset { get; set; }

    public static Character[] Canvas { get; set; } = Array.Empty<Character>();

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
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_TRANSPARENT);
        Raylib.InitWindow(ScreenW, ScreenH, "MCD");
        Raylib.SetWindowSize(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()) / 2, Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()) / 2);
        Raylib.SetWindowPosition(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()) / 2 - Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()) / 4, 
            Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()) / 2 - Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()) / 4);
        var icon = Raylib.LoadImageFromTexture(Raylib.LoadTexture($"{Resources}/icon.png"));
        Raylib.SetWindowIcon(icon);
        Raylib.UnloadImage(icon);
        Raylib.SetTargetFPS(60);
        Raylib.InitAudioDevice();
        Canvas = new Character[100000];
    }
    
    private static void Update() {
        ScreenW = Raylib.GetScreenWidth();
        ScreenH = Raylib.GetScreenHeight();
        InputHandler.Hey_Listen();
        Raylib.BeginDrawing();
        {
            Raylib.ClearBackground(Raylib.GetColor(0x00000000));

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
    
    
    //buffer operations
    public static void ClearBuff()
    {
        var size = Canvas.Length;
        Canvas = new Character[size];
    } 
    public static void Resize(int size)
    {
        var tmp = new Character[size];
        for(var i=0;i<Canvas.Length;i++)
        {
            if(i>=tmp.Length || i>=Canvas.Length)
                continue;
            tmp[i] = Canvas[i];
        }
        Canvas = tmp;
    }
    
}