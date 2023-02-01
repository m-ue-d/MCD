using Raylib_CsLo;

namespace Konsole.konsole.utility;

public class Util
{
    private static Dictionary<float, char> _brightnessMap = new()
    {
        {0.0f,' '},
        {0.1f,'.'},
        {0.2f,'+'},
        {0.3f,'*'},
        {0.4f,'%'},
        {0.5f,'&'},
        {0.6f,'#'},
        {0.7f,'$'},
        {0.8f,'§'},
        {0.9f,'§'},
        {1.0f,'§'}
    };

    public static char GetCharByBrightness(float brightness) => _brightnessMap[(float)Math.Round(brightness,1)];
    
    
    public static void ToggleFullscreen()
    {
        if (Raylib.IsWindowFullscreen())
        {
            Raylib.ToggleFullscreen();
            Raylib.SetWindowSize(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor())/2, Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor())/2);
            return;
        }
        Raylib.SetWindowSize(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()),Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()));
        Raylib.ToggleFullscreen();
    }
}
