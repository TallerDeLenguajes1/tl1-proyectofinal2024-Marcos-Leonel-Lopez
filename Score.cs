public class Puntaje
{
    private string player;
    private float score;
    private string poke;

    public Puntaje(string player, float score, string poke)
    {
        this.player = player;
        this.score = score;
        this.poke = poke;
    }

    public string Player { get => player; }
    public float Score { get => score; }
    public string Poke { get => poke; }

}