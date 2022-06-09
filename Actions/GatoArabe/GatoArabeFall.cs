﻿namespace AbsolsMask;

public class GatoArabeFall : Action
{
    public GatoArabeFall(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 2;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {

        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = -5;
                break;

            case Direction.Right:
                posicao.SpeedX = 5;
                break;
        }

        if (posicao.BottomDistance <= 0)
            prioridade = -1;
    }

    public override Action Reset(Posicao posicao)
    {
        prioridade = 2;
        currentSprite = 0;
        spriteDelay = 0;
        changeDirection = true;
        return this;
    }
}
