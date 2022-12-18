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
    private static StringBuilder _line= new();
    private static Dictionary<int,string> _brightness = new()
    {
        {0," "},
        {1,"."},
        {2,":"},
        {3,"-"},
        {4,"="},
        {5,"+"},
        {6,"*"},
        {7,"#"},
        {8,"%"},
        {9,"@"}
    };

    public static void DrawBuffer(ConsoleBuffer b)
     {
         for (var i = 0; i < b.Height; i++)
         {
             var l = b.GetLine(i);
             DrawLine(l,i);
         }
     }
 
     private static void DrawLine(BuffChar[]? line, int lineIndex)
     {
         if (line is null) return;
         
         for (var index = 0; index < line.Length; index++)
         {
             var position = new Vector2(index*10,10*lineIndex);
             
             _line.Append(line[index].Char);
             Raylib.DrawTextEx(Konsole.Font_, _brightness[line[index].BrightnessIndex], position, 10, 10, Raylib.GetColor(line[index].Rgba));
         }
     }
}