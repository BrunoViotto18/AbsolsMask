namespace AbsolsMask;

public class Posicao
{
    // Atributos
    private int x;
    private int y;
    private int maxSpeedX;
    private int maxSpeedY;
    private int dx;
    private int dy;
    private int speedX;
    private int speedY;
    protected int gravidadeX;
    protected int gravidadeY;
    private List<Keys> keysPressed = new List<Keys>();
    private HitBox hitBox;
    public static int maxTick = 12;
    private int tick = 0;


    // GET & SET
    public int X
    {
        get => x;
        private set => x = value;
    }
    public int Y
    {
        get => y;
        private set => y = value;
    }


    public int SpeedX
    {
        get => speedX;
        private set
        {
            if (value > maxSpeedX)
            {
                speedX = maxSpeedX;
                return;
            }
            if (value < -maxSpeedX)
            {
                speedX = -maxSpeedX;
                return;
            }
            speedX = value;
        }
    }
    public int SpeedY
    {
        get => speedY;
        private set
        {
            if (value > maxSpeedY)
            {
                speedY = maxSpeedY;
                return;
            }
            if (value < -maxSpeedY)
            {
                speedY = -maxSpeedY;
                return;
            }
            speedY = value;
        }
    }


    public int Height
    {
        get => hitBox.Altura;
    }
    public int Width
    {
        get => hitBox.Largura;
    }


    public int Top
    {
        get => Y;
        private set => Y = value;
    }
    public int Right
    {
        get => X + Width - 1;
        private set => X = value - Width + 1;
    }
    public int Bottom
    {
        get => Y + Height - 1;
        private set => Y = value - Height + 1;
    }
    public int Left
    {
        get => X;
        private set => X = value;
    }


    // Construtor
    public Posicao(int X, int Y, int maxSpeedX=6, int maxSpeedY=6, int dx=32, int dy=32, int speedX=0, int speedY=0, int gravidadeY=5, int gravidadeX=0)
    {
        this.x = X;
        this.y = Y;
        this.maxSpeedX = maxSpeedX;
        this.maxSpeedY = maxSpeedY;
        this.dx = dx;
        this.dy = dy;
        this.speedX = speedX;
        this.speedY = speedY;
        this.gravidadeX = gravidadeX;
        this.gravidadeY = gravidadeY;
        this.hitBox = new HitBox(56, 20);
    }


    // Métodos
    private void calculateKeysPressed()
    {
        foreach (Keys key in KeyPressManager.KeysPressed)
        {
            switch (key)
            {
                case Keys.Up:
                    speedY = -dy;
                    break;

                case Keys.Right:
                    speedX = dx;
                    break;

                case Keys.Down:
                    speedY = dy;
                    break;

                case Keys.Left:
                    speedX = -dx;
                    break;
            }
        }
        KeyPressManager.Clear();
    }

    // Calcula a gravidade
    private void calculateGravity()
    {
        if (tick < maxTick)
        {
            tick++;
            return;
        }

        this.speedX += this.gravidadeX;
        this.speedY += this.gravidadeY;
        tick = 0;
    }

    private void calculateCollision(Bloco[,] blocos, Entidades entidades)
    {
        // Calcualte OutOfBounds
        if (Top < 0)
            Top = 0;
        if (Left < 0)
            Left = 0;
        if (Right > blocos.GetLength(0) * 32)
            Right = blocos.GetLength(0) * 32;
        if (Bottom > blocos.GetLength(1) * 32)
            Bottom = blocos.GetLength(1) * 32;

        int[] border = new int[4];

        // Calculate Top, Bottom
        for (int i = Left / 32; i <= Right / 32; i++)
        {
            if (blocos[i, Top / 32] != null)
                border[0] += 32 - Top % 32;

            if (blocos[i, Bottom / 32] != null)
                border[2] += Bottom % 32 + 1;
        }

        // Calculate Right, Left
        for (int i = Top / 32; i <= Bottom / 32; i++)
        {
            if (blocos[Right / 32, i] != null)
                border[1] += Right % 32 + 1;

            if (blocos[Left / 32, i] != null)
                border[3] += 32 - Left % 32;
        }

        // Calculate multiple collisions
        border.OrderBy(p => p);
        for (int borda = 0; borda < border.Length; borda++)
        {
            if (border[borda] == 0)
                continue;

            switch (borda)
            {
                case 0:
                    Top = (Top / 32 + 1) * 32;
                    speedY = 0;
                    break;

                case 1:
                    Right = (Right / 32) * 32 - 1;
                    speedX = 0;
                    break;

                case 2:
                    Bottom = (Bottom / 32) * 32 - 1;
                    speedY = 0;
                    break;

                case 3:
                    Left = (Left / 32 + 1) * 32;
                    speedX = 0;
                    break;
            }
        }
    }

    // Calcula o movimento da entidade
    public void CalculateMoviment(Bloco[,] blocos, Entidades entidades)
    {
        calculateKeysPressed();
        calculateGravity();

        this.X += speedX;
        this.Y += speedY;

        calculateCollision(blocos, entidades);
    }
}
