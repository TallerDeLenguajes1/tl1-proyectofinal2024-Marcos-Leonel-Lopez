// using System.Text.Json;
// public class Juego
// {
//     private Random random = new Random();

//     public async Task IniciarCombate(Pokemon myPoke, List<Pokemon> personajes, List<Puntaje> puntajes)
//     {
//         while (myPoke.EstaVivo() && personajes.Count > 0)
//         {
//             int randomIndex = random.Next(personajes.Count);
//             Pokemon op = personajes[randomIndex];
//             Console.WriteLine($"Te enfrentas a {op.Name}");
//             Console.WriteLine();
//             myPoke.Combate(op);

//             if (myPoke.EstaVivo())
//             {
//                 personajes.Remove(op);
//                 Console.WriteLine("Enter para pasar al siguiente combate o escribe 'g' para guardar y salir:");
//                 string input = Console.ReadLine();
//                 if (input.Equals("g", StringComparison.OrdinalIgnoreCase))
//                 {
//                     string myPokeJsonString = JsonSerializer.Serialize(myPoke, new JsonSerializerOptions { WriteIndented = true });
//                     await ManejoJson.GuardarJson(Constantes.savedGamesDirectory, Constantes.myPokeFileName, myPokeJsonString);

//                     string opponentsJsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
//                     await ManejoJson.GuardarJson(Constantes.savedGamesDirectory, Constantes.opponentsFileName, opponentsJsonString);
//                     break; // Volver al menú principal
//                 }
//             }
//             else
//             {
//                 Console.WriteLine();
//                 Console.WriteLine($"PERDISTE: {myPoke.Name} ha sido derrotado! ");
//                 Console.ReadKey();
//                 break; // Volver al menú principal
//             }

//             if (myPoke.EstaVivo() && personajes.Count == 0)
//             {
//                 Console.WriteLine();
//                 Console.WriteLine($"{myPoke.Name} ha derrotado a todos los oponentes!");
//                 Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
//                 puntajes = ManejoPuntos.AgregarPuntaje(puntajes, myPoke.Score, myPoke.Name);
//                 string scoreJsonString = JsonSerializer.Serialize(puntajes, new JsonSerializerOptions { WriteIndented = true });
//                 await ManejoJson.GuardarJson(Constantes.scoreDirectory, Constantes.scoreFileName, scoreJsonString);
//                 ManejoJson.EliminarArchivosJson(Constantes.savedGamesDirectory);
//                 Console.ReadLine();
//                 break; // Volver al menú principal
//             }
//         }
//     }


// }


using System.Text.Json;

public static class Juego
{
    private static Random random = new Random();

    public  static async Task IniciarCombate(Pokemon myPoke, List<Pokemon> personajes, List<Puntaje> puntajes)
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
                Console.WriteLine("Enter para pasar al siguiente combate o escribe 'g' para guardar y salir:");
                string input = Console.ReadLine();
                if (input.Equals("g", StringComparison.OrdinalIgnoreCase))
                {
                    string myPokeJsonString = JsonSerializer.Serialize(myPoke, new JsonSerializerOptions { WriteIndented = true });
                    await ManejoJson.GuardarJson(Constantes.savedGamesDirectory, Constantes.myPokeFileName, myPokeJsonString);

                    string opponentsJsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
                    await ManejoJson.GuardarJson(Constantes.savedGamesDirectory, Constantes.opponentsFileName, opponentsJsonString);
                    break; // Volver al menú principal
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"PERDISTE: {myPoke.Name} ha sido derrotado! ");
                Console.ReadKey();
                break; // Volver al menú principal
            }

            if (myPoke.EstaVivo() && personajes.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{myPoke.Name} ha derrotado a todos los oponentes!");
                Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
                puntajes = ManejoPuntos.AgregarPuntaje(puntajes, myPoke.Score, myPoke.Name);
                string scoreJsonString = JsonSerializer.Serialize(puntajes, new JsonSerializerOptions { WriteIndented = true });
                await ManejoJson.GuardarJson(Constantes.scoreDirectory, Constantes.scoreFileName, scoreJsonString);
                ManejoJson.EliminarArchivosJson(Constantes.savedGamesDirectory);
                Console.ReadLine();
                break; // Volver al menú principal
            }
        }
    }
}

