// See https://aka.ms/new-console-template for more information
Console.WriteLine("Dia 4");

Star1();
Star2();

void Star1()
{
    var tableros = CargarDatos(out string[] numeros);

    foreach (var num in numeros)
    {
        foreach (var tab in tableros)
        {
            if (tab.Comprobar(num))
            {
                Console.WriteLine(Convert.ToInt32(num) * tab.Suma());
                return;
            }
        }
    }

}

void Star2()
{
    var tableros = CargarDatos(out string[] numeros);
    var total = tableros.Count;
   
    foreach (var num in numeros)
    {
        foreach (var tab in tableros)
        {
            if (tab.Finalizado) { continue; }
            if (tab.Comprobar(num))
            {
                total--;
                if (total == 0)
                {
                    Console.WriteLine(Convert.ToInt32(num) * tab.Suma());
                    return;
                }
            }
        }
    }
}

List<Tablero> CargarDatos(out string[] numeros)
{
    using var file = File.OpenText("input.txt");

    numeros = file.ReadLine().Split(',');
    file.ReadLine();
    var tableros = new List<Tablero>();
    var tablero = new Tablero();
    var fila = 0;
    while (!file.EndOfStream)
    {
        var line = file.ReadLine();
        if (line is null) { continue; }
        if (line.Length == 0)
        {
            tableros.Add(tablero);
            tablero = new Tablero();
            fila = 0;
            continue;
        }
        var elementos = line.Split(' ').Where(x => x != string.Empty).ToArray();
        for (int i = 0; i < 5; i++)
        {
            tablero.Elemento[fila, i] = new Elemento(elementos[i]);
        }
        fila++;
    }
    tableros.Add(tablero);
    return tableros;
}

class Tablero
{
    public Elemento[,] Elemento { get; set; }
    public bool Finalizado { get; set; }

    public Tablero()
    {
        Elemento = new Elemento[5, 5];
    }

    public int Suma()
    {
        int sum = 0;
        foreach (var el in Elemento)
        {
            if (!el.Encontrado)
            {
                sum += Convert.ToInt32(el.Number);
            }
        }
        return sum;
    }

    public bool Comprobar(string number)
    {
        foreach (var elemento in Elemento)
        {
            if (elemento.Number == number)
            {
                elemento.Encontrado = true;
                break;
            }
        }
        return EsGanador();
    }

    private bool EsGanador()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Elemento[i, 0].Encontrado && Elemento[i, 1].Encontrado && Elemento[i, 2].Encontrado && Elemento[i, 3].Encontrado && Elemento[i, 4].Encontrado)
            {
                Finalizado = true;
                return true;
            }
            if (Elemento[0, i].Encontrado && Elemento[1, i].Encontrado && Elemento[2, i].Encontrado && Elemento[3, i].Encontrado && Elemento[4, i].Encontrado)
            {
                Finalizado = true;
                return true;
            }
        }
        return false;
    }
}
class Elemento
{
    public string Number { get; set; }
    public bool Encontrado { get; set; }
    public Elemento(string number)
    {
        Number = number;
        Encontrado = false;
    }
    public override string ToString()
    {
        return Number;
    }
}