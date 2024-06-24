// public class Personaje
// {
//     private string tipo;
//     private string nombre;
//     private string apodo;
//     private DateTime fecha_nacimiento;
//     private int edad;

//     private int velocidad;
//     private int destreza;
//     private int fuerza;
//     private int nivel;
//     private int armadura;
//     private float salud;

//     public Personaje(string tipo, string nombre, string apodo, DateTime fecha_nacimiento, int edad, int velocidad, int destreza, int fuerza, int armadura)
//     {
//         this.tipo = tipo;
//         this.nombre = nombre;
//         this.apodo = apodo;
//         this.fecha_nacimiento = fecha_nacimiento;
//         this.edad = edad;
//         this.velocidad = velocidad;
//         this.destreza = destreza;
//         this.fuerza = fuerza;
//         this.nivel = 1;
//         this.armadura = armadura;
//         this.salud = 100;
//     }

//     public string Atributos()
//     {
//         return $"{this.nombre}: \n Velocidad: {this.velocidad} \n Destreza: {this.destreza} \n Fuerza: {this.fuerza} \n Nivel: {this.nivel} \n Armadura: {this.armadura} \n Salud: {this.salud}";
//     }

//     private bool estaVivo()
//     {
//         return this.salud > 0;
//     }

//     private void morir()
//     {
//         this.salud = 0;
//         Console.WriteLine($"{this.nombre} ha muerto!");
//     }

//     private float danio(Personaje enemigo)
//     {
//         int ataque, efectividad, defensa, cte;
//         cte = 50;
//         float res;
//         Random random = new Random();
//         ataque = this.destreza * this.fuerza * this.nivel;
//         efectividad = random.Next(0, 101);
//         defensa = enemigo.armadura * enemigo.velocidad;
//         res = (float)((ataque * efectividad) - defensa) / cte;
//         return (float)Math.Round(res, 2);
//     }

//     public void Atacar(Personaje enemigo)
//     {
//         if (this.estaVivo())
//         {
//             float danio = this.danio(enemigo);
//             enemigo.salud = (float)Math.Round((enemigo.salud - danio), 2);
//             Console.WriteLine($"{this.nombre} ha realizado {danio} puntos de daño a {enemigo.nombre}");
//             if (enemigo.estaVivo())
//             {
//                 Console.WriteLine($"La vida de {enemigo.nombre} es {enemigo.salud}");
//             }
//             else
//             {
//                 enemigo.morir();
//             }
//         }else{
//         }
//     }
// }

// public class Type{
//     private string name;
//     public Type(string name)
//     {
//         this.name = name;
//     }
// }
// public class Meta{
//     private int crit_rate;
//     private int drain;
//     private int healing;

//     public Meta(int crit_rate, int drain, int healing)
//     {
//         this.crit_rate = crit_rate;
//         this.drain = drain;
//         this.healing = healing;
//     }
// }
// public class Move
// {
//     private string name;
//     private int accuracy;
//     private int power;
//     private int pp;
//     private Meta meta;
//     private string type;

//     public Move(string name, int accuracy, int power, int pp, Meta meta, string type)
//     {
//         this.name = name;
//         this.accuracy = accuracy;
//         this.power = power;
//         this.pp = pp;
//         this.meta = meta;
//         this.type = type;
//     }
// }
public class Pokemon
{
    private int id;
    private string name;
    private float hp;
    private int attack;
    private int defense;
    private int special_attack;
    private int special_defense;
    private int speed;
    private int level;
    // private List<string> types;
    // private List<Move> moves;

    public Pokemon(int id, string name, int hp, int attack, int defense, int special_attack, int special_defense, int speed)
    {
        this.id = id;
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.special_attack = special_attack;
        this.special_defense = special_defense;
        this.speed = speed;
        this.level = 50;

        // this.types = types;
        // this.moves = moves;
    }

    public string Atributos()
    {
        return $"{this.name}: \n Salud: {this.hp} \n Ataque: {this.attack} \n Defensa: {this.defense} \n Ataque especial: {this.special_attack} \n Defensa especial: {this.special_defense} \n Velocidad: {this.speed}";
    }

    private bool estaVivo()
    {
        return this.hp > 0;
    }

    private void morir()
    {
        this.hp = 0;
        Console.WriteLine($"{this.name} ha muerto!");
    }

    private float danio(Pokemon enemigo, float critic)
    {
        float res, ataque, defensa, modif;
        Random random = new Random();
        int power_move = random.Next(79, 120);
        ataque = (this.attack + this.special_attack) / 2;
        defensa = (enemigo.defense + enemigo.special_defense) / 2;
        modif = critic;
        res = ((((((2 + this.level) / 5) + 2) * power_move * (ataque / defensa)) / 50) + 2) * modif;
        return (float)Math.Round(res, 2);
    }

    public void Atacar(Pokemon enemigo, float critic)
    {
        Random random = new Random();

        int own_luck = random.Next(0, 100);
        int enemy_luck = random.Next(0, 100);
        if (this.estaVivo())
        {
            if (own_luck > enemy_luck)
            {
                critic = 2;
                Console.WriteLine("Ataque critico!!!");
            }
            else
            {
                critic = 1.5F;
            }
            float danio = this.danio(enemigo, critic);
            enemigo.hp = (float)Math.Round((enemigo.hp - danio), 2);
            Console.WriteLine($"{this.name} ha realizado {danio} puntos de daño a {enemigo.name}");
            if (enemigo.estaVivo())
            {
                Console.WriteLine($"La vida de {enemigo.name} es {enemigo.hp}");
            }
            else
            {
                enemigo.morir();
            }
        }
    }

}
