namespace AbsolsMask;

public class GatoArabeJump : Action
{
    int FirstFrame;
    int speedLeft;
    int speedRight;

    public GatoArabeJump(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.FirstFrame = 8;
        this.prioridade = 3;
        speedLeft = new Random().Next(-7, -1);
        speedRight = new Random().Next(1, 7);
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        if (posicao.SpeedY >= 0)
            prioridade = -1;

        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = speedLeft;
                break;

            case Direction.Right:
                posicao.SpeedX = speedRight;
                break;
        }

        if (FirstFrame <= 0)
            return;

        posicao.SpeedY = -8;

        FirstFrame--;
    }
    public override Action Reset(Posicao posicao)
    {
        prioridade = 3;
        currentSprite = 0;
        spriteDelay = 0;
        FirstFrame = 8;
        changeDirection = true;
        speedLeft = new Random().Next(-7, -1);
        speedRight = new Random().Next(1, 7);
        return this;
    }
}
