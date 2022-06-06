using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolsMask;

public class Dash : Action
{
    private int maxDashTime = 20;

    public Dash(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        changeDirection = false;
        this.prioridade = 6;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        if (maxDashTime == 20)
            posicao.MaxSpeedX = posicao.MaxSpeedX * 3;

        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX -= 10;
                break;

            case Direction.Right:
                posicao.SpeedX += 10;
                break;
        }

        posicao.SpeedY = 0;

        if (maxDashTime < 0)
            this.prioridade = -1;

        maxDashTime--;
    }

    public override Action Reset(Posicao posicao)
    {
        posicao.MaxSpeedX = posicao.MaxSpeedX / 3;
        this.prioridade = 6;
        spriteDelay = 0;
        currentSprite = 0;
        maxDashTime = 20;
        return this;
    }
}
