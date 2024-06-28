// using System;
// using FabricaPj;
// using System.Text.Json;
// using System;
// using System.Collections.Generic;

// string jsonString;
// string selectedOption;

// int selectedIndex = 0;
// bool exit = false;
// Random random = new Random();
// List<Pokemon> personajes = new List<Pokemon>();
// //constantes
// string scoreDirectory = "files/score";
// string scoreFileName = "score.json";
// string backupDirectory = "files/backup";
// string pokeFileName = "poke.json";
// string savedGamesDirectory = "files/saved_games";
// string myPokeFileName = "myPoke.json";
// string opponentsFileName = "opponents.json";
// List<string> menuOptions = new List<string>
// {
//     "Nueva Partida",
//     "Cargar Partida",
//     "Máximas Puntuaciones",
// };
// List<string> seguirGuardar = new List<string>
// {
//     "Siguiente Batalla",
//     "Guardar y Salir",
// };
// List<Puntaje> puntajes = await ManejoJson.CargarJson<List<Puntaje>>(scoreDirectory, scoreFileName) ?? new List<Puntaje>();
// Console.Clear();
// //Muestra menu principal y devuelve "lo seleccionado"
// selectedOption = Interface.SeleccionarElemento(menuOptions, ref selectedIndex, ref exit, 2, option => option);
// if (exit) return;

// Console.Clear();
// switch (selectedOption)
// {
//     case "Nueva Partida":
//         Console.WriteLine("Iniciando nueva partida...");
//         bool is_connected = await Validation.CheckInternet();
//         // Verifico si hay internet para realizar la conmeccion con la API o consumo el 'backup' de la ultima conexion
//         if (is_connected)
//         {
//             // obtengo los datos de 10 pokemons
//             Fabrica fabrica = new Fabrica();
//             personajes = await fabrica.CrearListaPoke();
//             Console.WriteLine("Lista de Pokemons creada");
//             jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions
//             {
//                 WriteIndented = true // mejorar la legibilidad del JSON
//             });
//             // Hago un 'backup' de los archivos traidos desde la API
//             await ManejoJson.GuardarJson(backupDirectory, pokeFileName, jsonString);
//         }
//         else
//         {
//             // Recupero el 'backup' de los archivos traidos desde la API en la ultima conexion con internet
//             personajes = await ManejoJson.CargarJson<List<Pokemon>>(backupDirectory, pokeFileName);
//              if (personajes == null)
//             {
//                 Console.WriteLine("No se pudo cargar lista de pokemons.");
//                 return;
//             }


//         }

//         Console.WriteLine("Elige tu Pokemon:");
//         Pokemon op;
//         // A partir de la lista de 10 pokes, obtengo el indice(exit = true en caso de querer salir)
//         // 1 => indica en que forma se mostraran los objetos de la lista
//         // Utilizo función lambda (similar a funcion anonima en js) 
//         // 'p' representa un objeto de tipo Pokemon
//         // 'p.Name' es lo que se evalúa y se devuelve

//         Pokemon myPoke = Interface.SeleccionarElemento(personajes, ref selectedIndex, ref exit, 1, p => p.Name);
//         if (exit) return;// para salir de la ejecucion
//         Console.Clear();
//         // Muestro la seleccion y elimino dicho elemento del total de la lista
//         Console.WriteLine($"Elegiste a {myPoke.Name}");
//         personajes.Remove(myPoke);
//         // Mientras mi poke este vivo y haya rivales, se podra combatir
//         while (myPoke.EstaVivo() && personajes.Count > 0)
//         {
//             int randomIndex = random.Next(personajes.Count);
//             op = personajes[randomIndex];
//             Console.WriteLine($"Te enfrentas a {op.Name}");

//             myPoke.Combate(op);

//             if (myPoke.EstaVivo())
//             {
//                 personajes.Remove(op);
//                 Console.WriteLine("Enter para pasar al siguiente combate o escribe 'g' para guardar y salir:");
//                 string input = Console.ReadLine();
//                 // Compara dos cadenas, ignorando mayusuclas y minusculas con 'OrdinalIgnoreCase'
//                 if (input.Equals("g", StringComparison.OrdinalIgnoreCase))
//                 {
//                     // Guardar el estado del juego
//                     string myPokeJsonString = JsonSerializer.Serialize(myPoke, new JsonSerializerOptions { WriteIndented = true });
//                     await ManejoJson.GuardarJson(savedGamesDirectory, myPokeFileName, myPokeJsonString);

//                     string opponentsJsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
//                     await ManejoJson.GuardarJson(savedGamesDirectory, opponentsFileName, opponentsJsonString);
//                     return; // Salir del juego
//                 }

