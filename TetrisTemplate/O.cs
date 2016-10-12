using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class O : Tetromino
{
    public O(Texture2D b) : base(b)
    {
        blockColor = Color.Yellow;

    }

    public void up()
    {
        Clear();
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
    }

    public void right()
    {
        up();
    }

    public void down()
    {
        up();
    }


    public void left()
    {
        up();
    }
}


