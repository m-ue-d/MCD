using System.Numerics;

namespace Konsole.konsole.control;

public class BuffChar
{
    private static float[] _map =
    {//TODO: get luminance levels of chars
        ' ',
        '.',
        ':',
        '-',
        '=',
        '+',
        '*',
        '#',
        '%',
        '@'
    };
    
    public BuffChar(char c, uint rgba)
    {
        Rgba = rgba; // ?? new Vector4(1.0f,1.0f,1.0f,1.0f);
        Char = c;
    }

    public uint Rgba { get; }
    public char Char { get; }

    public int BrightnessIndex
    {
        get
        {
            var brightness = (0.2126f * R + 0.7152f * G + 0.0722f * B);


            return ;
        }
    }
}