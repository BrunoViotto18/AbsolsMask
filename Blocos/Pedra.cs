namespace AbsolsMask;

public class Pedra : Bloco
{
    private static Image? sprite = null;

    public static Image Sprite
    {
        get
        {
            if (Pedra.sprite == null)
                Pedra.sprite = Properties.Blocos.Pedra;
            return sprite;
        }
    }

    public void RenderBloco(int posX, int posY, Graphics g)
    {
        g.DrawImage(Pedra.Sprite, new Rectangle(posX*32, posY*32, 32, 32), new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);
    }
}
