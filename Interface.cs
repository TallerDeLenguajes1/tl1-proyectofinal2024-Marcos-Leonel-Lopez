public static class Interface
{
    // A la función lambda 'p => p/Name' le asigno 'Func<Pokemon, string>' llamado mostrarProp
    // Luego puedo llamar a esa función usando mostrarProp({elemento})
    static void MostrarElementos<T>(List<T> elementos, int selectedIndex, int mode, Func<T, string> mostrarProp)
    {
        if (mode == 1)
        {
            // Navegacion por filas y columnas
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
                        Console.Write($"| {mostrarProp(elementos[index])} |\t");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nUse las flechas para navegar; Enter para seleccionar; Escape para salir.");
        }
        else
        {
            // Navegacion en una sola columna
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
                Console.WriteLine($"- {mostrarProp(elementos[i])}");
            }
            Console.WriteLine("\nUse las flechas arriba/abajo para navegar; Enter para seleccionar; Escape para salir.");
        }
    }

    // 'mode igual a 1 o 2' se pasa para seleccionar el tipo de vista

    public static T SeleccionarElemento<T>(List<T> elementos, ref int selectedIndex, ref bool exit, int mode, Func<T, string> mostrarProp)
    {
        
        int columns = 5;

        while (!exit)
        {
            Console.Clear();
            // Mostramos los elementos según el modo seleccionado
            MostrarElementos(elementos, selectedIndex, mode, mostrarProp);

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (mode == 1 && selectedIndex >= columns)
                    {
                        selectedIndex -= columns;
                    }
                    else if (selectedIndex > 0)
                    {
                        selectedIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (mode == 1 && selectedIndex + columns < elementos.Count)
                    {
                        selectedIndex += columns;
                    }
                    else if (selectedIndex < elementos.Count - 1)
                    {
                        selectedIndex++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (mode == 1 && selectedIndex > 0)
                    {
                        selectedIndex--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (mode == 1 && selectedIndex < elementos.Count - 1)
                    {
                        selectedIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    // Manejo de la selección del elemento
                    if (typeof(T) == typeof(Pokemon))
                    {
                        Pokemon poke = elementos[selectedIndex] as Pokemon;
                        Console.WriteLine(poke.Atributos());
                        Console.WriteLine("\n¿Seleccionar este elemento? \nY: para confirmar \nCualquier otra tecla para volver");
                        var confirmKey = Console.ReadKey();
                        if (confirmKey.Key == ConsoleKey.Y)
                        {
                            return elementos[selectedIndex];
                        }
                    }
                    else
                    {
                        return elementos[selectedIndex];
                    }
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("\nSSaliendo...");
                    exit = true; // Salir del bucle
                    break;
            }
        }

        return default; // Valor por defecto si no se selecciona ningún elemento
    }

}