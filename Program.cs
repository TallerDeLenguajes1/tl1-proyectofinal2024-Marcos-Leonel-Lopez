using System;
using FabricaPj;
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



// obtengo los datos de 10 pokemons
Fabrica fabrica = new Fabrica();
List<Pokemon> personajes = new List<Pokemon>();
bool is_connected = await Validation.CheckInternet();
string jsonString;
if (is_connected)
{
    personajes = await fabrica.CrearListaPoke();
    foreach (var poke in personajes)
    {
        Console.WriteLine($"Poke:\n{poke.Atributos()}");
        Console.WriteLine();
    }
    jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions
    {
        WriteIndented = true // mejorar la legibilidad del JSON
    });
    System.Console.WriteLine(jsonString);
    await ManejoJson.GuardarJson("poke.json", jsonString);
}
else
{
    personajes = await ManejoJson.CargarJson("poke.json");
    foreach (var poke in personajes)
    {
        Console.WriteLine($"Poke:\n{poke.Atributos()}");
        Console.WriteLine();
    }
}