//             }
//             else
//             {
//                 Console.WriteLine();
//                 Console.WriteLine($"{myPoke.Name} ha sido derrotado!");
//                 Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
//                 Console.WriteLine();
//             }



//             if (myPoke.EstaVivo() && personajes.Count == 0)
//             {
//                 Console.WriteLine();
//                 Console.WriteLine($"{myPoke.Name} ha derrotado a todos los oponentes!");
//                 Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
//                 puntajes = Manejopunts.AgregarPuntaje(puntajes,myPoke.Score,myPoke.Name);
//                 string scoreJsonString = JsonSerializer.Serialize(puntajes, new JsonSerializerOptions { WriteIndented = true });

//                 await ManejoJson.GuardarJson(scoreDirectory,scoreFileName,scoreJsonString);
//                 Console.ReadLine();
//             }
//         }
//         break;
//     case "Cargar Partida":
//         Console.WriteLine("Cargando partida...");
//         myPoke = await ManejoJson.CargarJson<Pokemon>(savedGamesDirectory, myPokeFileName);
//         personajes = await ManejoJson.CargarJson<List<Pokemon>>(savedGamesDirectory, opponentsFileName);
//         if (myPoke == null || personajes == null)
//         {
//             Console.WriteLine("No se pudo cargar la partida guardada.");
//             return;
//         }
//         while (myPoke.EstaVivo() && personajes.Count > 0)
//         {
//             int randomIndex = random.Next(personajes.Count);
//             op = personajes[randomIndex];
//             Console.WriteLine($"Te enfrentas a {op.Name}");
//             myPoke.Combate(op);

//             if (myPoke.EstaVivo())
//             {
//                 personajes.Remove(op);
//                 Console.WriteLine("Enter para pasar al siguiente combate o escribe 'g' para guardar y salir:");
//                 string input = Console.ReadLine();
//                 if (input.Equals("g", StringComparison.OrdinalIgnoreCase))
//                 {
//                     // Guardar el estado del juego
//                     string myPokeJsonString = JsonSerializer.Serialize(myPoke, new JsonSerializerOptions { WriteIndented = true });
//                     await ManejoJson.GuardarJson(savedGamesDirectory, myPokeFileName, myPokeJsonString);

//                     string opponentsJsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
//                     await ManejoJson.GuardarJson(savedGamesDirectory, opponentsFileName, opponentsJsonString);
//                     return; // Salir del juego
//                 }
//             }
//             else
//             {
//                 Console.WriteLine();
//                 Console.WriteLine($"{myPoke.Name} ha sido derrotado!");
//                 Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
//                 Console.WriteLine();
//             }



//             if (myPoke.EstaVivo() && personajes.Count == 0)
//             {
//                 Console.WriteLine();
//                 Console.WriteLine($"{myPoke.Name} ha derrotado a todos los oponentes!");
//                 Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
//                 puntajes = Manejopunts.AgregarPuntaje(puntajes,myPoke.Score,myPoke.Name);
//                 Console.WriteLine();
//                 Console.ReadLine();
//             }
//         }
//         break;
//     case "Máximas Puntuaciones":
//         // Lógica para mostrar máximas puntuaciones
//         Console.WriteLine("Mostrando máximas puntuaciones...");
//         Manejopunts.MostrarMaximasPuntuaciones(puntajes);
//         break;
// }


using FabricaPj;
using System.Text.Json;

string jsonString;
string selectedOption;

int selectedIndex = 0;
bool exit = false;
Random random = new Random();
List<Pokemon> personajes = new List<Pokemon>();
//constantes
string scoreDirectory = "files/score";
string scoreFileName = "score.json";
string backupDirectory = "files/backup";
string pokeFileName = "poke.json";
string savedGamesDirectory = "files/saved_games";
string myPokeFileName = "myPoke.json";
string opponentsFileName = "opponents.json";
List<string> menuOptions = new List<string>
{
    "Nueva Partida",
    "Cargar Partida",
    "Máximas Puntuaciones",
};
List<string> seguirGuardar = new List<string>
{
    "Siguiente Batalla",
    "Guardar y Salir",
};
List<Puntaje> puntajes = await ManejoJson.CargarJson<List<Puntaje>>(scoreDirectory, scoreFileName) ?? new List<Puntaje>();

Juego juego = new Juego();

