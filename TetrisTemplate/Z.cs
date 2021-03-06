﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Z : Tetromino
{
    public Z() : base()
    {
        blockColor = Color.Red;
        Up();
    }

    public override void Up()
    {
        Clear();
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[2, 3] = blockColor;
        block[3, 3] = blockColor;
    }

    public override void Right()
    {
        Clear();
        block[2, 1] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[1, 3] = blockColor;
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