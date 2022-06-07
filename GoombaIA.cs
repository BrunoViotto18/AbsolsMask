namespace AbsolsMask;

public class GoombaIA : ActionManager
{

    public GoombaIA(int X, int Y) : base(X, Y)
    {
        this.actions = new List<Action>();
        actions.Add(new GoombaWalk(Properties.Entidades.Inimigo.Inseto, new int[] { 5, 5, 5 }));
        this.posicao = new Posicao(X, Y, 30 ,50);


        currentAction = actions[0];
        direcao = Direction.Right;
    }

    public override void CalculateAction()
    {
        if (posicao.RightDistance == 0)
            direcao = Direction.Left;
        else if (posicao.LeftDistance == 0)
            direcao = Direction.Right;
    }

    
}
