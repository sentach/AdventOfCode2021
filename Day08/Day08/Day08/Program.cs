// See https://aka.ms/new-console-template for more information

Console.WriteLine("Day 8");

//var filename = "test.txt";
var filename = "input.txt";

Star1(filename);
Star2(filename);

void Star1(string filename)
{
    using var file = File.OpenText(filename);
    var lista = new List<string>();
    while (!file.EndOfStream)
    {
        var linea = file.ReadLine();
        if (linea is null) { continue; }
        lista.AddRange(linea.Split('|')[1].Trim().Split(' '));
    }
    Console.WriteLine(lista.Sum(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7 ? 1 : 0));
}

void Star2(string filename)
{
    using var file = File.OpenText(filename);
    int suma = 0;

    while (!file.EndOfStream)
    {
        var linea = file.ReadLine();
        if (linea is null) { continue; }
        suma += ProcesaLinea(linea);
    }
    Console.WriteLine(suma);
}

int ProcesaLinea(string linea)
{
    var datos = linea.Split('|');
    var entrada = Normaliza(datos[0].Trim());
    var digitos = new Dictionary<string, int>();
    var uno = entrada.First(x => x.Length == 2);
    digitos.Add(uno, 1);
    digitos.Add(entrada.First(x => x.Length == 3), 7);
    digitos.Add(entrada.First(y => y.Length == 4), 4);
    digitos.Add(entrada.First(z => z.Length == 7), 8);
    var c = ' ';
    var seis = string.Empty;
    var cinco = string.Empty;
    foreach (var d in entrada.Where(x => x.Length == 6))
    {
        var salir = false;
        foreach (var unod in uno)
        {
            if (!d.Contains(unod))
            {
                digitos.Add(d, 6);
                seis = d;
                c = unod;
                salir = true;
                break;
            }
        }
        if (salir) { break; }
    }
    var f = uno.First(x => x != c);
    foreach (var d in entrada.Where(x => x.Length == 5))
    {
        if (!d.Contains(c))
        {
            cinco = d;
            digitos.Add(cinco, 5);
            var nueve = NormalizaLetra(d + c);
            digitos.Add(nueve, 9);
            digitos.Add(entrada.First(x => x.Length == 6 && x != nueve && x != seis), 0);
            break;
        }
    }
    foreach (var d in entrada.Where(x => x.Length == 5 && x != cinco))
    {
        if (d.Contains(f))
        {
            digitos.Add(d, 3);
        }
        else
        {
            digitos.Add(d, 2);
        }
    }

    var valores = Normaliza(datos[1].Trim());
    int resultado = 0;
    foreach (var val in valores)
    {
        resultado = (resultado * 10) + digitos[val];
    }

    return resultado;
}

List<string> Normaliza(string v)
{
    var result = new List<string>();
    var temp = v.Split(' ');
    foreach (var dato in temp)
    {
        result.Add(NormalizaLetra(dato));
    }
    return result;
}

string NormalizaLetra(string dato)
{
    List<char> t = dato.ToList().OrderBy(x => x).ToList();
    return string.Join(string.Empty, t);
}