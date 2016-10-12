using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class J : Tetromino
{
    public J(Texture2D b) : base(b)
    {
        blockColor = Color.Blue;
    }

    public void up()
    {
        Clear();
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[3, 2] = blockColor;
    }

    public void right()
    {
        Clear();
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[1, 3] = blockColor;
        block[2, 1] = blockColor;
    }

    public void down()
    {
        Clear();
        block[0, 1] = blockColor;
        block[1, 1] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
    }


    public void left()
    {
        Clear();
        block[1, 2] = blockColor;
        block[2, 0] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
    }
}