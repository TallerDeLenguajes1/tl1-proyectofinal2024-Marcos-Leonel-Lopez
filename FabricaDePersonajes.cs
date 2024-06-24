using InfoPokeAPI;
namespace FabricaPj
{
    public class Fabrica
    {
        public async Task<List<Pokemon>> CrearListaPoke()
        {
            var personajes = new List<Pokemon>();
            var ids_usados = new HashSet<int>(); // que es HashSet?
            int count_id = 0;
            ServicioWeb servicioWeb = new ServicioWeb();
            Random random = new Random();
            while (count_id < 10)
            {
                int id_poke = random.Next(0, 151);
                System.Console.WriteLine($"El id es {id_poke}");
                if (!ids_usados.Contains(id_poke))
                {
                    ids_usados.Add(id_poke);
                    var url = $"https://pokeapi.co/api/v2/pokemon/{id_poke}";
                    Poke poke = await servicioWeb.GetData<Poke>(url);
                    string name = poke.name;
                    int hp = poke.stats[0].base_stat;
                    int attack = poke.stats[1].base_stat;
                    int defense = poke.stats[2].base_stat;
                    int special_attack = poke.stats[3].base_stat;
                    int special_defense = poke.stats[4].base_stat;
                    int speed = poke.stats[5].base_stat;
                    var nuevoPoke = new Pokemon(id_poke,name,hp,attack,defense,special_attack,special_defense,speed);
                    personajes.Add(nuevoPoke);
                    count_id++;
                }
            }
            return personajes;
        }
    }
}