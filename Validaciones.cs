public static class Validation
{
    public static async Task<bool> CheckInternet()
    {
    //Definir como public static permite que el método sea accesible desde otras partes
    //sin necesidad de instanciar la clase.
        try
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5); 
            //Si la solicitud no se completa dentro de los 5 segundos
            //se lanzará una excepción TaskCanceledException.
            HttpResponseMessage response = await client.GetAsync("http://www.google.com");
            return response.IsSuccessStatusCode;

        }
        catch
        {
            return false;
        }
    }
}

