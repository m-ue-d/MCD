using System.Numerics;

namespace Konsole.konsole.control;

public static class ActionHandler
{
    public static float CameraMovementSpeed { get; set; }= 1;
    public static float ZoomSpeed { get; set; } = 1;
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