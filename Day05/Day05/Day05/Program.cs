using System.Text.RegularExpressions;

Console.WriteLine("Day5");
//var file = "test.txt";
var file = "input.txt";
Star1(file);
Star2(file);

void Star1(string fileName)
{
    var regex = new Regex("(\\d+),(\\d+) -> (\\d+),(\\d+)");

    var tablero = new int[1000, 1000];
    var file = File.OpenText(fileName);
    while (!file.EndOfStream)
    {
        var linea = file.ReadLine();
        if (linea == null) { continue; }
        var match = regex.Match(linea);
        var x1 = Convert.ToInt32(match.Groups[1].Value);
        var y1 = Convert.ToInt32(match.Groups[2].Value);
        var x2 = Convert.ToInt32(match.Groups[3].Value);
        var y2 = Convert.ToInt32(match.Groups[4].Value);
        if (x1 != x2 && y1 != y2)
        {
            continue;
        }
        if (x1 == x2)
        {
            var max = Math.Max(y1, y2);
            var min = Math.Min(y1, y2);
            for (int i = min; i <= max; i++)
            {
                tablero[i, x1]++;
            }
        }
        if (y1 == y2)
        {
            var max = Math.Max(x1, x2);
            var min = Math.Min(x1, x2);
            for (int i = min; i <= max; i++)
            {
                tablero[y1, i]++;
            }
        }
    }
    int suma = 0;
    for (int i = 0; i < 1000; i++)
    {
        for (int j = 0; j < 1000; j++)
        {
            if (tablero[i, j] > 1)
            {
                suma++;
            }
            if (j < 11 && i < 11)
            {
                var pinta = tablero[i, j] != 0 ? tablero[i, j].ToString() : ".";
                Console.Write(pinta);
            }
        }
        if (i < 11) { Console.WriteLine(); }
    }
    Console.WriteLine(suma);
}

void Star2(string fileName)
{
    var regex = new Regex("(\\d+),(\\d+) -> (\\d+),(\\d+)");

    var tablero = new int[1000, 1000];
    var file = File.OpenText(fileName);
    while (!file.EndOfStream)
    {
        var linea = file.ReadLine();
        if (linea == null) { continue; }
        var match = regex.Match(linea);
        var x1 = Convert.ToInt32(match.Groups[1].Value);
        var y1 = Convert.ToInt32(match.Groups[2].Value);
        var x2 = Convert.ToInt32(match.Groups[3].Value);
        var y2 = Convert.ToInt32(match.Groups[4].Value);
        if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
        {
            var x = x1;
            var y = y1;
            while (x != x2 && y != y2)
            {
                tablero[y, x]++;
                x += x1 < x2 ? 1 : -1;
                y += y1 < y2 ? 1 : -1;
            }
            tablero[y, x]++;
        }
        if (x1 == x2)
        {
            var max = Math.Max(y1, y2);
            var min = Math.Min(y1, y2);
            for (int i = min; i <= max; i++)
            {
                tablero[i, x1]++;
            }
        }
        if (y1 == y2)
        {
            var max = Math.Max(x1, x2);
            var min = Math.Min(x1, x2);
            for (int i = min; i <= max; i++)
            {
                tablero[y1, i]++;
            }
        }
    }
    int suma = 0;
    for (int i = 0; i < 1000; i++)
    {
        for (int j = 0; j < 1000; j++)
        {
            if (tablero[i, j] > 1)
            {
                suma++;
            }
            if (j < 10 && i < 10)
            {
                var pinta = tablero[i, j] != 0 ? tablero[i, j].ToString() : ".";
                Console.Write(pinta);
            }
        }
        if (i < 10) Console.WriteLine();
    }
    Console.WriteLine(suma);
}