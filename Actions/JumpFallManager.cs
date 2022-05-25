namespace AbsolsMask;

public class JumpFallManager : Action
{
    private Action[] actions = new Action[2];
    private Action currentAction;
    private bool doubleJump = true;
    private Posicao posicao;


    public JumpFallManager(Bitmap jumpSpritesheet, Bitmap fallSpritesheet, int[] spriteTimeJump, int[] spriteTimeFall, Posicao posicao) : base(jumpSpritesheet, spriteTimeJump)
    {
        actions[0] = (new Jump(jumpSpritesheet, spriteTimeJump));
        actions[1] = (new Fall(fallSpritesheet, spriteTimeFall));
        this.posicao = posicao;

        if (posicao.BottomDistance == 0)
            this.currentAction = actions[0];
        else
            this.currentAction = actions[1];

        this.prioridade = 3;
    }


    private void calculateAction(Posicao posicao)
    {
        if (KeyPressManager.KeysPressed.Contains(Keys.X) && doubleJump && currentAction.Prioridade == 3)
        {
            currentAction = actions[0].Reset();
            doubleJump = false;
        }

        if (posicao.SpeedY < 0 && currentAction.Prioridade < 3)
            currentAction = actions[1].Reset();
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        calculateAction(posicao);

        currentAction.RunAction(posicao, direction);

        if (posicao.Bottom == 0)
            this.prioridade = -1;
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
