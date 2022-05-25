namespace AbsolsMask;

public class Posicao
{
    // Atributos
    private int x;
    private int y;
    private int maxSpeedX;
    private int maxSpeedY;
    private int speedX;
    private int speedY;
    private int gravidadeX;
    private int gravidadeY;

    private int topDistance;
    private int rightDistance;
    private int bottomDistance;
    private int leftDistance;

    private List<Keys> keysPressed = new List<Keys>();
    private static int maxTick = 4;
    private HitBox hitBox;
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
        set
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
        set
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


    public int GravidadeX
    {
        get => gravidadeX;
    }
    public int GravidadeY
    {
        get => gravidadeY;
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

    public int TopDistance
    {
        get => topDistance;
    }
    public int RightDistance
    {
        get => rightDistance;
    }
    public int BottomDistance
    {
        get => bottomDistance;
    }
    public int LeftDistance
    {
        get => leftDistance;
    }


    // Construtor
    public Posicao(int X, int Y, int maxSpeedX=10, int maxSpeedY=5, int speedX=0, int speedY=0, int gravidadeY=2, int gravidadeX=0)
    {
        this.x = X;
        this.y = Y;
        this.maxSpeedX = maxSpeedX;
        this.maxSpeedY = maxSpeedY;
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
                    speedY = -5;
                    break;

                //case Keys.Right:
                //    speedX = dx;
                //    break;

                case Keys.Down:
                    speedY = 5;
                    break;

                //case Keys.Left:
                //    speedX = -dx;
                //    break;
            }
        }
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

    private int calculateTopCollision(Bloco[,] blocos, Entidades entidades)
    {
        int top = 0;

        for (int i = Left / 32; i <= Right / 32; i++)
        {
            if (blocos[i, Top / 32] != null)
            {
                int distanceTop = -1;
                int t = Top / 32;
                while (blocos[i, t] != null)
                {
                    if (t == Top / 32)
                        distanceTop = 32 - Top % 32;
                    else
                        distanceTop += 32;

                    if (distanceTop > top && top != 0)
                    {
                        distanceTop = top;
                        break;
                    }

                    t++;
                    if (t == blocos.GetLength(1))
                        break;
                }
                top = distanceTop;
            }
        }

        topDistance = Bottom;

        return top;
    }

    private int calculateBottomCollision(Bloco[,] blocos, Entidades entidades)
    {
        int bottom = 0;

        for (int i = Left / 32; i <= Right / 32; i++)
        {
            if (blocos[i, Bottom / 32] != null)
            {
                int distanceBottom = -1;
                int b = Bottom / 32;
                while (blocos[i, b] != null)
                {
                    if (b == Bottom / 32)
                        distanceBottom = Bottom % 32 + 1;
                    else
                        distanceBottom += 32;

                    if (distanceBottom > bottom && bottom != 0)
                    {
                        distanceBottom = bottom;
                        break;
                    }

                    b--;
                    if (b < 0)
                        break;
                }
                bottom = distanceBottom;
            }
        }

        bottomDistance = bottom;

        return bottom;
    }

    private int calculateLeftCollision(Bloco[,] blocos, Entidades entidades)
    {
        int left = 0;

        for (int i = Top / 32; i <= Bottom / 32; i++)
        {
            if (blocos[Left / 32, i] != null)
            {
                int distanceLeft = -1;
                int l = Left / 32;
                while (blocos[l, i] != null)
                {
                    if (l == Left / 32)
                        distanceLeft = 32 - Left % 32;
                    else
                        distanceLeft += 32;

                    if (distanceLeft > left && left != 0)
                    {
                        distanceLeft = left;
                        break;
                    }

                    l++;
                    if (l == blocos.GetLength(0))
                        break;
                }
                left = distanceLeft;
            }
        }

        leftDistance = left;

        return left;
    }

    private int calculateRightCollision(Bloco[,] blocos, Entidades entidades)
    {
        int right = 0;

        for (int i = Top / 32; i <= Bottom / 32; i++)
        {
            if (blocos[Right / 32, i] != null)
            {
                int distanceRight = -1;
                int r = Right / 32;
                while (r > 0 && r < blocos.GetLength(0) && blocos[r, i] != null)
                {
                    if (r == Right / 32)
                        distanceRight = Right % 32 + 1;
                    else
                        distanceRight += 32;

                    if (distanceRight > right && right != 0)
                    {
                        distanceRight = right;
                        break;
                    }

                    r--;
                    if (r < 0)
                        break;
                }
                right = distanceRight;
            }
        }

        rightDistance = right;

        return right;
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

        int top = calculateTopCollision(blocos, entidades);
        int bottom = calculateBottomCollision(blocos, entidades);
        int left = calculateLeftCollision(blocos, entidades);
        int right = calculateRightCollision(blocos, entidades);

        string[] bordasNome = { "top", "right", "bottom", "left" };
        int[] bordas = { top, right, bottom, left };
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
                    topDistance = 0;
                    break;

                case "right":
                    Right = Right - bordas[i];
                    SpeedX = 0;
                    rightDistance = 0;
                    break;

                case "bottom":
                    Bottom = Bottom - bordas[i];
                    SpeedY = 0;
                    bottomDistance = 0;
                    break;

                case "left":
                    Left = Left + bordas[i];
                    SpeedX = 0;
                    leftDistance = 0;
                    break;
            }

            top = calculateTopCollision(blocos, entidades);
            bottom = calculateBottomCollision(blocos, entidades);
            right = calculateRightCollision(blocos, entidades);
            left = calculateLeftCollision(blocos, entidades);

            for (int j = 0; j < 4; j++)
            {
                switch (bordasNome[j])
                {
                    case "top":
                        bordas[j] = top;
                        break;

                    case "right":
                        bordas[j] = right;
                        break;

                    case "bottom":
                        bordas[j] = bottom;
                        break;

                    case "left":
                        bordas[j] = left;
                        break;
                }
            }
        }
        speedX = 0;
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
