﻿namespace AbsolsMask;

public class Player : Entidade
{
    private Mascara mascaraAtual;
    private List<Mascara> mascaras;

    public Player(int hp, int maxHp, int X, int Y) : base(hp, maxHp, X, Y)
    {

    }

    public override void RenderSelf(Graphics g)
    {
        g.FillRectangle(Brushes.DarkRed, new Rectangle(this.Left, this.Top, this.Width, this.Height));
    }

    private void RenderBody()
    {

    }

    private void RenderMask()
    {

    }
}
