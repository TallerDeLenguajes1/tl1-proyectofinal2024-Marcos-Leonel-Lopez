using FabricaPj;
using System.Text.Json;

string jsonString;
string selectedOption;

int selectedIndex = 0;
bool exit = false;

Random random = new Random();

List<Pokemon> personajes = new List<Pokemon>();
List<Puntaje> puntajes = await ManejoJson.CargarJson<List<Puntaje>>(Constantes.scoreDirectory, Constantes.scoreFileName) ?? new List<Puntaje>();

Juego juego = new Juego();

while (true)
{
    selectedIndex = 0;
    Console.Clear();
    //Muestra menu principal y devuelve "lo seleccionado"
    selectedOption = Interface.SeleccionarElemento(Constantes.menuOptions, ref selectedIndex, ref exit, 2, option => option);
    if (exit) return;
    Console.Clear();
    switch (selectedOption)
    {
        // case "Nueva Partida":
        //     selectedIndex = 0;
        //     Console.WriteLine("Iniciando nueva partida...");
        //     bool is_connected = await Validaciones.CheckInternet();
        //     // Verifico si hay internet para realizar la conmección con la API o consumo el 'backup' de la ultima conexión
        //     if (is_connected)
        //     {
        //         // obtengo los datos de 10 pokemons
        //         Fabrica fabrica = new Fabrica();
        //         personajes = await fabrica.CrearListaPoke();
        //         Console.WriteLine("Lista de Pokemons creada");
        //         jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions
        //         {
        //             WriteIndented = true // mejorar la legibilidad del JSON
        //         });
        //         // Hago un 'backup' de los archivos traidos desde la API
        //         await ManejoJson.GuardarJson(Constantes.backupDirectory, Constantes.pokeFileName, jsonString);
        //     }
        //     else
        //     {
        //         // Recupero el 'backup' de los archivos traidos desde la API en la ultima conexión con internet
        //         personajes = await ManejoJson.CargarJson<List<Pokemon>>(Constantes.backupDirectory, Constantes.pokeFileName);
        //         if (personajes == null)
        //         {
        //             Console.WriteLine("No se pudo cargar lista de pokemons.");
        //             Console.ReadLine();
        //             continue; // Volver al menú principal
        //         }
        //     }
        //     Console.WriteLine("Elige tu Pokemon:");
        //     Pokemon myPoke = Interface.SeleccionarElemento(personajes, ref selectedIndex, ref exit, 1, p => p.Name);
        //     if (exit) continue; // Volver al menú principal
        //     Console.Clear();
        //     // Muestro la selección y elimino dicho elemento del total de la lista
        //     Console.WriteLine($"Elegiste a {myPoke.Name}");
        //     personajes.Remove(myPoke);
        //     // Iniciar combate
        //     await juego.IniciarCombate(myPoke, personajes, puntajes);
        //     break;
        case "Nueva Partida":
            selectedIndex = 0;
            Console.WriteLine("Iniciando nueva partida...");

            int subMenuIndex = 0;
            bool exitSubMenu = false;
            string selectedSubMenuOption = Interface.SeleccionarElemento(Constantes.subMenuOptions, ref subMenuIndex, ref exitSubMenu, 2, option => option);

            if (exitSubMenu)
            {
                Console.WriteLine("\nContinue\n");
                continue;
            }

            Console.Clear();
            switch (selectedSubMenuOption)
            {
                case "Usar datos guardados":
                    Console.WriteLine("Usando datos guardados...");
                    personajes = await ManejoJson.CargarJson<List<Pokemon>>(Constantes.backupDirectory, Constantes.pokeFileName);
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
                        await ManejoJson.GuardarJson(Constantes.backupDirectory, Constantes.pokeFileName, jsonString);
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
            Pokemon myPoke = Interface.SeleccionarElemento(personajes, ref selectedIndex, ref exit, 1, p => p.Name);
            if (exit) continue; // Volver al menú principal
            Console.Clear();
            Console.WriteLine($"Elegiste a {myPoke.Name}");
            personajes.Remove(myPoke);
            await juego.IniciarCombate(myPoke, personajes, puntajes);
            break;


        case "Cargar Partida":
            Console.WriteLine("Cargando partida...");
            Console.WriteLine();
            myPoke = await ManejoJson.CargarJson<Pokemon>(Constantes.savedGamesDirectory, Constantes.myPokeFileName);
            personajes = await ManejoJson.CargarJson<List<Pokemon>>(Constantes.savedGamesDirectory, Constantes.opponentsFileName);
            if (myPoke == null || personajes == null)
            {
                Console.WriteLine("No se pudo cargar la partida guardada.");
                Console.ReadLine();
                continue; // Volver al menú principal
            }
            // Iniciar combate
            await juego.IniciarCombate(myPoke, personajes, puntajes);
            break;

        case "Máximas Puntuaciones":
            // Lógica para mostrar máximas puntuaciones
            Console.WriteLine("Mostrando máximas puntuaciones...");
            ManejoPuntos.MostrarMaximasPuntuaciones(puntajes);
            Console.ReadLine();
            break;
    }
}