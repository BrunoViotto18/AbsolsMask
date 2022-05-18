namespace AbsolsMask;

using System.Reflection;

public class ActionManager
{
    private Action currentAction = new Idle(Properties.Entidades.Player.Idle, 3, new int[] { 20, 20, 20 });
    private Posicao posicao;
    private Direction direcao;
    private BuffsDebuffs buffDebuff;
    private List<Action> actions = new List<Action>();

    //Gets de posicao
    public int X
    {
        get => posicao.X;
    }
    public int Y
    {
        get => posicao.Y;
    }

    public int Height
    {
        get => posicao.Height;
    }
    public int Width
    {
        get => posicao.Width;
    }

    public int Top
    {
        get => posicao.Top;
    }
    public int Bottom
    {
        get => posicao.Bottom;
    }
    public int Right
    {
        get => posicao.Right;
    }
    public int Left
    {
        get => posicao.Left;
    }

    public ActionManager(int X, int Y)
    {
        this.posicao = new Posicao(X, Y);
    }

    // Calcula a a��o atual da entidade
    public void CalculateAction()
    {
        if (currentAction.GetType().GetCustomAttribute<IdleAttribute>() == null)
            currentAction = new Idle(Properties.Entidades.Player.Idle, 3, new int[] { 20, 20, 20 });
    }

    // Calcula a velocidade da a��o
    public void RunCurrentAction()
    {
        currentAction.RunAction(posicao, direcao);
    }

    // Calcula o movimento da a��o
    public void CalculateActionMoviment(Bloco[,] blocos, Entidades entidades)
    {
        this.posicao.CalculateMoviment(blocos, entidades);
    }

    // Renderiza a a��o
    public void RenderCurrentAction(Graphics g)
    {
        this.currentAction.RenderActionSprite(posicao, g, direcao);
    }
}