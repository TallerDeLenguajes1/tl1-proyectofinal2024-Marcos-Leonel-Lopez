// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Text.Json.Serialization;
// POKEMON
namespace InfoPokeAPI
{
    public class Move
    {
        [JsonPropertyName("move")]
        public Move2 move { get; set; }
    }

    public class Move2
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class Poke
    {
        [JsonPropertyName("height")]
        public int height { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("moves")]
        public List<Move> moves { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("order")]
        public int order { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> stats { get; set; }

        [JsonPropertyName("types")]
        public List<Type> types { get; set; }

        [JsonPropertyName("weight")]
        public int weight { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("base_stat")]
        public int base_stat { get; set; }

        [JsonPropertyName("effort")]
        public int effort { get; set; }

        [JsonPropertyName("stat")]
        public Stat2 stat { get; set; }
    }

    public class Stat2
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class Type
    {
        [JsonPropertyName("slot")]
        public int slot { get; set; }

        [JsonPropertyName("type")]
        public Type2 type { get; set; }
    }

    public class Type2
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

// TIPOS
    public class Result
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class TiposPoke
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("results")]
        public List<Result> results { get; set; }
    }

// DAÑO SEGUN POKE

    public class DamageRelations
    {
        [JsonPropertyName("double_damage_from")]
        public List<DoubleDamageFrom> double_damage_from { get; set; }

        [JsonPropertyName("double_damage_to")]
        public List<object> double_damage_to { get; set; }

        [JsonPropertyName("half_damage_from")]
        public List<object> half_damage_from { get; set; }

        [JsonPropertyName("half_damage_to")]
        public List<HalfDamageTo> half_damage_to { get; set; }

        [JsonPropertyName("no_damage_from")]
        public List<NoDamageFrom> no_damage_from { get; set; }

        [JsonPropertyName("no_damage_to")]
        public List<NoDamageTo> no_damage_to { get; set; }
    }

    public class DoubleDamageFrom
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

    }

    public class HalfDamageTo
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
    }

    public class NoDamageFrom
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

    }

    public class NoDamageTo
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

    }

    public class DanioSegunTipo
    {
        [JsonPropertyName("damage_relations")]
        public DamageRelations damage_relations { get; set; }
    }
 
}
    