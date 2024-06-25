using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


public static class ManejoJson
{
    public static async Task GuardarJson(string fileName, string jsonString)
    {
    //Definir el método GuardarJson como público y estático:
    //Esto permite que el método sea accesible desde otras partes de tu aplicación sin necesidad de instanciar la clase.
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                await writer.WriteAsync(jsonString);
            }
            Console.WriteLine($"Archivo guardado como {fileName}");
        }
        catch (Exception err)
        {
            Console.WriteLine($"Error al guardar el archivo: {err.Message}");
        }
    }


    public static async Task<List<Pokemon>> CargarJson(string fileName)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string jsonString = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
            }
        }
        catch (Exception err)
        {
            Console.WriteLine($"Error al cargar el archivo: {err.Message}");
            return new List<Pokemon>();
        }
    }

}