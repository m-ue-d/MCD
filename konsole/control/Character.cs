using Raylib_CsLo;

namespace Konsole.konsole.control;

public struct Character {
    public Character(char value, Color color) {
        Value = value;
        Color = color;
    }
    
    public char Value { get; }
    public Color Color { get; }
}
