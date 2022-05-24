namespace AbsolsMask;

public class JumpFallManager : Action
{
    private Action currentAction;
    private bool doubleJump = true;

    public JumpFallManager(Bitmap spritesheet, int[] spriteTime, bool falling) : base(spritesheet, spriteTime)
    {
        if (falling)
            currentAction = new Fall();
        else
            currentAction = new Jump();
        this.prioridade = 2;
    }

    private void calculateAction(Posicao posicao)
    {
        if (currentAction.Prioridade == 3 && KeyPressManager.KeysPressed.Contains(Keys.X))
        {
            currentAction = new Jump();
            doubleJump = false;
        }
        if (posicao.SpeedY < 0 && currentAction.Prioridade < 3)
            currentAction = new Fall(Properties.Entidades.Player.);
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        if (posicao.Bottom == 0)
            this.prioridade = -1;
    }
}
