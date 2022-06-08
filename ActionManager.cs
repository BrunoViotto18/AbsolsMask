namespace AbsolsMask;

using System.Reflection;

public class ActionManager
{
    protected List<Action> actions = new List<Action>();
    protected Action currentAction;
    protected Posicao posicao;
    protected Direction direcao;
    protected bool Recoil;

    private bool doubleJump;
    private bool dash;

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

    public int? HitboxDamage
    {
        get => posicao.HitboxDamage;
    }


    public ActionManager(int X, int Y)
    {
        this.posicao = new Posicao(X, Y, 56, 20);

        this.actions.Add(new Idle(Properties.Entidades.Player.Idle, new int[] { 8, 8, 8 }));
        this.actions.Add(new Walk(Properties.Entidades.Player.Walk, new int[] { 5, 5, 5, 5 }));
        this.actions.Add(new Run(Properties.Entidades.Player.Run, new int[] { 5, 5, 5, 5 }));
        this.actions.Add(new Fall(Properties.Entidades.Player.Fall, new int[] { 5, 5, 5, 5 }));
        this.actions.Add(new Jump(Properties.Entidades.Player.Jump, new int[] { 3, 3, 5, 5 }));
        this.actions.Add(new Attack(Properties.Entidades.Player.Attack, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        this.actions.Add(new Dash(Properties.Entidades.Player.Dash, new int[] { 3, 3 }));

        currentAction = actions[0];
        direcao = Direction.Right;
        doubleJump = true;
        dash = true;
    }


    // Calcula a ação atual da entidade
    public virtual void CalculateAction()
    {
        /* Calcular direcao */

        bool key = false;
        if (currentAction.ChangeDirection)
        {
            key = true;
            var keyDirection = KeyPressManager.LastKey(Keys.Right, Keys.Left);

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
        
        // Dash
        if (KeyPressManager.KeysPressed.Contains(Keys.A) && dash && currentAction.Prioridade < 6)
        {
            dash = false;
            currentAction.Reset(posicao);
            currentAction = actions[6];
        }
        // Ataque
        else if (KeyPressManager.KeysPressed.Contains(Keys.C) && currentAction.Prioridade < 5)
        {
            currentAction.Reset(posicao);
            currentAction = actions[5];
        }
        else if (posicao.BottomDistance == 0)
        {
            doubleJump = true;
            dash = true;
            
            // Pulo
            if (KeyPressManager.KeysPressed.Contains(Keys.X) && currentAction.Prioridade < 4)
            {
                currentAction.Reset(posicao);
                currentAction = actions[4];
            }
            // Correr
            else if (key && KeyPressManager.KeysPressed.Contains(Keys.Z) && currentAction.Prioridade < 2)
            {
                currentAction.Reset(posicao);
                currentAction = actions[2];
            }
            // Andar
            else if (key && currentAction.Prioridade < 1)
            {
                currentAction.Reset(posicao);
                currentAction = actions[1];
            }
            // Parado
            else if (currentAction.Prioridade < 0)
            {
                currentAction.Reset(posicao);
                currentAction = actions[0];
            }
        }
        else
        {
            // Pulo Duplo
            if (KeyPressManager.KeysPressed.Contains(Keys.X) && doubleJump && currentAction.Prioridade < 4)
            {
                doubleJump = false;
                currentAction.Reset(posicao);
                currentAction = actions[4];
            }
            // Caindo
            else if (currentAction.Prioridade < 3 && posicao.SpeedY <= 0)
            {
                currentAction.Reset(posicao);
                currentAction = actions[3];
            }
        }
    }


    // Calcula a quantidade de movimento da ação
    public void RunCurrentAction()
    {
        currentAction.RunAction(posicao, direcao);
    }

    // Calcula a colisão
    public Entidade? CalculateEntityCollision(Entidade[] entidades)
    {
        return posicao.CalculateEntityCollision(entidades);
    }

    // Calcula o movimentação da ação
    public void CalculateActionMoviment(Bloco[,] blocos, Entidades entidades)
    {
        this.posicao.CalculateMoviment(blocos, entidades, Recoil);
    }

    // Renderiza a ação
    public void RenderCurrentAction(Graphics g)
    {
        this.currentAction.RenderActionSprite(posicao, g, direcao);
    }
}