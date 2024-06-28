public static class Manejopunts
{
    public static List<Puntaje> AgregarPuntaje(List<Puntaje> puntajes, float pokeScore, string pokeName)
    {
        Console.WriteLine($"Ingresa tu nombre para registrar tu puntaje:");
        string player = Console.ReadLine();
        Puntaje nuevoPuntaje = new Puntaje(player, pokeScore, pokeName);
        puntajes.Add(nuevoPuntaje);
        puntajes.Sort((p1, p2) => p2.Score.CompareTo(p1.Score)); // Ordenar de mayor a menor
        // Si hay más de 10 puntajes, eliminar los extras
        if (puntajes.Count > 10)
        {
            puntajes = puntajes.Take(10).ToList();
        }
        return puntajes;
    }
    public static void MostrarMaximasPuntuaciones(List<Puntaje> puntajes)
    {
        Console.Clear();
        Console.WriteLine("Máximas Puntuaciones:");
        if (puntajes == null || puntajes.Count == 0)
        {
            Console.WriteLine("No hay puntuaciones registradas.");
            return;
        }

        foreach (var puntaje in puntajes)
        {
            Console.WriteLine($"{puntaje.Player} - {puntaje.Poke} - {puntaje.Score}");
        }
    }
}