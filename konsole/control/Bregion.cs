using System.Numerics;
using Raylib_CsLo;

namespace Konsole.konsole.control;

/**
 * A BufferRegion is an abstract object 'inside' the buffer, that can be used to separate it into smaller pieces.
*/
public class Bregion
{
    /** The start of the region in relation to the buffer*/
    public Vector2 Start { get; set; }
    /** The size of the region*/
    public Vector2 Size { get; set; }

    /**
     * Packs another region into the current region.
     */
    public void Pack(Vector2 startOffset, Vector2 size, Action<Bregion> shell)
    {
        shell(new Bregion
        {
            Start = Start + startOffset,
            Size = size
        });
    }

    /** Fills the region with the specified color*/
    public void FillColor(char ch,Color co) {
        for (var y = (int) Start.Y; y < Start.Y + Size.Y; y++)
            for (var x = (int) Start.X; x < Start.X + Size.X; x++)
                Mcd.Canvas[Mcd.PosAtPos(x, y)] = new Character(ch, co);
    }

    /** Sets a character at the desired position*/
    public void SetAt(Vector2 pos, char ch, Color co)
    {
        var j = (int) pos.X;
        var i = (int) pos.Y;
        var posAtPos = Mcd.PosAtPos(j, i);
        if (posAtPos < Mcd.PosAtPos((int) Start.X, (int) Start.Y) || posAtPos > Mcd.PosAtPos((int)(Start.X+Size.X),(int)(Start.Y+Size.Y)))
            return;
        
        Mcd.Canvas[posAtPos] = new Character(ch, co);
    }
}