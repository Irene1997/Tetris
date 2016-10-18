using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Z : Tetromino
{
    public Z(Vector2 bPosition) : base(bPosition)
    {
        blockColor = Color.Red;
        Up();
    }

    public override void Up()
    {
        Clear();
        block[0, 1] = blockColor;
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
    }

    public override void Right()
    {
        Clear();
        block[2, 0] = blockColor;
        block[1, 1] = blockColor;
        block[2, 1] = blockColor;
        block[1, 2] = blockColor;
    }

    public override void Down()
    {
        Up();
    }


    public override void Left()
    {
        Right();
    }
}