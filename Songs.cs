namespace AbsolsMask;

using System.Media;

public class Songs
{
    public void playDead()
    {
        SoundPlayer simples = new SoundPlayer(Properties.Songs.zelda);
        simples.Play();
    }
}
