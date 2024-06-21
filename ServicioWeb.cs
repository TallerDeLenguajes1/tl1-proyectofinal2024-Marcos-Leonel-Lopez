using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ServicioWeb
{
    // public async Task<Poke> GetPoke()
    // {
    //     Random random = new Random();
    //     int idPersonajes = random.Next(0,150);
    //     System.Console.WriteLine(idPersonajes);
    //     var url = $"https://pokeapi.co/api/v2/pokemon/{idPersonajes}";

    //     try
    //     {
    //         HttpClient client = new HttpClient();
    //         HttpResponseMessage response = await client.GetAsync(url);
    //         response.EnsureSuccessStatusCode();
    //         string responseBody = await response.Content.ReadAsStringAsync();
    //         Poke pokemon = JsonSerializer.Deserialize<Poke>(responseBody);
    //         return pokemon;
    //     }
    //     catch (HttpRequestException err)
    //     {
    //         Console.WriteLine(err.Message);
    //         return null;
    //     }
    // }
    public async Task<T> GetData<T>(string url)
    {
        Random random = new Random();
        int idPersonajes = random.Next(0,150);
        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            T data = JsonSerializer.Deserialize<T>(responseBody);
            return data;
        }
        catch (HttpRequestException err)
        {
            Console.WriteLine(err.Message);
            return default;
        }
    }

}