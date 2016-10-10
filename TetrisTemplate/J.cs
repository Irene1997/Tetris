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
        matrix[1, 1] = blockColor;
        matrix[1, 2] = blockColor;
        matrix[2, 2] = blockColor;
        matrix[3, 2] = blockColor;
    }

    public void right()
    {
        Clear();
        matrix[1, 1] = blockColor;
        matrix[1, 2] = blockColor;
        matrix[1, 3] = blockColor;
        matrix[2, 1] = blockColor;
    }

    public void down()
    {
        Clear();
        matrix[0, 1] = blockColor;
        matrix[1, 1] = blockColor;
        matrix[2, 1] = blockColor;
        matrix[2, 2] = blockColor;
    }


    public void left()
    {
        Clear();
        matrix[1, 2] = blockColor;
        matrix[2, 0] = blockColor;
        matrix[2, 1] = blockColor;
        matrix[2, 2] = blockColor;
    }
}