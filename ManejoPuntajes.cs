public static class ManejoPuntos
{
    public static List<Puntaje> AgregarPuntaje(List<Puntaje> puntajes, float pokeScore, string pokeName)
    {
        Console.WriteLine($"Ingresa tu nombre para registrar tu puntaje:");
        string player = Console.ReadLine();
        DateTime fecha = DateTime.Now;
        Puntaje nuevoPuntaje = new Puntaje(player, pokeScore, pokeName,fecha);
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
        Console.WriteLine();
        if (puntajes == null || puntajes.Count == 0)
        {
            Console.WriteLine("No hay puntuaciones registradas.");
            return;
        }
        Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-20}", "Pos", "Jugador", "Pokemon", "Puntaje", "Fecha y Hora");
        Console.WriteLine(new string('-', 70));
        int i = 1;
        foreach (var puntaje in puntajes)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10:F2} {4,-20}",
                i,
                puntaje.Player,
                puntaje.Poke,
                puntaje.Score,
                puntaje.Fecha.ToString("dd/MM/yyyy HH:mm"));
            i++;
        }

        Console.WriteLine();
        Console.WriteLine("Enter para volver...");
    }
}



