using Raylib_CsLo;

namespace Konsole.konsole.control;

public struct Character {
    public Character(string value, Color color) {
        Value = value;
        Color = color;
    }
    
    public string Value { get; }
    public Color Color { get; }
}
