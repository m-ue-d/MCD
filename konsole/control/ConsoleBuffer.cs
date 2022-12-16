namespace Konsole.konsole.control;

/*
 * This class is basically an array of chars with rgba values, that has a little more functionality.
*/
public class ConsoleBuffer
{
    private BuffChar[] _buffer;
    public int Width { get; set; }
    public int Height { get; set; }

    public ConsoleBuffer(int width, int height)
    {
        _buffer = new BuffChar[height*width];
        Width = width;
        Height = height;
    }

    public bool Set(int x, int y, BuffChar c)
    {
        if (_buffer.Length>=x*y || x*y<0)
            return false;
        _buffer[x*y] = c;
        return true;
    }

    public BuffChar? Get(int x, int y)
    {
        if (_buffer.Length>=x*y || x*y<0)
            return null;
        return _buffer[x*y];
    }

    public void Clear()
    {
        var size = _buffer.Length;
        _buffer = new BuffChar[size];
    }
}