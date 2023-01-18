namespace Konsole.konsole.utility;

public class Util
{
    private static Dictionary<float, string> _brightnessMap = new()
    {
        {0.0f,"$"},
        {0.1f,"$"},
        {0.2f,"$"},
        {0.3f,"§"},
        {0.4f,"§"},
        {0.5f,"§"},
        {0.6f,"§"},
        {0.7f,"§"},
        {0.8f,"§"},
        {0.9f,"§"},
        {1.0f,"§"}
    };

    public static string GetCharByBrightness(float brightness) => _brightnessMap[(float)Math.Round(brightness,1)];
}