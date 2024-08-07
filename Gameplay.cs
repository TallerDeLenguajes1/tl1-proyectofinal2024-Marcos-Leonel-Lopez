using System.Text.Json;
public static class Juego
{
    private static Random random = new Random();

    public static async Task IniciarCombate(Pokemon myPoke, List<Pokemon> personajes, List<Puntaje> puntajes)
    {
        while (myPoke.EstaVivo() && personajes.Count > 0)
        {
            int randomIndex = random.Next(personajes.Count);
            Pokemon op = personajes[randomIndex];
            Console.WriteLine($"Te enfrentas a {op.Name}");
            Console.WriteLine();
            myPoke.Combate(op);
            if (myPoke.EstaVivo())
            {
                personajes.Remove(op);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"PERDISTE: {myPoke.Name} ha sido derrotado! ");
                Thread.Sleep(5000);
                break; // Volver al menú principal
            }


            if (myPoke.EstaVivo() && personajes.Count > 0)
            {
                Console.WriteLine("Enter para pasar al siguiente combate o escribe 'g' para guardar y salir:");
                string input = Console.ReadLine();
                if (input.Equals("g", StringComparison.OrdinalIgnoreCase))
                {
                    string myPokeJsonString = JsonSerializer.Serialize(myPoke, new JsonSerializerOptions { WriteIndented = true });
                    await ManejoJson.GuardarJson(Constantes.SavedGamesDirectorio, Constantes.MyPokeFileName, myPokeJsonString);

                    string opponentsJsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
                    await ManejoJson.GuardarJson(Constantes.SavedGamesDirectorio, Constantes.OponentsFileName, opponentsJsonString);
                    Thread.Sleep(500);
                    break; // Volver al menú principal
                }
            }


            if (myPoke.EstaVivo() && personajes.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{myPoke.Name} ha derrotado a todos los oponentes!");
                Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
                puntajes = ManejoPuntos.AgregarPuntaje(puntajes, myPoke.Score, myPoke.Name);
                string scoreJsonString = JsonSerializer.Serialize(puntajes, new JsonSerializerOptions { WriteIndented = true });
                await ManejoJson.GuardarJson(Constantes.ScoreDirectorio, Constantes.ScoreFileName, scoreJsonString);
                ManejoJson.EliminarArchivosJson(Constantes.SavedGamesDirectorio);
                Thread.Sleep(5000);
                break; // Volver al menú principal
            }
        }
    }
}

