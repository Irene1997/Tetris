using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class O : Tetromino
{
    public O() : base()
    {
        blockColor = Color.Yellow;
        Up();
    }

    public override void Up()
    {
        Clear();
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
    }

    public override void Right()
    {
        Up();
    }

    public override void Down()
    {
        Up();
    }


    public override void Left()
    {
        Up();
    }
}


