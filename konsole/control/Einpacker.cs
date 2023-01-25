using System.Numerics;
using Raylib_CsLo;

namespace Konsole.konsole.control;

public class Einpacker
{
    public Vector2 Start { get; set; }
    public Vector2 Size { get; set; }

    public void Einpacken(Vector2 start, Vector2 size, Action<Einpacker> hülle)
    {
        hülle(new Einpacker
        {
            Start = start,
            Size = size
        });
    }

    public void FüllenMit(char ch,Color co)
    {
        for (int i = (int) Start.X; i < Size.Y; i++)
        {
            for (int j = (int) Start.Y; j < Size.X; j++)
            {
                Mcd.Canvas[Mcd.PosAtPos(j, i)] = new Character(ch,co);
                //Console.WriteLine($"{j}, {i}");
            }
        }
    }

    public void SetzeBei(Vector2 pos, char ch, Color co)
    {
        var j = (int) pos.X;
        var i = (int) pos.Y;
        Mcd.Canvas[Mcd.PosAtPos(j, i)] = new Character(ch, co);
    }
}