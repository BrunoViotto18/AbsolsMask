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
    private List<Keys> keysPressed;
    private HitBox hitBox;


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

    public int Height
    {
        get => this.hitBox.Altura;
    }
    public int Width
    {
        get => this.hitBox.Largura;
    }


    // Construtor
    public Posicao(int X, int Y, int maxSpeedX=64, int maxSpeedY=64, int dx=32, int dy=32, int speedX=0, int speedY=0, int gravidadeY=10, int gravidadeX=0)
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
    private void CalculateKeysPressed()
    {
        foreach (Keys key in this.keysPressed)
        {
            switch (key)
            {
                case Keys.Up:
                    speedY -= dy;
                    break;

                case Keys.Right:
                    speedX += dx;
                    break;

                case Keys.Left:
                    speedX -= dx;
                    break;
            }
        }
    }

    // Calcula a gravidade
    private void CalculateGravity()
    {
        this.speedX += this.gravidadeX;
        this.speedY += this.gravidadeY;
    }

    // Calcula o movimento da entidade
    public void CalculateMoviment(Bloco[,] blocos, Entidades entidades)
    {
        CalculateKeysPressed();
        CalculateGravity();

        this.X += dx;
        this.Y += dy;
    }
}
