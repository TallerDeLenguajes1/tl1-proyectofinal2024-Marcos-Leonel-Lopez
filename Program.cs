using System;
using System.Text.Json;
// DateTime nac = DateTime.Now;
// //Personaje NuevoPJ1 = new Personaje("Planta","Chicorita","Chico",nac,12,5,4,9,10);
// //Personaje NuevoPJ2 = new Personaje("Fuego","Charmander","Char",nac,12,10,5,9,10);

// // var listaPersonajes = new List<Personaje>();
// // listaPersonajes.Add(new Personaje("Planta", "Chicorita", "Chico", nac, 12, 5, 4, 9, 10));
// // listaPersonajes.Add(new Personaje("Fuego", "Charmander", "Char", nac, 12, 10, 5, 9, 10));


// // Console.WriteLine(listaPersonajes[0].Atributos());
// // Console.WriteLine(listaPersonajes[1].Atributos());
// // Console.WriteLine("===");
// // listaPersonajes[0].Atacar(listaPersonajes[1]);
// // Console.WriteLine("===");
// // listaPersonajes[0].Atacar(listaPersonajes[1]);
// // Console.WriteLine("===");
// // listaPersonajes[0].Atacar(listaPersonajes[1]);
// // Console.WriteLine("===");
// // listaPersonajes[1].Atacar(listaPersonajes[0]);
// // Console.WriteLine("===");
// // Console.WriteLine(listaPersonajes[0].Atributos());
// // Console.WriteLine(listaPersonajes[1].Atributos());
// // Console.WriteLine("===\nEsta vivo? " + NuevoPJ1.Esta_Vivo());
// // NuevoPJ1.morir();
// // Console.WriteLine("===\nEsta vivo? " + NuevoPJ1.Esta_Vivo());

// bool isConnected = await Validation.CheckInternetConnection();
// if (isConnected)
// {
//     int idPersonajes = 1;
//     var url = $"https://pokeapi.co/api/v2/pokemon/{idPersonajes}";
//     ServicioWeb servicioWeb = new ServicioWeb();

//     Poke poke = await servicioWeb.GetData<Poke>(url);

//     // string jsonString = JsonSerializer.Serialize(poke);
//     // await SaveJsonToFileAsync("poke.json", jsonString);

//     System.Console.WriteLine($"Nombre {poke.name}");
//     System.Console.WriteLine($"Tipo1 {poke.types[0].type.name}");
//     System.Console.WriteLine($"Tipo2 {poke.types[1].type.name}");
// }
// else
// {
//     Console.WriteLine("No hay conexión a Internet.");
// }

// static async Task SaveJsonToFileAsync(string fileName, string jsonString)
// {
//     try
//     {
//         using (StreamWriter writer = new StreamWriter(fileName, false))
//         {
//             await writer.WriteAsync(jsonString);
//         }
//         Console.WriteLine($"Archivo guardado como {fileName}");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
//     }
// }
using FabricaPj;


// obtengo los datos de 10 pokemons
Fabrica fabrica = new Fabrica();
List<Pokemon> personajes = await fabrica.CrearListaPoke();
foreach (var poke in personajes)
{
    Console.WriteLine($"Poke:\n{poke.Atributos()}");
    // Console.WriteLine("Types: " + string.Join(", ", poke.types.Select(t => t.type.name)));
    Console.WriteLine();
}
string jsonString = JsonSerializer.Serialize(personajes);
await GuardarJson("poke.json", jsonString);



static async Task GuardarJson(string fileName, string jsonString)
{
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