// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day 06");
//var filename = "test.txt";
var filename = "input.txt";

Star1(filename);
Star2(filename);

void Star1(string filename)
{
    var peces = ObtenerPeces(filename);

    for (int i = 1; i <= 80; i++)
    {
        var total = peces.Count;
        
        for (int j = 0; j < total; j++)
        {
            if (peces[j] == 0)
            {
                peces[j] = 6;
                peces.Add(8);
            }
            else
            {
                peces[j]--;
            }
        }
        

    }
    Console.WriteLine(peces.Count);
}

void Star2(string filename)
{
    var peces = ObtenerPeces(filename);
    long []nacen  = new long[9];
    for(int i=1;i<6;i++)
    {
        nacen[i] = peces.Count(x => x == i);
    }
    pinta(nacen, 0);
    long anterior = 0;
    for (int i = 1; i<=256;i++)
    {
        anterior = nacen[0];
        for(int j=1;j<9;j++)
        {
            nacen[j - 1] = nacen[j];
        }        
        nacen[6] += anterior;
        nacen[8] = anterior;
        pinta(nacen, i);
    }
    Console.WriteLine(nacen.Sum());
}

List<int> ObtenerPeces(string filename)
{
    using var file = File.OpenText(filename);

    return file.ReadToEnd().Split(',').Select(x => Convert.ToInt32(x)).ToList();
}

void pinta(long []nacen, int i)
{    
    long total = nacen.Sum();
    Console.WriteLine($"Dia {i} {string.Join(",", nacen)} Total:{total}");
}