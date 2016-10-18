using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class S : Tetromino
{
    public S(Vector2 bPosition) : base(bPosition)
    {
        blockColor = new Color(0,204,0);
        Up();
    }

    public override void Up()
    {
        Clear();
        block[1, 1] = blockColor;
        block[2, 1] = blockColor;
        block[0, 2] = blockColor;
        block[1, 2] = blockColor;
    }

    public override void Right()
    {
        Clear();
        block[1, 0] = blockColor;
        block[1, 1] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
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