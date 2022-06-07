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

    private static int maxTick = 2;
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

    public int MaxSpeedX
    {
        get => maxSpeedX;
        set => maxSpeedX = value;
    }
    public int MaxSpeedY
    {
        get => maxSpeedY;
        set => maxSpeedY = value;
    }


    public int GravidadeX
    {
        get => gravidadeX;
        set => gravidadeX = value;
    }
    public int GravidadeY
    {
        get => gravidadeY;
        set => gravidadeY = value;
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
    public Posicao(int X, int Y, int altura, int largura, int maxSpeedX=10, int maxSpeedY=10, int speedX=0, int speedY=0, int gravidadeY=1, int gravidadeX=0)
    {
        this.x = X;
        this.y = Y;
        this.maxSpeedX = maxSpeedX;
        this.maxSpeedY = maxSpeedY;
        this.speedX = speedX;
        this.speedY = speedY;
        this.gravidadeX = gravidadeX;
        this.gravidadeY = gravidadeY;
        this.hitBox = new HitBox(altura, largura);
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
        int top = -1;

        // Checa toda a borda superior
        for (int i = Left / 32; i <= Right / 32; i++)
        {
            // Checa se não está em colisão mas esteja em contato com o bloco
            if (blocos[i, (Top - 1) / 32] != null && top < 0)
                top = 0;

            // Checa se está em colisão
            if (blocos[i, Top / 32] != null)
            {
                int distanceTop = 32 - Top % 32;
                int t = Top / 32 + 1;

                // Checa quantos pixeis para dentro está no bloco
                while (blocos[i, t] != null)
                {
                    distanceTop += 32;
                    t++;
                    if (t == blocos.GetLength(1))
                    {
                        distanceTop = top;
                        break;
                    }
                }

                if (distanceTop > top && top > 0)
                    distanceTop = top;

                top = distanceTop;
            }
        }

        topDistance = top;

        return top;
    }

    private int calculateBottomCollision(Bloco[,] blocos, Entidades entidades)
    {
        int bottom = -1;

        for (int i = Left / 32; i <= Right / 32; i++)
        {
            if (blocos[i, (Bottom + 1) / 32] != null && bottom < 0)
                bottom = 0;

            if (blocos[i, Bottom / 32] != null)
            {
                int distanceBottom = Bottom % 32 + 1;
                int b = Bottom / 32 - 1;
                while (blocos[i, b] != null)
                {
                    distanceBottom += 32;
                    b--;
                    if (b < 0)
                    {
                        distanceBottom = bottom;
                        break;
                    }
                }

                if (distanceBottom > bottom && bottom > 0)
                    distanceBottom = bottom;

                bottom = distanceBottom;
            }
        }

        bottomDistance = bottom;

        return bottom;
    }

    private int calculateLeftCollision(Bloco[,] blocos, Entidades entidades)
    {
        int left = -1;

        for (int i = Top / 32; i <= Bottom / 32; i++)
        {
            if (blocos[(Left - 1) / 32, i] != null && left < 0)
                left = 0;

            if (blocos[Left / 32, i] != null)
            {
                int distanceLeft = 32 - Left % 32;
                int l = Left / 32 + 1;
                while (blocos[l, i] != null)
                {
                    distanceLeft += 32;
                    l++;
                    if (l == blocos.GetLength(0))
                    {
                        distanceLeft = left;
                        break;
                    }
                }

                if (distanceLeft > left && left > 0)
                    distanceLeft = left;

                left = distanceLeft;
            }
        }

        leftDistance = left;

        return left;
    }

    private int calculateRightCollision(Bloco[,] blocos, Entidades entidades)
    {
        int right = -1;

        for (int i = Top / 32; i <= Bottom / 32; i++)
        {
            if (blocos[(Right + 1) / 32, i] != null && right < 0)
                right = 0;

            if (blocos[Right / 32, i] != null)
            {
                int distanceRight = Right % 32 + 1;
                int r = Right / 32 - 1;
                while (blocos[r, i] != null)
                {
                    distanceRight += 32;
                    r--;
                    if (r < 0)
                    {
                        distanceRight = right;
                        break;
                    }
                }

                if (distanceRight > right && right > 0)
                    distanceRight = right;

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
            if (bordas[i] <= 0)
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
