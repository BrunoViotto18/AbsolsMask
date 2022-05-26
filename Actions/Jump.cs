namespace AbsolsMask;

public class Jump : Action
{
    private Posicao posicao;
    private int maxJumpTime = 30;
    public int GravidadeY { get; private set; } = 0;


    public Jump(Bitmap spritesheet, int[] spriteTime, Posicao posicao) : base(spritesheet, spriteTime)
    {
        this.posicao = posicao;
        this.GravidadeY = posicao.GravidadeY;
        this.prioridade = 2;
    }


    public override void RunAction(Posicao posicao, Direction direction)
    {
        if (maxJumpTime < 0)
        {
            posicao.GravidadeY = GravidadeY;
            return;
        }

        if (KeyPressManager.LastKey(Keys.X) == null)
        {
            maxJumpTime = -1;
            this.prioridade = 1;
        }

        if (GravidadeY != 0)
        {
            GravidadeY = posicao.GravidadeY;
            posicao.GravidadeY = 0;
        }

        if (maxJumpTime % 4 != 0)
            posicao.SpeedY -= 10;

        maxJumpTime--;
    }

    public override Action Reset()
    {
        posicao.GravidadeY = GravidadeY;
        prioridade = 2;
        currentSprite = 0;
        spriteDelay = 0;
        changeDirection = true;
        maxJumpTime = 30;
        return this;
    }
}
