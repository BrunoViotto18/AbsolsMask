namespace Model;

public class Game
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public int seed { get; set; }
    public User user { get; set; }
    public Sala sala { get; set; }
}