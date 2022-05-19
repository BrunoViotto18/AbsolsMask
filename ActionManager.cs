namespace AbsolsMask;

using System.Reflection;

public class ActionManager
{
    private Action currentAction = new Idle(Properties.Entidades.Player.Idle, 3, new int[] { 20, 20, 20 });
    private Posicao posicao;
    private Direction direcao;
    private BuffsDebuffs buffDebuff;
    private List<Action> actions = new List<Action>();

    public ActionManager(Posicao posicao, Direction direcao, BuffsDebuffs buffDebuff, List<Action> actions){
        this.posicao = posicao;
        this.direcao = direcao;
        this.buffDebuff = buffDebuff;
        this.actions = actions;
    }

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

    // Calcula a ação atual da entidade
    public void CalculateAction()
    {
        /* Calcular direcao */
        if (currentAction.ChangeDirection)
        {
            foreach (var key in KeyPressManager.KeysPressed)
            {
                switch (key)
                {
                    case Keys.Left:
                        this.direcao = Direction.Left;
                        break;

                    case Keys.Right:
                        this.direcao = Direction.Right;
                        break;

                    default:
                        continue;
                }
                break;
            }
        }


        if (currentAction.GetType()/*.GetCustomAttribute<IdleAttribute>()*/ == null)
            currentAction = new Idle(Properties.Entidades.Player.Idle, 3, new int[] { 20, 1, 1 });
    }

    // Calcula a velocidade da ação
    public void RunCurrentAction()
    {
        currentAction.RunAction(posicao, direcao);
    }

    // Calcula o movimento da ação
    public void CalculateActionMoviment(Bloco[,] blocos, Entidades entidades)
    {
        this.posicao.CalculateMoviment(blocos, entidades);
    }

    // Renderiza a ação
    public void RenderCurrentAction(Graphics g)
    {
        this.currentAction.RenderActionSprite(posicao, g, direcao);
    }
}