while (true)
{
    Console.Clear();
    //Muestra menu principal y devuelve "lo seleccionado"
    selectedOption = Interface.SeleccionarElemento(menuOptions, ref selectedIndex, ref exit, 2, option => option);
    if (exit) return;

    Console.Clear();
    switch (selectedOption)
    {
        case "Nueva Partida":
        
            Console.WriteLine("Iniciando nueva partida...");
            bool is_connected = await Validation.CheckInternet();
            
            // Verifico si hay internet para realizar la conmección con la API o consumo el 'backup' de la ultima conexión
            if (is_connected)
            {
                // obtengo los datos de 10 pokemons
                Fabrica fabrica = new Fabrica();
                personajes = await fabrica.CrearListaPoke();
                Console.WriteLine("Lista de Pokemons creada");
                jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions
                {
                    WriteIndented = true // mejorar la legibilidad del JSON
                });
                // Hago un 'backup' de los archivos traidos desde la API
                await ManejoJson.GuardarJson(backupDirectory, pokeFileName, jsonString);
            }
            else
            {
                // Recupero el 'backup' de los archivos traidos desde la API en la ultima conexión con internet
                personajes = await ManejoJson.CargarJson<List<Pokemon>>(backupDirectory, pokeFileName);
                if (personajes == null)
                {
                    Console.WriteLine("No se pudo cargar lista de pokemons.");
                    Console.ReadLine();
                    continue;
                }
            }

            Console.WriteLine("Elige tu Pokemon:");
            Pokemon myPoke = Interface.SeleccionarElemento(personajes, ref selectedIndex, ref exit, 1, p => p.Name);
            if (exit) continue; // Volver al menú principal
            Console.Clear();
            // Muestro la selección y elimino dicho elemento del total de la lista
            Console.WriteLine($"Elegiste a {myPoke.Name}");
            personajes.Remove(myPoke);
            // Iniciar combate
            await juego.IniciarCombate(myPoke, personajes, puntajes);
            break;

        case "Cargar Partida":
            Console.WriteLine("Cargando partida...");
            myPoke = await ManejoJson.CargarJson<Pokemon>(savedGamesDirectory, myPokeFileName);
            personajes = await ManejoJson.CargarJson<List<Pokemon>>(savedGamesDirectory, opponentsFileName);
            if (myPoke == null || personajes == null)
            {
                Console.WriteLine("No se pudo cargar la partida guardada.");
                Console.ReadLine();
                continue;
            }
            // Iniciar combate
            await juego.IniciarCombate(myPoke, personajes, puntajes);
            break;

        case "Máximas Puntuaciones":
            // Lógica para mostrar máximas puntuaciones
            Console.WriteLine("Mostrando máximas puntuaciones...");
            Manejopunts.MostrarMaximasPuntuaciones(puntajes);
            Console.ReadLine();
            break;
    }
}




public class Juego
{
    private string savedGamesDirectory = "files/saved_games";
    private string myPokeFileName = "myPoke.json";
    private string opponentsFileName = "opponents.json";
    private string scoreDirectory = "files/score";
    private string scoreFileName = "score.json";
    private Random random = new Random();

    public async Task IniciarCombate(Pokemon myPoke, List<Pokemon> personajes, List<Puntaje> puntajes)
    {
        while (myPoke.EstaVivo() && personajes.Count > 0)
        {
            int randomIndex = random.Next(personajes.Count);
            Pokemon op = personajes[randomIndex];
            Console.WriteLine($"Te enfrentas a {op.Name}");
            myPoke.Combate(op);

            if (myPoke.EstaVivo())
            {
                personajes.Remove(op);
                Console.WriteLine("Enter para pasar al siguiente combate o escribe 'g' para guardar y salir:");
                string input = Console.ReadLine();
                if (input.Equals("g", StringComparison.OrdinalIgnoreCase))
                {
                    string myPokeJsonString = JsonSerializer.Serialize(myPoke, new JsonSerializerOptions { WriteIndented = true });
                    await ManejoJson.GuardarJson(savedGamesDirectory, myPokeFileName, myPokeJsonString);

                    string opponentsJsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
                    await ManejoJson.GuardarJson(savedGamesDirectory, opponentsFileName, opponentsJsonString);
                    break; // Volver al menú principal
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{myPoke.Name} ha sido derrotado!");
                break; // Volver al menú principal
            }

            if (myPoke.EstaVivo() && personajes.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{myPoke.Name} ha derrotado a todos los oponentes!");
                Console.WriteLine($"Tu puntaje fue: {myPoke.PuntajeFinal()}");
                puntajes = Manejopunts.AgregarPuntaje(puntajes, myPoke.Score, myPoke.Name);
                string scoreJsonString = JsonSerializer.Serialize(puntajes, new JsonSerializerOptions { WriteIndented = true });
                await ManejoJson.GuardarJson(scoreDirectory, scoreFileName, scoreJsonString);
                Console.ReadLine();
                break; // Volver al menú principal
            }
        }
    }


}
