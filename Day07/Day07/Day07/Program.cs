// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day 7");

//var filename = "test.txt";
var filename = "input.txt";

Star1(filename);
Star2(filename);

void Star1(string filename)
{
    var lista = ReadFile(filename);
    var minimo = int.MaxValue;
    for(int i= lista.Min(); i<=lista.Max(); i++)
    {
        var iter = lista.Sum(x => Math.Abs(x - i));
        if(iter< minimo)
        {
            minimo = iter;
        }
    }
    Console.WriteLine(minimo);
}

void Star2(string filename)
{
    var lista = ReadFile(filename);
    var minimo = int.MaxValue;
    for(int i=lista.Min(); i<=lista.Max(); i++)
    {
        var iter = lista.Sum(x =>
        {
            var n = Math.Abs(x - i);
            return n * (n + 1) / 2; 
        });
        if(iter< minimo)
        {
            minimo = iter;
        }
    }
    Console.WriteLine(minimo);
}

List<int> ReadFile(string filename)
{
    using var file = File.OpenText(filename);
    var linea = file.ReadToEnd();
    return linea.Split(',').Select(x => Convert.ToInt32(x)).ToList();
}