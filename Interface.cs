public static class Interface
{
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


    public static T SeleccionarElemento<T>(List<T> elementos, ref int selectedIndex, ref bool exit, int mode, Func<T, string> displayProperty)
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
}