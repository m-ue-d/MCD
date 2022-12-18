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

    public ConsoleBuffer(int width, int height)
    {
        _buffer = new BuffChar[height*width];
        Width = width;
        Height = height;
    }

    public bool Set(int x, int y, BuffChar c)
    {
        var pos = (y - (y==0? 0:1)) * Width + x;
        
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
        var pos = (y - (y==0? 0:1)) * Width + x;
        
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
        var o = new BuffChar[Width];
        
        if (y >= _buffer.Length / Width || y < 0)
            return o;

        for (var i = 0; i < o.Length; i++)
        {
            var pos = y * Width + i;
            o[i] = _buffer[pos];
        }
        
        return o;
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
                Console.Write(t.Char + "-");
        }

        Console.Write(">\n");
    }

    public void Resize(int width, int height)
    {
        //TODO: Implement
    }
}