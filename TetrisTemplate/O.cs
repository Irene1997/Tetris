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
        matrix[1, 1] = blockColor;
        matrix[1, 2] = blockColor;
        matrix[2, 1] = blockColor;
        matrix[2, 2] = blockColor;
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


