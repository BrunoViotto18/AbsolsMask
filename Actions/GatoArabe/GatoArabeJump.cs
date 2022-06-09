namespace AbsolsMask;

public class GatoArabeJump : Action
{
    bool FirstFrame;
    public GatoArabeJump(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.FirstFrame = true;
        this.prioridade = 3;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        if (posicao.SpeedY >= 0)
            prioridade = -1;

        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = -5;
                break;

            case Direction.Right:
                posicao.SpeedX = 5;
                break;
        }

        if (!FirstFrame)
            return;

        posicao.SpeedY = -8;

        FirstFrame = false;
    }
    public override Action Reset(Posicao posicao)
    {
        prioridade = 3;
        currentSprite = 0;
        spriteDelay = 0;
        FirstFrame = true;
        changeDirection = true;
        return this;
    }
}
