using System.Numerics;
using Raylib_CsLo;

namespace Konsole.konsole.control;

public class BuffChar
{
    public BuffChar(char c, uint rgba)
    {
        Rgba = rgba;
        Char = c;
    }

    public uint Rgba { get; }
    public char? Char { get; }

    public float BrightnessIndex
    {
        get
        {
            var r = Rgba / 0x01000000;
            var g = (Rgba % 0x01000000) / 0x00010000;
            var b = ((Rgba % 0x01000000) % 0x00010000) / 0x00000100;
            
            var brightness = (0.2126f * r + 0.7152f * g + 0.0722f * b);
            
            return MathF.Round(brightness/255,1);
        }
    }
}