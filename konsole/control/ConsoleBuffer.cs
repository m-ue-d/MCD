using Raylib_CsLo;

namespace Konsole.konsole.control;

/*
 * This class is basically an array of chars with rgba values, that has a little more functionality.
*/
public class ConsoleBuffer
{
    private BuffChar[] _buffer;
    public int Width { get; set; }
    public int Height { get; set; }

    public int Length => Height * Width;

    private BuffChar[] _line;
        
    public ConsoleBuffer(int width, int height)
    {
        _buffer = new BuffChar[height*width];
        Width = width;
        Height = height;
        _line = new BuffChar[Width];
    }

    public bool Set(int x, int y, BuffChar c)
    {
        var pos = y * Width + x;
        
        if (pos>=_buffer.Length || pos<0)
            return false;
        _buffer[pos] = c;
        return true;
    }
    public bool Set(int x, BuffChar c)
    {
        if (x>= _buffer.Length || x<0)
            return false;
        _buffer[x] = c;
        return true;
    }

    public BuffChar? Get(int x, int y)
    {
        var pos = y * Width + x;
        
        if (pos>= _buffer.Length || pos<0)
            return null;
        return _buffer[pos];
    }
    
    public BuffChar? Get(int x)
    {
        if (x>= _buffer.Length || x<0)
            return null;
        return _buffer[x];
    }
    
    public BuffChar[] GetLine(int y)
    {
        if (y >= _buffer.Length / Width || y < 0)
            return _line;

        for (var i = 0; i < _line.Length; i++)
        {
            var pos = y * Width + i;
            _line[i] = _buffer[pos];
        }
        
        return _line;
    }

    public void FSet(int x, BuffChar c)
    {
        _buffer[x] = c;
    }
    public BuffChar? FGet(int x)
    {
        return _buffer[x];
    }


    public void Clear()
    {
        var size = _buffer.Length;
        _buffer = new BuffChar[size];
    }


    public void Debug()
    {
        Console.Write("Buffer-Debug: \n<");
        for (var index = 0; index < _buffer.Length; index++)
        {
            var t = _buffer[index];
            if(index<_buffer.Length-1)
                Console.Write("(i:"+index+","+t.Char + ")-");
        }

        Console.Write(">\n");
    }

    public void OnUpdate()
    {
        var newW = Raylib.GetScreenWidth() / 10;
        var newH = Raylib.GetScreenHeight() / 10;

        if (Width != newW || Height != newH)
        {
            Console.WriteLine(newW + ", " + newH);
            Width = newW;
            Height = newH;
            Resize();
        }
    }

    private void Resize()
    {
        _buffer = new BuffChar[Length];
    }
}