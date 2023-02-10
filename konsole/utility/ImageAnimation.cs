using Raylib_CsLo;

namespace Konsole.konsole.utility;

public class ImageAnimation
{
    public Image Img { get; }
    public Texture Texture { get; }
    public int FramesCount { get; set; }
    public int Current { get; set; }

    public ImageAnimation(string path)
    {
        unsafe
        {
            var count = 0;
            Img = Raylib.LoadImageAnim(path, &count);
            Texture = Raylib.LoadTextureFromImage(Img);
            FramesCount = count;
        }
    }

    ~ImageAnimation()
    {
        Raylib.UnloadImage(Img);
    }
}