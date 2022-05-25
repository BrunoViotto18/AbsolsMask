﻿namespace AbsolsMask;

public class Fall : Action
{
    public Fall(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 3;
    }

    public override Action Reset()
    {
        prioridade = 3;
        currentSprite = 0;
        spriteDelay = 0;
        changeDirection = true;
        return this;
    }
}
