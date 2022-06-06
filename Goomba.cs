namespace AbsolsMask;

public class Goomba : Entidade
{

    public Goomba(int hp, int maxHp, int X, int Y) : base(hp, maxHp, X, Y)
    {
        this.actionManager = new GoombaIA(X, Y);
    }

    private void RenderBody()
    {

    }

    private void RenderMask()
    {

    }
}
