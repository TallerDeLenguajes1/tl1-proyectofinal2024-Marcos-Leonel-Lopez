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

//     private bool EstaVivo()
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
//         if (this.EstaVivo())
//         {
//             float danio = this.danio(enemigo);
//             enemigo.salud = (float)Math.Round((enemigo.salud - danio), 2);
//             Console.WriteLine($"{this.nombre} ha realizado {danio} puntos de daño a {enemigo.nombre}");
//             if (enemigo.EstaVivo())
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
    private float hp_max;
    private int attack;
    private int defense;
    private int special_attack;
    private int special_defense;
    private int speed;
    private int level;
    //private List<string> types;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public float Hp { get => hp; set => hp = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Defense { get => defense; set => defense = value; }
    public int Special_attack { get => special_attack; set => special_attack = value; }
    public int Special_defense { get => special_defense; set => special_defense = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Level { get => level; set => level = value; }
    public float Hp_max { get => hp_max; }


    // private List<Move> moves;
    public Pokemon() { } // necesario para dezerializar
    public Pokemon(int id, string name, int hp, int attack, int defense, int special_attack, int special_defense, int speed)
    {
        this.Id = id;
        this.Name = name.ToUpper();
        this.Hp = hp;
        this.hp_max = hp;
        this.Attack = attack;
        this.Defense = defense;
        this.Special_attack = special_attack;
        this.Special_defense = special_defense;
        this.Speed = speed;
        this.Level = 50;

        // this.types = types;
        // this.moves = moves;
    }

    public string Atributos()
    {
        return $"{this.Name}: \n Salud: {this.Hp} \n Ataque: {this.Attack} \n Defensa: {this.Defense} \n Ataque especial: {this.Special_attack} \n Defensa especial: {this.Special_defense} \n Velocidad: {this.Speed}";
    }

    public bool EstaVivo()
    {
        return this.Hp > 0;
    }

    private void morir()
    {
        this.Hp = 0;
        Console.WriteLine($"{this.Name} fue vencido!");
    }

    private float danio(Pokemon enemigo, float critic)
    {
        float res, ataque, defensa, modif;
        Random random = new Random();
        int power_move = random.Next(79, 120);
        ataque = (this.Attack + this.Special_attack) / 2;
        defensa = (enemigo.Defense + enemigo.Special_defense) / 2;
        modif = critic;
        res = ((((((2 + this.Level) / 5) + 2) * power_move * (ataque / defensa)) / 100) + 2) * modif; //en un principio se divide por 50, luego modifico a 100
        return (float)Math.Round(res, 2);
    }

    public void Atacar(Pokemon enemigo)
    {
        if (enemigo.EstaVivo() && this.EstaVivo())
        {
            Console.WriteLine($"{this.name} ataco a {enemigo.Name}");
            Random random = new Random();
            float critic;
            int own_luck = random.Next(0, 100);
            int enemy_luck = random.Next(50, 100);
            if (this.EstaVivo())
            {
                if (own_luck > enemy_luck)
                {
                    critic = 2;
                    Console.WriteLine("== Ataque critico ==");
                }
                else
                {
                    critic = 1.5F;
                }
                float danio = this.danio(enemigo, critic);
                enemigo.Hp = (float)Math.Round((enemigo.Hp - danio), 2);
                Console.WriteLine($"{this.Name} ha realizado {danio} puntos de daño a {enemigo.Name}");
                if (enemigo.EstaVivo())
                {
                    Console.WriteLine($"La vida de {enemigo.Name} es {enemigo.Hp}");
                }
                else
                {
                    enemigo.morir();
                    this.recompensa();
                    Console.WriteLine($"{this.Name} recupero salud, su nueva salud es {this.Hp} e incremento sus estadisticas");
                }
            }
        }

    }

    private void recompensa()
    {
        Random random = new Random();
        this.Hp += (float)Math.Round((float)this.Hp_max * 0.5f, 2);
        this.Attack += random.Next(0, 1);
        this.Defense += random.Next(0, 1);
        this.Special_attack += random.Next(0, 1);
        this.Special_defense += random.Next(0, 1);
        this.Speed += random.Next(0, 1);
    }

    private void turno(Pokemon enemigo)
    {
        if (this.Speed > enemigo.Speed)
        {
            this.Atacar(enemigo);
            if (enemigo.EstaVivo())
            {
                enemigo.Atacar(this);
            }
        }
        else
        {
            enemigo.Atacar(this);
            if (this.EstaVivo())
            {
                this.Atacar(enemigo);
            }
        }
    }

    private void ganador(Pokemon enemigo)
    {
        Pokemon aux = this.EstaVivo() ? this : enemigo;
        Console.WriteLine($"Gano {aux.Name}");
    }

    public void Combate(Pokemon enemigo)
    {
        do
        {
            this.turno(enemigo);
        } while (this.EstaVivo() && enemigo.EstaVivo());
        this.ganador(enemigo);
    }

}
