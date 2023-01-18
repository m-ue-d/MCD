using Raylib_CsLo;

namespace Konsole.konsole.utility;

public static class Extensions
{

    public static float GetBrightness(this Color color)
    {
        return (0.2126f * color.r + 0.7152f * color.g + 0.0722f * color.b) /255;
    }
}