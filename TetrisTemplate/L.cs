﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class L : Tetromino
{
    public L() : base()
    {
        blockColor = Color.Orange;
        Up();
    }

    public override void Up()
    {
        Clear();
        block[0, 2] = blockColor;
        block[1, 2] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
    }

    public override void Right()
    {
        Clear();
        block[1, 0] = blockColor;
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
    }

    public override void Down()
    {
        Clear();
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 1] = blockColor;
        block[3, 1] = blockColor;
    }


    public override void Left()
    {
        Clear();
        block[1, 1] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
        block[2, 3] = blockColor;
    }
}