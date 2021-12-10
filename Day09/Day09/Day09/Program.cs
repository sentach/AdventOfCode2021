// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day 09");

var filename = "input.txt";
//var filename = "test.txt";

Star1(filename);
Star2(filename);

void Star1(string filename)
{
    int[,] data = GetData(filename);
    
    var lowerpoints = GetLowerPoints(data);

    Console.WriteLine(lowerpoints.Sum(x => data[x.x, x.y] + 1));
}

void Star2(string filename)
{
    int[,] data = GetData(filename);
    var lowerPoints = GetLowerPoints(data);
    List<int> tamPath = new ();
    bool[,] recoridos = new bool[data.GetLength(0),data.GetLength(1)];
    foreach(var point in lowerPoints)
    {        
        var tam = GetTamPath(point, data, recoridos);
        Limpia(recoridos);
        tamPath.Add(tam);
    }
    var tres = tamPath.OrderByDescending(x => x).Take(3).ToArray();
    Console.WriteLine(tres[0]*tres[1]*tres[2]);
}

void Limpia(bool[,] recoridos)
{
    recoridos = new bool[recoridos.GetLength(0), recoridos.GetLength(1)];
}

int GetTamPath(Point point, int[,] data, bool[,] recorridos)
{
    //if (point.x<0) { return 0; }
    //if(point.y<0) { return 0;}
    //if(point.x>data.GetLength(0)-1) { return 0; } 
    //if(point.y>data.GetLength(1)-1) { return 0; }
    recorridos[point.x, point.y] = true;
    var maxx = data.GetLength(0) - 1;
    var maxy = data.GetLength(1) - 1;
    if (data[point.x, point.y] == 9) { return 0; }

    var p = new Point { x = point.x, y = point.y };
    p.x--;
    var arriba = p.x>=0 && !recorridos[p.x,p.y] ? GetTamPath(p, data, recorridos) : 0;
    p.x++;
    p.x++;
    var abajo = p.x<=maxx && !recorridos[p.x, p.y] ? GetTamPath(p, data, recorridos) : 0;
    p.x--; p.y--;
    var izquierda = p.y>=0 && !recorridos[p.x, p.y] ? GetTamPath(p, data, recorridos) : 0;
    p.y++;p.y++;
    var derecha = p.y<=maxy && !recorridos[p.x, p.y] ? GetTamPath(p, data, recorridos) : 0;
    return 1 + arriba + abajo + izquierda + derecha;
}

List<Point> GetLowerPoints(int [,] data)
{
    var lowerpoints = new List<Point>();
    var maxx = data.GetLength(0);
    var maxy = data.GetLength(1);
    for (int i = 0; i < maxx; i++)
    {
        for (int j = 0; j < maxy; j++)
        {
            if (i > 0)
            {
                if (data[i, j] >= data[i - 1, j]) { continue; }
            }
            if (j > 0)
            {
                if (data[i, j] >= data[i, j - 1]) { continue; }
            }
            if (i < maxx - 1)
            {
                if (data[i, j] >= data[i + 1, j]) { continue; }
            }
            if (j < maxy - 1)
            {
                if (data[i, j] >= data[i, j + 1]) { continue; }
            }
            lowerpoints.Add(new Point { x = i, y = j });
        }
    }
    return lowerpoints;
}

int [,] GetData(string filename)
{
    using var file = File.OpenText(filename);
    var lista = new List<string>();
    while(!file.EndOfStream)
    {
        lista.Add(file.ReadLine() ?? string.Empty);
    }

    var x = lista.Count;
    var y = lista[0].Length;
    int[,] result = new int[x, y];
    int i = 0;
    foreach(var l in lista)
    {
        int j = 0;
        foreach(char c in l)
        {
            result[i,j]=Convert.ToInt32(c.ToString());
            j++;
        }
        i++;
    }

    return result;
}

class Point
{
    public int x;
    public int y;

    public override string ToString() { return $"({x},{y})"; }

    public override bool Equals(object? p)
    {
        if(p is null) { return false; }
        if(p is not Point) { return false; }
        var p1 = p as Point;
        if(p1 is null) { return false; }
        return p1.x==x && p1.y==y; 
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public static bool operator ==(Point p1, Point p2)
    {
        return p1.x==p2.x && p1.y==p2.y;
    }
    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1.x == p2.x && p1.y == p2.y);
    }
}