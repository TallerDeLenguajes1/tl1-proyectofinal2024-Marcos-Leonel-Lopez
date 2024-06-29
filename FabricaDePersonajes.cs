using InfoPokeAPI;
namespace FabricaPj
{
    public class Fabrica
    {
        public async Task<List<Pokemon>> CrearListaPoke()
        {
            var personajes = new List<Pokemon>();
            var ids_usados = new HashSet<int>();
            int count_id = 0;
            ServicioWeb servicioWeb = new ServicioWeb();
            Random random = new Random();
            bool err = false;

            while (count_id < 10)
            {
                int id_poke = random.Next(1, 151);
                if (!ids_usados.Contains(id_poke))
                {
                    ids_usados.Add(id_poke);
                    var url = Constantes.GetPokemonUrl(id_poke);

                    try
                    {
                        Poke poke = await servicioWeb.GetData<Poke>(url);
                        string name = poke.name;
                        int hp = poke.stats[0].base_stat;
                        int attack = poke.stats[1].base_stat;
                        int defense = poke.stats[2].base_stat;
                        int special_attack = poke.stats[3].base_stat;
                        int special_defense = poke.stats[4].base_stat;
                        int speed = poke.stats[5].base_stat;
                        int IV = random.Next(0, 32);

                        var nuevoPoke = new Pokemon(id_poke, name, hp, attack, defense, special_attack, special_defense, speed, IV);
                        personajes.Add(nuevoPoke);
                        count_id++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al intentar obtener datos: {ex.Message}");
                        if (count_id == 0)
                        {
                            err = true;
                            break;
                        }
                    }
                }
            }

            if (err)
            {
                personajes.Clear();
            }

            return personajes;
        }
    }
}
