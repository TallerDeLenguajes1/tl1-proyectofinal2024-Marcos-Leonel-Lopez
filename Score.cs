public class Puntaje
{
    private string player;
    private float score;
    private string poke;
    private DateTime fecha;

    public Puntaje(string player, float score, string poke)
    {
        this.player = player;
        this.score = score;
        this.poke = poke;
        this.fecha = DateTime.Now;;
        
    }

    public string Player { get => player; }
    public float Score { get => score; }
    public string Poke { get => poke; }
    public DateTime Fecha { get => fecha; }

}