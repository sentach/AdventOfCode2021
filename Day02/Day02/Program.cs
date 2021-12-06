// See https://aka.ms/new-console-template for more information
Star1();
Star2();

void Star1()
{
    using var file = File.OpenText("input.txt");
    var forward = 0;
    var deep = 0;
    while(!file.EndOfStream)
    {
        var linea = file.ReadLine();
        if (linea == null) break;
        if (linea.StartsWith("forward"))
        {
            forward += Convert.ToInt32(linea[8..]);
        }
        if(linea.StartsWith("up"))
        {
            deep -= Convert.ToInt32(linea[3..]);
        }
        if(linea.StartsWith("down"))
        {
            deep+=Convert.ToInt32(linea[5..]);
        }
    }
    Console.WriteLine($"Star 1 ->forward {forward} deep {deep} resultado {forward*deep}");
}

void Star2()
{
    using var file = File.OpenText("input.txt");
    long forward = 0;
    long deep = 0;
    var aim = 0;
    while (!file.EndOfStream)
    {
        var linea = file.ReadLine();
        if (linea == null) break;
        if (linea.StartsWith("forward"))
        {
            var avance = Convert.ToInt32(linea[8..]);
            forward += avance;
            deep += avance * aim;
            continue;
        }
        if (linea.StartsWith("up"))
        {
            aim -= Convert.ToInt32(linea[3..]);
            continue;
        }
        if (linea.StartsWith("down"))
        {
            aim += Convert.ToInt32(linea[5..]);
        }
    }
    long resultado = forward * deep;
    Console.WriteLine($"Star 2 ->forward {forward} deep {deep} resultado {resultado}");
}