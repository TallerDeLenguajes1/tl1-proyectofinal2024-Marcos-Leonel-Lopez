
Personaje NuevoPJ1 = new Personaje("Marcos",150,3,5,7,9);
Personaje NuevoPJ2 = new Personaje("Naty",80,10,8,5,3);

Console.WriteLine(NuevoPJ1.Atributos());
Console.WriteLine(NuevoPJ2.Atributos());
Console.WriteLine("===");
NuevoPJ1.Atacar(NuevoPJ2);
Console.WriteLine("===");
NuevoPJ1.Atacar(NuevoPJ2);
Console.WriteLine("===");
NuevoPJ1.Atacar(NuevoPJ2);
Console.WriteLine("===");
NuevoPJ2.Atacar(NuevoPJ1);
Console.WriteLine("===");
Console.WriteLine(NuevoPJ1.Atributos());
Console.WriteLine(NuevoPJ2.Atributos());
// Console.WriteLine("===\nEsta vivo? " + NuevoPJ1.Esta_Vivo());
// NuevoPJ1.morir();
// Console.WriteLine("===\nEsta vivo? " + NuevoPJ1.Esta_Vivo());