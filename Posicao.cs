namespace AbsolsMask;

public class Posicao
{
    private int x;
    private int y;
    private int maxSpeedX;
    private int maxSpeedY;
    private int speedX;
    private int speedY;
    private HitBox hitBox;

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

    public Posicao(int X, int Y, int maxSpeedX=25, int maxSpeedY=25, int speedX=0, int speedY=0)
    {
        this.x = X;
        this.y = Y;
        this.maxSpeedX = maxSpeedX;
        this.maxSpeedY = maxSpeedY;
        this.speedX = speedX;
        this.speedY = speedY;
        this.hitBox = new HitBox(56, 20);
    }
}
