using System.Numerics;

namespace Konsole.konsole.control;

public static class ActionHandler
{
    public static int CameraMovementSpeed { get; set; }= 2;
    public static int ZoomSpeed { get; set; } = 2;
    public static Action<Bregion> Listen { get; set; } = (x) => { Console.WriteLine("Example-Update-Function"); };

    public static void Hey_Listen()    //Navi reference xD
    {
        Listen(new Bregion
        {
            Start = Vector2.Zero,
            Size = new Vector2(Mcd.CanvasW, Mcd.CanvasH)
        });
    }
}