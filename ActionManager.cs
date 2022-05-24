namespace AbsolsMask;

using System.Reflection;

public class ActionManager
{
    private Action currentAction = new Idle(Properties.Entidades.Player.Idle, new int[] { 8, 8, 8 });
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

        bool key = false;
        if (currentAction.ChangeDirection)
        {
            key = true;
            var keyDirection = KeyPressManager.KeysPressed.LastOrDefault(k => k == Keys.Left || k == Keys.Right);

            switch (keyDirection)
            {
                case Keys.Left:
                    this.direcao = Direction.Left;
                    break;

                case Keys.Right:
                    this.direcao = Direction.Right;
                    break;

                default:
                    key = false;
                    break;
            }
        }


        /* Calcular ação */
        
        if (posicao.BottomDistance == 0)
        {
            if (key && KeyPressManager.KeysPressed.Contains(Keys.Z) && currentAction.Prioridade < 2)
                currentAction = new Run(Properties.Entidades.Player.Run, new int[] { 3, 3, 3, 3 });
            else if (key && currentAction.Prioridade < 1)
                currentAction = new Walk(Properties.Entidades.Player.Walk, new int[] { 5, 5, 5, 5 });
            else if (currentAction.Prioridade < 0)
                currentAction = new Idle(Properties.Entidades.Player.Idle, new int[] { 8, 8, 8 });
        }
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