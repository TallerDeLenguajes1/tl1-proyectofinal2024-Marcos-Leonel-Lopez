public static class Constantes
{
    public const string ScoreDirectorio = "files/score";
    public const string ScoreFileName = "score.json";
    public const string BackupDirectorio = "files/backup";
    public const string PokeFileName = "poke.json";
    public const string SavedGamesDirectorio = "files/saved_games";
    public const string MyPokeFileName = "myPoke.json";
    public const string OponentsFileName = "opponents.json";
    public const int MaxPoke = 10;
    public static readonly List<string> MenuOptions = new List<string>
{
    "Nueva Partida",
    "Cargar Partida",
    "Máximas Puntuaciones",
};
    public static readonly List<string> SeguirGuardar = new List<string>
{
    "Siguiente Batalla",
    "Guardar y Salir",
};
    public static readonly List<string> SubMenuOptions = new List<string>
    {
        "Usar datos guardados",
        "Cargar nuevos datos"
    };
    public static string GetPokemonUrl(int idPoke) => $"https://pokeapi.co/api/v2/pokemon/{idPoke}";
}