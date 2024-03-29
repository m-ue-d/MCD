﻿using System.Numerics;
using Konsole.konsole.utility;
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

    /** Fills the region with an image (format must be png)*/
    public void FillImage(Image image)
    {
        unsafe //resize image to fit inside the region
        {
            var current = Raylib.ImageCopy(image);
            Raylib.ImageResize(&current, (int)(Start.X+Size.X), (int)(Start.Y+Size.Y));   //TODO: change Vector2<float> to Vector2<int>
            for (var y = (int) Start.Y; y < Start.Y + Size.Y; y++)
                for (var x = (int) Start.X; x < Start.X + Size.X; x++)
                {
                    var color = Raylib.GetImageColor(current, x, y);
                    Mcd.Canvas[Mcd.PosAtPos(x, y)] = new Character(Util.GetCharByBrightness(color.GetBrightness()), color);
                }
            
            Raylib.UnloadImage(current);
        }
    }

    /** Fills the region with an animation (format must be gif)*/
    public void FillAnimation(ImageAnimation img, int frameDelay)
    {
        unsafe
        {
            var copy = Raylib.ImageCopy(img.Img);
            Raylib.ImageResize(&copy, (int)(Start.X+Size.X), (int)(Start.Y+Size.Y)); //wont work if i do that
            var texAnim = Raylib.LoadTextureFromImage(copy);
        //
        //     if (DateTime.Now.Second%frameDelay==0)  //TODO: frameDelay isn't about frames? But it should be... Fix that, later...
        //     {
        //         img.Current = ++img.Current % img.FramesCount;
        //     }
        //
        var offset = (uint) (1 * copy.width * copy.height);
           
        Raylib.UpdateTexture(texAnim,  (uint* )copy.data + offset);
           
        Raylib.DrawTexture(texAnim, 0,0,Raylib.WHITE);  //Not displaying anything?!
        //     
        //     var tmp2 = Raylib.LoadImageFromTexture(texAnim);
        //
        //     for (var y = (int) Start.Y; y < Start.Y + Size.Y; y++)
        //         for (var x = (int) Start.X; x < Start.X + Size.X; x++)
        //         {
        //             var color = Raylib.GetImageColor(tmp2, x, y);
        //             Mcd.Canvas[Mcd.PosAtPos(x, y)] = new Character(Util.GetCharByBrightness(color.GetBrightness()), color);
        //         }
        //     
        Raylib.UnloadTexture(texAnim);
        Raylib.UnloadImage(copy);
        }   //won't work if i use tmp, but i can't resize the image otherwise =(
        
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