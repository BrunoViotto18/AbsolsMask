namespace AbsolsMask;

using System.Reflection;

public class ActionManager
{
    private List<Action> actions = new List<Action>();
    private Action currentAction;
    private Posicao posicao;
    private Direction direcao;
    private bool doubleJump;

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

        this.actions.Add(new Idle(Properties.Entidades.Player.Idle, new int[] { 8, 8, 8 }));
        this.actions.Add(new Walk(Properties.Entidades.Player.Walk, new int[] { 5, 5, 5, 5 }));
        this.actions.Add(new Run(Properties.Entidades.Player.Run, new int[] { 5, 5, 5, 5 }));
        this.actions.Add(new Fall(Properties.Entidades.Player.Fall, new int[] { 5, 5, 5, 5 }));
        this.actions.Add(new Jump(Properties.Entidades.Player.Jump, new int[] { 10, 10, 5, 5 }, posicao));

        currentAction = actions[0];
        direcao = Direction.Right;
        doubleJump = true;
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
            doubleJump = true;
            if (KeyPressManager.KeysPressed.Contains(Keys.X) && currentAction.Prioridade < 4)
            {
                currentAction.Reset();
                currentAction = actions[4];
            }
            else if (key && KeyPressManager.KeysPressed.Contains(Keys.Z) && currentAction.Prioridade < 2)
            {
                currentAction.Reset();
                currentAction = actions[2];
            }
            else if (key && currentAction.Prioridade < 1)
            {
                currentAction.Reset();
                currentAction = actions[1];
            }
            else if (currentAction.Prioridade < 0)
            {
                currentAction.Reset();
                currentAction = actions[0];
            }
        }
        /*else
        {
            if (KeyPressManager.KeysPressed.Contains(Keys.X) && doubleJump && currentAction.Prioridade < 4)
            {
                doubleJump = false;
                currentAction.Reset();
                currentAction = actions[4];
            }
            else if (currentAction.Prioridade < 3)
            {
                currentAction.Reset();
                currentAction = actions[3];
            }
        }*/
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