namespace AbsolsMask;

public class GatoArabeIA : ActionManager
{

    public GatoArabeIA(int X, int Y) : base(X, Y)
    {
        this.actions = new List<Action>();
        actions.Add(new GatoArabeJump(Properties.Entidades.InimigoGatoArabe.GatoIdle, new int[] { 5 }));
        actions.Add(new GatoArabeJump(Properties.Entidades.InimigoGatoArabe.GatoEndJump, new int[] { 5 }));
        actions.Add(new GatoArabeJump(Properties.Entidades.InimigoGatoArabe.GatoStartJump, new int[] { 5 }));
        this.posicao = new Posicao(X, Y, 32 ,41);


        currentAction = actions[0];
        direcao = Direction.Right;
    }

    public override void CalculateAction()
    {
        if (posicao.RightDistance == 0)
            direcao = Direction.Left;
        else if (posicao.LeftDistance == 0)
            direcao = Direction.Right;

        if(posicao.BottomDistance == 0)
        {
            if (currentAction.Prioridade < 1)
            {
                currentAction.Reset(posicao);
                currentAction = actions[0];
            }
        }
        else
        {
            if(posicao.SpeedY <= 0 && currentAction.Prioridade < 3)
            {
                currentAction.Reset(posicao);
                currentAction = actions[2];
            }
            else if(posicao.SpeedY > 0 && currentAction.Prioridade < 2)
            {
                currentAction.Reset(posicao);
                currentAction = actions[1];
            }
        }
    }
}
