// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day 3");

Star1();
Star2();

static void Star1()
{
    using var file = File.OpenText("input.txt");
    int[] numeros = new int[12];
    int total = 0;
    while(!file.EndOfStream)
    {
        var linea = file.ReadLine();
        if(linea is null) { continue; }
        int cont = 0;
        foreach(var c in linea)
        {
            if(c == '1') { numeros[cont]++; }
            cont++;
        }
        total++;
    }
    total /= 2;
    int gamma = 0, epsilon = 0;
    int p2 = 1;
    for(int i=11; i>=0; i--)
    {
        if(numeros[i] >total) { gamma += p2; }
        else { epsilon += p2; }
        p2 *= 2;
    }
    Console.WriteLine($"El resultado es {gamma} * {epsilon} = {gamma*epsilon}" );
}

static void Star2()
{
    using var file = File.OpenText("input.txt");
    var lista = new List<string>();
    while(!file.EndOfStream)
    {
        lista.Add(file.ReadLine() ?? string.Empty);
    }
    var longitud = lista[0].Length;
    var ox = new List<string>();
    ox.AddRange(lista);
    var co2 = new List<string>();
    co2.AddRange(lista);
    int empezar = 0;
    while (ox.Count != 1)
    {
        for (int i = empezar; i < longitud; i++)
        {
            var unos = ox.Count(x => x[i] == '1');
            var cero = ox.Count(x => x[i] == '0');
            if (unos >= cero)
            {
                ox = ox.Where(x => x[i] == '1').ToList();
            }
            else
            {
                ox = ox.Where(x => x[i] == '0').ToList();
            }
            if (ox.Count == 1) { break; }
            if (ox.Count == 0)
            {
                empezar++;
                ox.Clear();
                ox.AddRange(lista);
                break;
            }
        }
    }
    var oxigeno = Convert.ToInt32(ox[0], 2);
    
    empezar = 0;
    while (co2.Count != 1)
    {
        for (int i = empezar; i < longitud; i++)
        {
            var unos = co2.Count(x => x[i] == '1');
            var cero = co2.Count(x => x[i] == '0');
            if (cero <= unos)
            {
                co2 = co2.Where(x => x[i] == '0').ToList();
            }
            else
            {
                co2 = co2.Where(x => x[i] == '1').ToList();
            }
            
            if (co2.Count == 1) { break; }
            if (co2.Count == 0) 
            { 
                empezar++;
                co2.Clear();
                co2.AddRange(lista);
                break;
            }
        }
    }
    var co2gen = Convert.ToInt32(co2[0], 2);

    Console.WriteLine($"Resultado {oxigeno} * {co2gen} = {oxigeno * co2gen}");
}


