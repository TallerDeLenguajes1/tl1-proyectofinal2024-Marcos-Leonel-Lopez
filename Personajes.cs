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
    private float score;
    private int iv;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public float Hp { get => hp; set => hp = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Defense { get => defense; set => defense = value; }
    public int Special_attack { get => special_attack; set => special_attack = value; }
    public int Special_defense { get => special_defense; set => special_defense = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Level { get => level; set => level = value; }
    public float Hp_max { get => hp_max; set => hp_max = value;}
    public float Score { get => score; set => score = value; }
    public int Iv { get => iv; set => iv = value;}

    public Pokemon() { } // necesario para dezerializar
    public Pokemon(int id, string name, int hp, int attack, int defense, int special_attack, int special_defense, int speed, int IV)
    {
        this.Level = 50;
        this.iv = IV;
        this.Id = id;
        this.Name = name.ToUpper();
        this.Hp = ((2 * hp + IV) * this.level / 100) + this.level + 10;
        this.hp_max = ((2 * hp + IV) * this.level / 100) + this.level + 10;
        this.Attack = ((2 * attack + IV) * this.level / 100) + 5;
        this.Defense = ((2 * defense + IV) * this.level / 100) + 5;
        this.Special_attack = ((2 * special_attack + IV) * this.level / 100) + 5;
        this.Special_defense = ((2 * special_defense + IV) * this.level / 100) + 5;
        this.Speed = ((2 * speed + IV) * this.level / 100) + 5;
        this.Score = 0;
    }

    public string Atributos()
    {
        return $"-{this.Name} -={this.Iv} IVs=- : \n\t Salud: {this.Hp} \n\t Ataque: {this.Attack} \n\t Defensa: {this.Defense} \n\t Ataque especial: {this.Special_attack} \n\t Defensa especial: {this.Special_defense} \n\t Velocidad: {this.Speed}";
    }

    public bool EstaVivo()
    {
        return this.Hp > 0;
    }

    private void morir()
    {
        this.Hp = 0;
        this.Score = 0;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{this.Name} fue vencido!");
        Console.ResetColor();
    }

    private float danio(Pokemon enemigo, float critic)
    {
        float res, ataque, defensa, modif;
        Random random = new Random();
        int power_move = random.Next(80, 121);
        ataque = (this.Attack + this.Special_attack) / 2;
        defensa = (enemigo.Defense + enemigo.Special_defense) / 2;
        modif = critic;
        res = ((((((2 * this.Level) / 5) + 2) * power_move * (ataque / defensa)) / 100) + 2) * modif; //en un principio se divide por 50, luego modifico a 100
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("== Ataque critico ==");
                    Console.ResetColor();
                }
                else
                {
                    critic = 1.5F;
                }
                float danio = this.danio(enemigo, critic);
                enemigo.Hp = (float)Math.Round((enemigo.Hp - danio), 2);
                Console.WriteLine();
                Console.WriteLine($"{this.Name} ha realizado {danio} puntos de daño a {enemigo.Name}");
                if (enemigo.EstaVivo())
                {
                    Console.WriteLine();
                    Console.WriteLine($"La vida de {enemigo.Name} es {enemigo.Hp}");
                }
                else
                {
                    enemigo.morir();
                    this.recompensa();
                    Console.WriteLine();
                    Console.WriteLine($"{this.Name} recupero salud, su nueva salud es {this.Hp} e incremento sus estadisticas");
                }
            }
        }

    }

    private void recompensa()
    {
        Random random = new Random();
        this.Score = this.Score + (float)Math.Round(((this.Hp_max - this.Hp) * 100 / this.Hp_max) + 100, 2);
        if ((float)Math.Round((float)this.Hp + this.Hp_max * 0.4f, 2) > this.Hp_max)
        {
            this.Hp = this.Hp_max;
        }
        else
        {
            this.Hp += (float)Math.Round((float)this.Hp_max * 0.4f, 2);
        }
        this.Attack += random.Next(0, 11);
        this.Defense += random.Next(0, 11);
        this.Special_attack += random.Next(0, 11);
        this.Special_defense += random.Next(0, 11);
        this.Speed += random.Next(0, 3);
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
        int longitud = aux.Name.Length;
        string tope = new string('-', longitud + 10);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{tope}");
        Console.WriteLine($"|| Gano {aux.Name} ||");
        Console.WriteLine($"{tope}");
        Console.ResetColor();
    }

    public void Combate(Pokemon enemigo)
    {
        do
        {

            Thread.Sleep(2000);
            Console.WriteLine("------------");
            this.turno(enemigo);
            Console.WriteLine("------------");
        } while (this.EstaVivo() && enemigo.EstaVivo());
        this.ganador(enemigo);
    }

    public float PuntajeFinal()
    {
        return this.score;
    }

}
