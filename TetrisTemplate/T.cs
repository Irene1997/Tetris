using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class T : Tetromino
{
    public T() : base()
    {
        blockColor = Color.Purple;
        Up();
    }

    public override void Up()
    {
        Clear();
        block[2, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[3, 2] = blockColor;
    }

    public override void Right()
    {
        Clear();
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
        block[3, 2] = blockColor;
        block[2, 3] = blockColor;
    }

    public override void Down()
    {
        Clear();
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[3, 2] = blockColor;
        block[2, 3] = blockColor;
    }


    public override void Left()
    {
        Clear();
        block[2, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[2, 3] = blockColor;
    }
}