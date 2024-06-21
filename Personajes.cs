public class Personaje
{
    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fecha_nacimiento;
    private int edad;

    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private float salud;

    public Personaje(string tipo, string nombre, string apodo, DateTime fecha_nacimiento, int edad, int velocidad, int destreza, int fuerza, int armadura)
    {
        this.tipo = tipo;
        this.nombre = nombre;
        this.apodo = apodo;
        this.fecha_nacimiento = fecha_nacimiento;
        this.edad = edad;
        this.velocidad = velocidad;
        this.destreza = destreza;
        this.fuerza = fuerza;
        this.nivel = 1;
        this.armadura = armadura;
        this.salud = 100;
    }

    public string Atributos()
    {
        return $"{this.nombre}: \n Velocidad: {this.velocidad} \n Destreza: {this.destreza} \n Fuerza: {this.fuerza} \n Nivel: {this.nivel} \n Armadura: {this.armadura} \n Salud: {this.salud}";
    }

    private bool estaVivo()
    {
        return this.salud > 0;
    }

    private void morir()
    {
        this.salud = 0;
        Console.WriteLine($"{this.nombre} ha muerto!");
    }

    private float danio(Personaje enemigo)
    {
        int ataque, efectividad, defensa, cte;
        cte = 50;
        float res;
        Random random = new Random();
        ataque = this.destreza * this.fuerza * this.nivel;
        efectividad = random.Next(0, 101);
        defensa = enemigo.armadura * enemigo.velocidad;
        res = (float)((ataque * efectividad) - defensa) / cte;
        return (float)Math.Round(res, 2);
    }

    public void Atacar(Personaje enemigo)
    {
        if (this.estaVivo())
        {
            float danio = this.danio(enemigo);
            enemigo.salud = (float)Math.Round((enemigo.salud - danio), 2);
            Console.WriteLine($"{this.nombre} ha realizado {danio} puntos de daño a {enemigo.nombre}");
            if (enemigo.estaVivo())
            {
                Console.WriteLine($"La vida de {enemigo.nombre} es {enemigo.salud}");
            }
            else
            {
                enemigo.morir();
            }
        }else{
            
        }

    }

}

// public string Tipo { get => tipo; set => tipo = value; }
// public string Nombre { get => nombre; set => nombre = value; }
// public string Apodo { get => apodo; set => apodo = value; }
// public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
// public int Edad { get => edad; set => edad = value; }
// public int Velocidad { get => velocidad; set => velocidad = value; }
// public int Destreza { get => destreza; set => destreza = value; }
// public int Fuerza { get => fuerza; set => fuerza = value; }
// public int Nivel { get => nivel; set => nivel = value; }
// public int Armadura { get => armadura; set => armadura = value; }
// public int Salud { get => salud; set => salud = value; }