public static class Constantes
{
    public const string scoreDirectory = "files/score";
    public const string scoreFileName = "score.json";
    public const string backupDirectory = "files/backup";
    public const string pokeFileName = "poke.json";
    public const string savedGamesDirectory = "files/saved_games";
    public const string myPokeFileName = "myPoke.json";
    public const string opponentsFileName = "opponents.json";
    public const int maxPoke = 10;
    public static readonly List<string> menuOptions = new List<string>
{
    "Nueva Partida",
    "Cargar Partida",
    "Máximas Puntuaciones",
};
    public static readonly List<string> seguirGuardar = new List<string>
{
    "Siguiente Batalla",
    "Guardar y Salir",
};
    public static readonly List<string> subMenuOptions = new List<string>
    {
        "Usar datos guardados",
        "Cargar nuevos datos"
    };
    public static string GetPokemonUrl(int idPoke) => $"https://pokeapi.co/api/v2/pokemon/{idPoke}";
}