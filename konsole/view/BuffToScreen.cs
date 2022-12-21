using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;
using Konsole.konsole.control;
using Raylib_CsLo;

namespace Konsole.konsole.view;

/*
 * <...>
 */
public static class BuffToScreen
{
    private static Dictionary<float,string> _brightness = new()
    {
        {0," "},
        {0.1f,"."},
        {0.2f,":"},
        {0.3f,"-"},
        {0.4f,"="},
        {0.5f,"+"},
        {0.6f,"*"},
        {0.7f,"#"},
        {0.8f,"%"},
        {0.9f,"@"},
        {1,"$"}
    };

    public static void DrawBuffer(ConsoleBuffer b)
     {
         /*
         for (var i = 0; i < b.Height; i++)
         {
             var l = b.GetLine(i);
             DrawLineBrightness(l,i);
         }*/
        Raylib.DrawTextEx(Konsole.Font_, _brightness[0.9f], 
            new Vector2(0,0), 10, 0, Raylib.GetColor(0xFFFFFFFF));
         for (var i = 0; i < b.Height; i++)
         {
             for (var j = 0; j < b.Width; j++)
             {
                 var c = b.Get(j, i);
                 if (c != null)
                 {
                     Raylib.DrawTextEx(Konsole.Font_, _brightness[c.BrightnessIndex],
                         new Vector2(j*10,i*10), 10, 0, Raylib.GetColor(c.Rgba));
                 }
             }
         }
     }
 
     private static void DrawLineBrightness(BuffChar[]? line, int lineIndex)
     {
         if (line is null) return;
         for (var index = 0; index < line.Length; index++)
         {
             var position = new Vector2(index*10,10*lineIndex);
             Raylib.DrawTextEx(Konsole.Font_, _brightness[line[index].BrightnessIndex], 
                 position, 10, 0, Raylib.GetColor(line[index].Rgba));
         }
     }
     private static void DrawLineRaw(BuffChar[]? line, int lineIndex)
     {
         if (line is null) return;
         
         for (var index = 0; index < line.Length; index++)
         {
             var position = new Vector2(index*10,10*lineIndex);
             
             Raylib.DrawTextEx(Konsole.Font_, line[index].Char?.ToString() ?? string.Empty, position, 10, 10, 
                 Raylib.GetColor(line[index].Rgba));
         }
     }
}