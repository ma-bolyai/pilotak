namespace Versenyzok;

internal class VersenyzoUtils
{
    public static List<Versenyzo> ListaFeltoltese(string filenev)
    {
        StreamReader sr = new(filenev);
        List<Versenyzo> versenyzok = new();

        while (!sr.EndOfStream)
        {
            string sor = sr.ReadLine();
            if (String.IsNullOrWhiteSpace(sor) || sor == sor.ToLower())
            {
                continue;
            }
            string[] sorSplit = sor.Split(';');

            Versenyzo v = new()
            {
                Nev = sorSplit[0],
                SzuletesiDatum = sorSplit[1],
                Nemzetiseg = sorSplit[2],
            };

            if (!String.IsNullOrEmpty(sorSplit[3]))
            {
                v.Rajtszam = int.Parse(sorSplit[3]);
            }
            versenyzok.Add(v);
        }
        sr.Close();

        return versenyzok;
    }

    public static List<Versenyzo> HuszadikSzazadElott(List<Versenyzo> lista)
    {
        int limit = 1901;
        var huszadikSzazadElott = lista 
            .Where(v => int.Parse(v.SzuletesiDatum.Split('.')[0]) < limit)
            .ToList();

        return huszadikSzazadElott;
    }

    public static List<int?> RajtszamokLista(List<Versenyzo> lista)
    {
        var rajtszamok = lista 
            .Where(v => v.Rajtszam is not null)
            .Select(v => v.Rajtszam)
            .ToList();

        return rajtszamok;
    }

    public static string LegalacsonyabbNemzetisege(List<Versenyzo> lista)
    {
        var rajtszamok = RajtszamokLista(lista);
        var legalacsonyabb = lista 
            .Where(v => v.Rajtszam is not null)
            .OrderBy(v => v.Rajtszam)
            .First();

        return legalacsonyabb.Nemzetiseg;
    }

    public static List<int?> KozosRajtszamok(List<int?> lista)
    {
        var kozosek = lista
            .GroupBy(r => r)
            .Where(r => r.Count() > 1)
            .Select(r => r.Key)
            .ToList();

        return kozosek;
    }
}