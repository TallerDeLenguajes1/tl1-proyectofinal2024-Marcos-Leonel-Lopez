using FabricaPj;
using System.Text.Json;

string jsonString;
string opSeleccionada;

int indiceSelec = 0;
bool exit = false;

Random random = new Random();

List<Pokemon> personajes = new List<Pokemon>();
List<Puntaje> puntajes = await ManejoJson.CargarJson<List<Puntaje>>(Constantes.ScoreDirectorio, Constantes.ScoreFileName) ?? new List<Puntaje>();

//Juego juego = new Juego();

while (true)
{
    indiceSelec = 0;
    Console.Clear();
    //Muestra menu principal y devuelve "lo seleccionado"
    opSeleccionada = Interface.SeleccionarElemento(Constantes.MenuOptions, ref indiceSelec, ref exit, 2, option => option);
    if (exit)
    {
        return;
    }
    Console.Clear();
    switch (opSeleccionada)
    {
        case "Nueva Partida":
            // indiceSelec = 0;
            Console.WriteLine("Iniciando nueva partida...");
            int indexSubMenu = 0;
            bool exitSubMenu = false;
            string opSelecSubMenu = Interface.SeleccionarElemento(Constantes.SubMenuOptions, ref indexSubMenu, ref exitSubMenu, 2, option => option);
            if (exitSubMenu)
            {
                continue;
            }

            Console.Clear();
            switch (opSelecSubMenu)
            {
                case "Usar datos guardados":
                    Console.WriteLine("Usando datos guardados...");
                    personajes = await ManejoJson.CargarJson<List<Pokemon>>(Constantes.BackupDirectorio, Constantes.PokeFileName);
                    if (personajes == null)
                    {
                        Console.WriteLine("No se pudo cargar lista de pokemons desde el respaldo.");
                        Console.ReadLine();
                        continue; // Volver al menú principal
                    }
                    break;

                case "Cargar nuevos datos":
                    Console.WriteLine("Cargando nuevos datos desde la API...");
                    bool isConnected = await Validaciones.CheckInternet();
                    if (isConnected)
                    {
                        // podria ser static
                        Fabrica fabrica = new Fabrica();
                        personajes = await fabrica.CrearListaPoke();
                        if (personajes == null || personajes.Count() == 0)
                        {
                            Console.ReadKey();
                            continue; // Volver al menú principal
                        }

                        Console.WriteLine("Lista de Pokemons creada");
                        jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions
                        {
                            WriteIndented = true // mejorar la legibilidad del JSON
                        });
                        await ManejoJson.GuardarJson(Constantes.BackupDirectorio, Constantes.PokeFileName, jsonString);
                    }
                    else
                    {
                        Console.WriteLine("No hay conexión a Internet para cargar nuevos datos.");
                        Console.ReadLine();
                        continue; // Volver al menú principal
                    }
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    continue; // Volver al menú principal
            }

            Console.WriteLine("Elige tu Pokemon:");
            indexSubMenu = 0;
            Pokemon myPoke = Interface.SeleccionarElemento(personajes, ref indexSubMenu, ref exitSubMenu, 1, p => p.Name);
            if (exitSubMenu)
            {
                continue;
            } // Volver al menú principal
            Console.Clear();
            Console.WriteLine($"Elegiste a {myPoke.Name}");
            personajes.Remove(myPoke);
            await Juego.IniciarCombate(myPoke, personajes, puntajes);
            break;


        case "Cargar Partida":
            Console.WriteLine("Cargando partida...");
            Console.WriteLine();
            myPoke = await ManejoJson.CargarJson<Pokemon>(Constantes.SavedGamesDirectorio, Constantes.MyPokeFileName);
            personajes = await ManejoJson.CargarJson<List<Pokemon>>(Constantes.SavedGamesDirectorio, Constantes.OponentsFileName);
            if (myPoke == null || personajes == null)
            {
                Console.WriteLine("No se pudo cargar la partida guardada.");
                Console.ReadLine();
                continue; // Volver al menú principal
            }
            await Juego.IniciarCombate(myPoke, personajes, puntajes);
            break;

        case "Máximas Puntuaciones":
            Console.WriteLine("Mostrando máximas puntuaciones...");
            ManejoPuntos.MostrarMaximasPuntuaciones(puntajes);
            Console.ReadLine();
            break;
    }

}