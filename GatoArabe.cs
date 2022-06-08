namespace AbsolsMask;

public class GatoArabe : Entidade
{

    public GatoArabe(int hp, int maxHp, int X, int Y) : base(hp, maxHp, X, Y)
    {
        this.actionManager = new GatoArabeIA(X, Y);
    }
}
