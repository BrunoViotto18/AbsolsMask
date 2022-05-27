namespace AbsolsMask;

public class JumpFallManager : Action
{
    private Action[] actions = new Action[2];
    private Action currentAction;
    private bool doubleJump = true;


    public JumpFallManager(Bitmap jumpSpritesheet, Bitmap fallSpritesheet, int[] spriteTimeJump, int[] spriteTimeFall, Posicao posicao) : base(jumpSpritesheet, spriteTimeJump)
    {
        actions[0] = (new Jump(jumpSpritesheet, spriteTimeJump, posicao));
        actions[1] = (new Fall(fallSpritesheet, spriteTimeFall));

        if (posicao.BottomDistance == 0)
            this.currentAction = actions[0];
        else
            this.currentAction = actions[1];

        this.prioridade = 3;
    }


    private void calculateAction(Posicao posicao)
    {
        
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        calculateAction(posicao);

        currentAction.RunAction(posicao, direction);
    }

    public override Action Reset()
    {
        prioridade = 3;
        changeDirection = true;
        for (int i = 0; i < actions.Length; i++)
            actions[i] = actions[i].Reset();
        return this;
    }
}
