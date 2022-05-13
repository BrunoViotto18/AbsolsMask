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
    public Posicao(int X, int Y, int maxSpeedX=10, int maxSpeedY=10, int dx=5, int dy=5, int speedX=0, int speedY=0, int gravidadeY=5, int gravidadeX=0)
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

    private int[] calculateVerticalCollision(Bloco[,] blocos, Entidades entidades)
    {
        int[] bordas = new int[2];

        for (int i = Left / 32; i <= Right / 32; i++)
        {
            if (blocos[i, Top / 32] != null)
            {
                int distanceTop = 0;
                int t = Top / 32;
                while (blocos[i, t] != null)
                {
                    if (t == Top / 32)
                        distanceTop = 32 - Top % 32;
                    else
                        distanceTop += 32;

                    if (distanceTop > bordas[0] && bordas[0] != 0)
                    {
                        distanceTop = bordas[0];
                        break;
                    }

                    t++;
                    if (t == blocos.GetLength(1))
                        break;
                }
                bordas[0] = distanceTop;
            }

            if (blocos[i, Bottom / 32] != null)
            {
                int distanceBottom = 0;
                int b = Bottom / 32;
                while (blocos[i, b] != null)
                {
                    if (b == Bottom / 32)
                        distanceBottom = Bottom % 32 + 1;
                    else
                        distanceBottom += 32;

                    if (distanceBottom > bordas[1] && bordas[1] != 0)
                    {
                        distanceBottom = bordas[1];
                        break;
                    }

                    b--;
                    if (b < 0)
                        break;
                }
                bordas[1] = distanceBottom;
            }
        }

        return bordas;
    }

    private int[] calculateHorizontalCollision(Bloco[,] blocos, Entidades entidades)
    {
        int[] bordas = new int[2];

        for (int i = Top / 32; i <= Bottom / 32; i++)
        {
            if (blocos[Right / 32, i] != null)
            {
                int distanceRight = 0;
                int r = Right / 32;
                while (r > 0 && r < blocos.GetLength(0) && blocos[r, i] != null)
                {
                    if (r == Right / 32)
                        distanceRight = Right % 32 + 1;
                    else
                        distanceRight += 32;

                    if (distanceRight > bordas[0] && bordas[0] != 0)
                    {
                        distanceRight = bordas[0];
                        break;
                    }

                    r--;
                    if (r < 0)
                        break;
                }
                bordas[0] = distanceRight;
            }

            if (blocos[Left / 32, i] != null)
            {
                int distanceLeft = 0;
                int l = Left / 32;
                while (blocos[l, i] != null)
                {
                    if (l == Left / 32)
                        distanceLeft = 32 - Left % 32;
                    else
                        distanceLeft += 32;

                    if (distanceLeft > bordas[1] && bordas[1] != 0)
                    {
                        distanceLeft = bordas[1];
                        break;
                    }

                    l++;
                    if (l == blocos.GetLength(0))
                        break;
                }
                bordas[1] = distanceLeft;
            }
        }

        return bordas;
    }

    private void sortBordas(int[] bordas, string[] bordasNome)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bordas[i] < bordas[j])
                {
                    int temp = bordas[j];
                    bordas[j] = bordas[i];
                    bordas[i] = temp;
                    string tempNome = bordasNome[j];
                    bordasNome[j] = bordasNome[i];
                    bordasNome[i] = tempNome;
                }
            }
        }
    }

    private void calculateCollision(Bloco[,] blocos, Entidades entidades)
    {
        int salaWidth = blocos.GetLength(0) * 32;
        int salaHeight = blocos.GetLength(1) * 32;

        // Calcualte OutOfBounds
        if (Top < 0)
            Top = 0;
        if (Left < 0)
            Left = 0;
        if (Right > salaWidth)
            Right = salaWidth;
        if (Bottom > salaHeight)
            Bottom = salaHeight;

        
        int[] vertical = calculateVerticalCollision(blocos, entidades);
        int[] horizontal = calculateHorizontalCollision(blocos, entidades);
        string[] bordasNome = { "top", "right", "bottom", "left" };
        int[] bordas = { vertical[0], horizontal[0], vertical[1], horizontal[1] };
        sortBordas(bordas, bordasNome);

        for (int i = 0; i < 4; i++)
        {
            if (bordas[i] == 0)
                continue;

            switch (bordasNome[i])
            {
                case "top":
                    Top = Top + bordas[i];
                    SpeedY = 0;
                    break;

                case "right":
                    Right = Right - bordas[i];
                    SpeedX = 0;
                    break;

                case "bottom":
                    Bottom = Bottom - bordas[i];
                    SpeedY = 0;
                    break;

                case "left":
                    Left = Left + bordas[i];
                    SpeedX = 0;
                    break;
            }

            vertical = calculateVerticalCollision(blocos, entidades);
            horizontal = calculateHorizontalCollision(blocos, entidades);

            for (int j = 0; j < 4; j++)
            {
                switch (bordasNome[j])
                {
                    case "top":
                        bordas[j] = vertical[0];
                        break;

                    case "right":
                        bordas[j] = horizontal[0];
                        break;

                    case "bottom":
                        bordas[j] = vertical[1];
                        break;

                    case "left":
                        bordas[j] = horizontal[1];
                        break;
                }
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
