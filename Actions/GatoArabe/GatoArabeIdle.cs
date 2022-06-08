namespace AbsolsMask;

public class GatoArabeIdle : Action
{
    int maxTime = 60;
    public GatoArabeIdle(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 1;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        maxTime--;
        if(maxTime <= 0)
            prioridade = -1;
    }
    public override Action Reset(Posicao posicao)
    {
        prioridade = 1;
        currentSprite = 0;
        spriteDelay = 0;
        maxTime = 60;
        changeDirection = true;
        return this;
    }
}
