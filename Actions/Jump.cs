namespace AbsolsMask;

public class Jump : Action
{
    private int maxJumpTime = 30;
    private int maxJumpSpeed = 7;


    public Jump(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 2;
    }


    public override void RunAction(Posicao posicao, Direction direction)
    {
        if (maxJumpTime < 0)
            return;

        if (!KeyPressManager.KeysPressed.Contains(Keys.X))
            this.prioridade = 1;

        if (maxJumpTime % 5 == 0 && this.prioridade == 2)
            posicao.SpeedY += posicao.GravidadeY >= 0 ? -1 - posicao.GravidadeY : 1 + posicao.GravidadeY;

        maxJumpTime--;
    }

    public override Action Reset()
    {
        prioridade = 2;
        currentSprite = 0;
        spriteDelay = 0;
        changeDirection = true;
        return this;
    }
}
