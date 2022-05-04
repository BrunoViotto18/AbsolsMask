namespace AbsolsMask;

public class Debug : Bloco
{
    private static Image? sprite = null;

    public static Image Sprite
    {
        get
        {
            if (Debug.sprite == null)
                Debug.sprite = new Bitmap("Sprites/Blocos/debug.png");
            return sprite;
        }
    }

    public void RenderBloco(int posX, int posY, Graphics g)
    {
        g.DrawImage(Debug.Sprite, new Rectangle(posX*32, posY*32, 32, 32), new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);
    }
}
