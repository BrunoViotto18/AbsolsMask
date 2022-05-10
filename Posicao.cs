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
    public Posicao(int X, int Y, int maxSpeedX=6, int maxSpeedY=6, int dx=5, int dy=5, int speedX=0, int speedY=0, int gravidadeY=5, int gravidadeX=0)
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
                int top = 32 - Top % 32;
                for (int j = Top / 32 + 1; j <= Top / 32 + 1 + Height / 32; j++)
                {
                    if (top > bordas[0] && bordas[0] != 0 || blocos[i, j - 1] == null)
                        break;
                    bordas[0] += top;
                    top = 32;
                }
            }

            if (blocos[i, Bottom / 32] != null)
            {
                int bottom = Bottom % 32 + 1;
                for (int j = Bottom / 32 - 1; j >= Bottom / 32 - 1 - Height / 32; j--)
                {
                    if (bottom > bordas[1] && bordas[1] != 0 || blocos[i, j + 1] == null)
                        break;
                    bordas[1] += bottom;
                    bottom = 32;
                }
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
                int right = Right % 32 + 1;
                for (int j = Right / 32 - 1; j >= Right / 32 - 1 - Width / 32; j--)
                {
                    if (right > bordas[0] && bordas[0] != 0 || blocos[j + 1, i] == null)
                        break;
                    bordas[0] += right;
                    right = 32;
                }
            }

            if (blocos[Left / 32, i] != null)
            {
                int left = 32 - Left % 32;
                for (int j = Left / 32 + 1; j <= Left / 32 + 1 + Width / 32; j++)
                {
                    if (left > bordas[1] && bordas[1] != 0 || blocos[j - 1, i] == null)
                        break;
                    bordas[1] += left;
                    left = 32;
                }
            }
        }

        return bordas;
    }

    private void sortBordas(int[] bordas, string[] bordasNome)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bordas[i] > bordas[j])
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

        /*string[] bordasNome = { "top", "right", "bottom", "left"};
        int[] bordas = new int[4];
        bool flag = false;*/

        /*
        // Calculate Top, Bottom
        for (int i = Left / 32; i <= Right / 32; i++)
        {
            if (blocos[i, Top / 32] != null)
            {
                int top = 32 - Top % 32;
                for (int j = Top / 32 + 1; j <= Top / 32 + 1 + Height / 32; j++)
                {
                    if (top > bordas[0] && bordas[0] != 0 || blocos[i, j-1] == null)
                        break;
                    bordas[0] += top;
                    top = 32;
                }
            }

            if (blocos[i, Bottom / 32] != null)
            {
                int bottom = Bottom % 32 + 1;
                for (int j = Bottom / 32 - 1; j >= Bottom / 32 - 1 - Height / 32; j--)
                {
                    if (bottom > bordas[2] && bordas[2] != 0 || blocos[i, j+1] == null)
                        break;
                    bordas[2] += bottom;
                    bottom = 32;
                }
            }
        }

        // Calculate Right, Left
        for (int i = Top / 32; i <= Bottom / 32; i++)
        {
            if (blocos[Right / 32, i] != null)
            {
                int right = Right % 32 + 1;
                for (int j = Right / 32 - 1; j >= Right / 32 - 1 - Width / 32; j--)
                {
                    if (right > bordas[1] && bordas[1] != 0 || blocos[j + 1, i] == null)
                        break;
                    bordas[1] += right;
                    right = 32;
                }
            }

            if (blocos[Left / 32, i] != null)
            {
                int left = 32 - Left % 32;
                for (int j = Left / 32 + 1; j <= Left / 32 + 1 + Width / 32; j++)
                {
                    if (left > bordas[3] && bordas[3] != 0 || blocos[j - 1, i] == null)
                        break;
                    bordas[3] += left;
                    left = 32;
                }
            }
        }
        */

        /*for (int i = 0; i < 3; i++)
        {
            if (bordas[0] > bordas[1])
            {
                int temp = bordas[1];
                bordas[1] = bordas[0];
                bordas[0] = temp;
                string tempNome = bordasNome[1];
                bordasNome[1] = bordasNome[0];
                bordasNome[0] = tempNome;
            }
        }*/

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
                    Top = (Top / 32 + 1) * 32;
                    SpeedY = 0;
                    vertical = calculateVerticalCollision(blocos, entidades);
                    horizontal = calculateHorizontalCollision(blocos, entidades);
                    bordasNome = new string[4] { "top", "right", "bottom", "left" };
                    bordas = new int[4] { vertical[0], horizontal[0], vertical[1], horizontal[1] };
                    sortBordas(bordas, bordasNome);
                    break;

                case "right":
                    Right = Right / 32 * 32 - 1;
                    SpeedX = 0;
                    vertical = calculateVerticalCollision(blocos, entidades);
                    horizontal = calculateHorizontalCollision(blocos, entidades);
                    bordasNome = new string[4] { "top", "right", "bottom", "left" };
                    bordas = new int[4] { vertical[0], horizontal[0], vertical[1], horizontal[1] };
                    sortBordas(bordas, bordasNome);
                    break;

                case "bottom":
                    Bottom = Bottom / 32 * 32 - 1;
                    SpeedY = 0;
                    vertical = calculateVerticalCollision(blocos, entidades);
                    horizontal = calculateHorizontalCollision(blocos, entidades);
                    bordasNome = new string[4] { "top", "right", "bottom", "left" };
                    bordas = new int[4] { vertical[0], horizontal[0], vertical[1], horizontal[1] };
                    sortBordas(bordas, bordasNome);
                    break;

                case "left":
                    Left = (Left / 32 + 1) * 32;
                    SpeedX = 0;
                    vertical = calculateVerticalCollision(blocos, entidades);
                    horizontal = calculateHorizontalCollision(blocos, entidades);
                    bordasNome = new string[4] { "top", "right", "bottom", "left" };
                    bordas = new int[4] { vertical[0], horizontal[0], vertical[1], horizontal[1] };
                    sortBordas(bordas, bordasNome);
                    break;
            }
        }

        // Calculate Top, Bottom
        /*for (int i = Left / 32; i <= Right / 32; i++)
        {
            if (blocos[i, Top / 32] != null)
            {
                Top = (Top / 32 + 1) * 32;
            }

            if (blocos[i, Bottom / 32] != null)
            {
                Bottom = Bottom / 32 * 32 - 1;
            }
        }

        // Calculate Right, Left
        for (int i = Top / 32 + 1; i <= Bottom / 32 - 1; i++)
        {
            if (blocos[Right / 32, i] != null)
            {
                Right = Right / 32 * 32 - 1;
            }

            if (blocos[Left / 32, i] != null)
            {
                Left = (Left / 32 + 1) * 32;
            }
        }*/
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
