using System.Text.Json;

public static class ManejoJson
{
    // 
    public static async Task GuardarJson(string directoryPath, string fileName, string jsonString)
    {
        try
        {
            // Crear el directorio si no existe
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName);
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                await writer.WriteAsync(jsonString);
            }
            Console.WriteLine($"Archivo guardado");
        }
        catch (Exception err)
        {
            Console.WriteLine($"Error al guardar el archivo: {err.Message}");
        }
    }

    public static async Task<T> CargarJson<T>(string directoryPath, string fileName)
    {
        try
        {
            string filePath = Path.Combine(directoryPath, fileName);
            if (!File.Exists(filePath))
            {
                //throw new FileNotFoundException($"El archivo {filePath} no existe.");
                //Console.WriteLine($"El archivo {filePath} no existe.");
                return default;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string jsonString = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<T>(jsonString);
            }
        }
        catch (Exception err)
        {
            Console.WriteLine($"Error al cargar el archivo: {err.Message}");
            return default;
        }
    }

    public static void EliminarArchivosJson(string directoryPath)
    {
        try
        {
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath, "*.json");
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
        }
        catch (Exception err)
        {
            Console.WriteLine($"Error al eliminar archivos: {err.Message}");
        }
    }
}