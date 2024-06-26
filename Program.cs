using System;
using FabricaPj;
using System.Text.Json;
using System;
using System.Collections.Generic;

string jsonString;
int selectedIndex = 0;
bool exit = false;


List<string> menuOptions = new List<string>
        {
            "Nueva Partida",
            "Cargar Partida",
            "Máximas Puntuaciones",
        };
string selectedOption = SeleccionarElemento(menuOptions, ref selectedIndex, ref exit, 2, option => option);
if (exit) return;

Console.Clear();
switch (selectedOption)
{
    case "Nueva Partida":
        // Lógica para nueva partida
        Console.WriteLine("Iniciando nueva partida...");
        break;
    case "Cargar Partida":
        // Lógica para cargar partida
        Console.WriteLine("Cargando partida...");
        break;
    case "Máximas Puntuaciones":
        // Lógica para mostrar máximas puntuaciones
        Console.WriteLine("Mostrando máximas puntuaciones...");
        break;
}
List<Pokemon> personajes = new List<Pokemon>();

bool is_connected = await Validation.CheckInternet();
// Verifico si hay internet para realizar la conmeccion con la API o consumo datos locales creados en la ultima conexion
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
    //System.Console.WriteLine(jsonString);
    await ManejoJson.GuardarJson("poke.json", jsonString);
}
else
{
    personajes = await ManejoJson.CargarJson("poke.json");
}

Console.WriteLine("Elige tu Pokemon:");
Pokemon op;
Pokemon myPoke = SeleccionarElemento(personajes, ref selectedIndex, ref exit, 1, p => p.Name);
if (exit) return;// para salir de la ejecucion
Console.Clear();
Console.WriteLine($"Elegiste a {myPoke.Name}");
personajes.Remove(myPoke);

Random random = new Random();
while (myPoke.EstaVivo() && personajes.Count > 0)
{
    int randomIndex = random.Next(personajes.Count);
    op = personajes[randomIndex];
    Console.WriteLine($"Te enfrentas a {op.Name}");
    Combate(myPoke, op);

    if (myPoke.EstaVivo())
    {
        personajes.Remove(op);
        Console.WriteLine("Enter para pasar al siguiente combate");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine($"{myPoke.Name} ha sido derrotado!");
    }


    if (myPoke.EstaVivo() && personajes.Count == 0)
    {
        Console.WriteLine($"{myPoke.Name} ha derrotado a todos los oponentes!");
        Console.ReadLine();
    }

}


static void Turno(Pokemon op1, Pokemon op2)
{
    if (op1.Speed > op2.Speed)
    {
        op1.Atacar(op2);
        if (op2.EstaVivo())
        {
            op2.Atacar(op1);
        }
    }
    else
    {
        op2.Atacar(op1);
        if (op1.EstaVivo())
        {
            op1.Atacar(op2);
        }
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

static void MostrarElementos<T>(List<T> elementos, int selectedIndex, int mode, Func<T, string> displayProperty)
{
    if (mode == 1)
    {
        int columns = 5;
        int rows = (int)Math.Ceiling((double)elementos.Count / columns);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                int index = row * columns + col;
                if (index < elementos.Count)
                {
                    if (index == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.Write($"| {displayProperty(elementos[index])} |\t");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nUse las flechas arriba/abajo para navegar por filas, izquierda/derecha para navegar por columnas, Enter para seleccionar, Escape para salir.");
    }
    else
    {
        for (int i = 0; i < elementos.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write("  ");
            }
            Console.WriteLine($"- {displayProperty(elementos[i])}");
        }
        Console.WriteLine("\nUse las flechas arriba/abajo para navegar, Enter para seleccionar, Escape para salir.");
    }
}


static T SeleccionarElemento<T>(List<T> elementos, ref int selectedIndex, ref bool exit, int mode, Func<T, string> displayProperty)
{
    int columns = 5;

    while (!exit)
    {
        Console.Clear();
        MostrarElementos(elementos, selectedIndex, mode, displayProperty);
        var key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (mode == 1 && selectedIndex >= columns) selectedIndex -= columns;
                else if (selectedIndex > 0) selectedIndex--;
                break;
            case ConsoleKey.DownArrow:
                if (mode == 1 && selectedIndex + columns < elementos.Count) selectedIndex += columns;
                else if (selectedIndex < elementos.Count - 1) selectedIndex++;
                break;
            case ConsoleKey.LeftArrow:
                if (mode == 1 && selectedIndex > 0) selectedIndex--;
                break;
            case ConsoleKey.RightArrow:
                if (mode == 1 && selectedIndex < elementos.Count - 1) selectedIndex++;
                break;
            case ConsoleKey.Enter:
                return elementos[selectedIndex];
            case ConsoleKey.Escape:
                Console.WriteLine("SSaliendo..."); // No toma la primera letra de la cadena ¿¿¿???
                exit = true;
                break;
        }
    }
    return default;
}



// static void MostrarPersonajes(List<Pokemon> personajes, int selectedIndex, int mode)
// {
//     if (mode == 1)
//     {
//         for (int i = 0; i < personajes.Count; i++)
//         {
//             if (i == selectedIndex)
//             {
//                 Console.BackgroundColor = ConsoleColor.Gray;
//                 Console.ForegroundColor = ConsoleColor.DarkRed;
//             }
//             Console.WriteLine($"{i + 1}. {personajes[i].Name}");
//             Console.ResetColor();
//         }
//         Console.WriteLine("\nUse las flechas arriba/abajo para navegar, Enter para seleccionar, Escape para salir.");
//     }
//     else
//     {
//         for (int i = 0; i < personajes.Count; i++)
//         {
//             if (i == selectedIndex)
//             {
//                 Console.Write("> "); //Marca el elemento seleccionado con '>'
//             }
//             else
//             {
//                 Console.Write("  "); //No marca los elementos no seleccionados
//             }
//             Console.WriteLine($"{i + 1}. {personajes[i].Name}");
//         }
//         Console.WriteLine("\nUse las flechas arriba/abajo para navegar, Enter para seleccionar, Escape para salir.");
//     }
// }

// static Pokemon SeleccionarPokemon(List<Pokemon> personajes, ref int selectedIndex, ref bool exit)
// {
//     while (!exit)
//     {
//         Console.Clear();
//         MostrarPersonajes(personajes, selectedIndex, 1);
//         var key = Console.ReadKey();
//         switch (key.Key)
//         {
//             case ConsoleKey.UpArrow:
//                 if (selectedIndex > 0) selectedIndex--;
//                 break;
//             case ConsoleKey.DownArrow:
//                 if (selectedIndex < personajes.Count - 1) selectedIndex++;
//                 break;
//             case ConsoleKey.Enter:
//                 Console.Clear();
//                 Console.WriteLine(personajes[selectedIndex].Atributos());
//                 Console.WriteLine("\nSelecciona este Poke? (Y/N)");
//                 var confirmKey = Console.ReadKey();
//                 if (confirmKey.Key == ConsoleKey.Y)
//                 {
//                     return personajes[selectedIndex];
//                 }
//                 break;
//             case ConsoleKey.Escape:
//                 exit = true;
//                 break;
//         }
//     }
//     return null;
// }







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