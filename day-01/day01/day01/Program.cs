// See https://aka.ms/new-console-template for more information
star1();
star2();

void star2()
{
    using var file = File.OpenText("input.txt");
    var elements = new List<int>();
    while (!file.EndOfStream)
    {
        elements.Add(Convert.ToInt32(file.ReadLine()));
    }
    var inc = 0;
    var anterior = elements[0] + elements[1] + elements[2];
    int current = 0;
    for(int i = 3; i<elements.Count; i++)
    {
        current = elements[i] + elements[i-1] + elements[i-2];
        if(current>anterior) inc++;
        anterior = current;
    }
    Console.WriteLine(inc);
}

void star1()
{
    using var file = File.OpenText("input.txt");

    var anterior = Convert.ToInt32(file.ReadLine());
    int inc = 0;
    while (!file.EndOfStream)
    {
        var current = Convert.ToInt32(file.ReadLine());
        if (current > anterior) inc++;
        anterior = current;
    }
    Console.WriteLine(inc);

}