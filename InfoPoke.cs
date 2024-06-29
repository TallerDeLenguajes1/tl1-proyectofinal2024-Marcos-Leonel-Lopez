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

    // public class DamageRelations
    // {
    //     [JsonPropertyName("double_damage_from")]
    //     public List<DoubleDamageFrom> double_damage_from { get; set; }

    //     [JsonPropertyName("double_damage_to")]
    //     public List<DoubleDamageTo> double_damage_to { get; set; }

    //     [JsonPropertyName("half_damage_from")]
    //     public List<HalfDamageFrom> half_damage_from { get; set; }

    //     [JsonPropertyName("half_damage_to")]
    //     public List<HalfDamageTo> half_damage_to { get; set; }

    //     [JsonPropertyName("no_damage_from")]
    //     public List<object> no_damage_from { get; set; }

    //     [JsonPropertyName("no_damage_to")]
    //     public List<object> no_damage_to { get; set; }
    // }

    // public class DoubleDamageFrom
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class DoubleDamageTo
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class GameIndex
    // {
    //     [JsonPropertyName("game_index")]
    //     public int game_index { get; set; }

    //     [JsonPropertyName("generation")]
    //     public Generation generation { get; set; }
    // }

    // public class Generation
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class HalfDamageFrom
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class HalfDamageTo
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class Language
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class Move_type
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class MoveDamageClass
    // {
    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class Name
    // {
    //     [JsonPropertyName("language")]
    //     public Language language { get; set; }

    //     [JsonPropertyName("name")]
    //     public string name { get; set; }
    // }

    // public class PastDamageRelation
    // {
    //     [JsonPropertyName("damage_relations")]
    //     public DamageRelations damage_relations { get; set; }

    //     [JsonPropertyName("generation")]
    //     public Generation generation { get; set; }
    // }

    // public class Pokemon
    // {
    //     [JsonPropertyName("pokemon")]
    //     public Pokemon pokemon { get; set; }

    //     [JsonPropertyName("slot")]
    //     public int slot { get; set; }

    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("url")]
    //     public string url { get; set; }
    // }

    // public class Type_Naturaleza
    // {
    //     [JsonPropertyName("damage_relations")]
    //     public DamageRelations damage_relations { get; set; }

    //     [JsonPropertyName("game_indices")]
    //     public List<GameIndex> game_indices { get; set; }

    //     [JsonPropertyName("generation")]
    //     public Generation generation { get; set; }

    //     [JsonPropertyName("id")]
    //     public int id { get; set; }

    //     [JsonPropertyName("move_damage_class")]
    //     public MoveDamageClass move_damage_class { get; set; }

    //     [JsonPropertyName("moves")]
    //     public List<Move> moves { get; set; }

    //     [JsonPropertyName("name")]
    //     public string name { get; set; }

    //     [JsonPropertyName("names")]
    //     public List<Name> names { get; set; }

    //     [JsonPropertyName("past_damage_relations")]
    //     public List<PastDamageRelation> past_damage_relations { get; set; }

    //     [JsonPropertyName("pokemon")]
    //     public List<Pokemon> pokemon { get; set; }
    // }


 
}
    