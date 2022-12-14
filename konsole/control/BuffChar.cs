using System.Numerics;

namespace Konsole.konsole.control;

public struct BuffChar
{
    public BuffChar(char c, Vector4? rgba)
    {
        Rgba = rgba ?? new Vector4(1.0f,1.0f,1.0f,1.0f);
        Char = c;
    }

    public Vector4 Rgba { get; }
    public char Char { get; }
}