namespace AbsolsMask;

public class HitBox
{
    private int altura;
    private int largura;
    private int? dano;

    public int Altura
    {
        get => altura;
    }
    public int Largura
    {
        get => largura;
    }

    public HitBox(int altura, int largura, int? dano=null)
    {
        this.altura = altura;
        this.largura = largura;
        this.dano = dano;
    }
}
