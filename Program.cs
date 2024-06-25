using System;
using FabricaPj;
using System.Text.Json;

List<Pokemon> personajes = new List<Pokemon>();
bool is_connected = await Validation.CheckInternet();
string jsonString;
int selectedIndex = 0;
bool exit = false;

if (is_connected)
{
    // obtengo los datos de 10 pokemons
    Fabrica fabrica = new Fabrica();
    personajes = await fabrica.CrearListaPoke();
    // foreach (var poke in personajes)
    // {
    //     Console.WriteLine($"Poke:\n{poke.Atributos()}");
    //     Console.WriteLine();
    // }
    Console.WriteLine("Lista de Pokemons creada");
    jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions
    {
        WriteIndented = true // mejorar la legibilidad del JSON
    });
    //System.Console.WriteLine(jsonString);
    await ManejoJson.GuardarJson("poke.json", jsonString);
}
else
{
    personajes = await ManejoJson.CargarJson("poke.json");
    // foreach (var poke in personajes)
    // {
    //     Console.WriteLine($"Poke:\n{poke.Atributos()}");
    //     Console.WriteLine();
    // }
}
// Console.WriteLine("Oponente 1");
// Pokemon op1 = personajes[0];
// Console.WriteLine(personajes[0].Atributos());
// Console.WriteLine("Oponente 2");
// Pokemon op2 = personajes[5];
// Console.WriteLine(personajes[5].Atributos());

// Combate(op1, op2);

Console.WriteLine("Elige tu Pokemon:");
Pokemon op1 = SeleccionarPokemon(personajes, ref selectedIndex, ref exit);
if (exit) return;// para salir de la ejecucion
Console.Clear();
System.Console.WriteLine($"Elegiste a {op1.Name}");

static void Turno(Pokemon op1, Pokemon op2)
{
    if (op1.Speed > op2.Speed)
    {
        op1.Atacar(op2);
        op2.Atacar(op1);
    }
    else
    {
        op2.Atacar(op1);
        op1.Atacar(op2);
    }
}

static void Ganador(Pokemon op1, Pokemon op2)
{
    Pokemon aux = op1.EstaVivo() ? op1 : op2;
    Console.WriteLine($"Gano {aux.Name}");
}

static void Combate(Pokemon op1, Pokemon op2)
{
    do
    {
        Turno(op1, op2);
    } while (op1.EstaVivo() && op2.EstaVivo());
    Ganador(op1, op2);
}




static void MostrarPersonajes(List<Pokemon> personajes, int selectedIndex)
{
    for (int i = 0; i < personajes.Count; i++)
    {
        if (i == selectedIndex)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        Console.WriteLine($"{i + 1}. {personajes[i].Name}");
        Console.ResetColor();
    }
    Console.WriteLine("\nUse las flechas arriba/abajo para navegar, Enter para seleccionar, Escape para salir.");

    // for (int i = 0; i < personajes.Count; i++)
    //     {
    //         if (i == selectedIndex)
    //         {
    //             Console.Write("> "); // Marca el elemento seleccionado con '>'
    //         }
    //         else
    //         {
    //             Console.Write("  "); // No marca los elementos no seleccionados
    //         }
    //         Console.WriteLine($"{i + 1}. {personajes[i].Name}");
    //     }
    //     Console.WriteLine("\nUse las flechas arriba/abajo para navegar, Enter para seleccionar, Escape para salir.");
}

static Pokemon SeleccionarPokemon(List<Pokemon> personajes, ref int selectedIndex, ref bool exit)
    {
        while (!exit)
        {
            Console.Clear();
            MostrarPersonajes(personajes, selectedIndex);
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedIndex > 0) selectedIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedIndex < personajes.Count - 1) selectedIndex++;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Console.WriteLine(personajes[selectedIndex].Atributos());
                    Console.WriteLine("\nSelecciona este Poke? (Y/N)");
                    var confirmKey = Console.ReadKey();
                    if (confirmKey.Key == ConsoleKey.Y)
                    {
                        return personajes[selectedIndex];
                    }
                    break;
                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        }
        return null;
    }







// while (!exit)
// {
//     Console.Clear();
//     Console.WriteLine("Elige tu Pokemon:");
//     MostrarPersonajes(personajes, selectedIndex);
//     var key = Console.ReadKey();
//     switch (key.Key)
//     {
//         case ConsoleKey.UpArrow:
//             if (selectedIndex > 0) selectedIndex--;
//             break;
//         case ConsoleKey.DownArrow:
//             if (selectedIndex < personajes.Count - 1) selectedIndex++;
//             break;
//         case ConsoleKey.Enter:
//             Console.Clear();
//             Console.WriteLine(personajes[selectedIndex].Atributos());
//             Console.WriteLine("\nSelecciona este Poke?");
//             Console.ReadKey();
//             break;
//         case ConsoleKey.Escape:
//             exit = true;
//             break;
//     }
// }