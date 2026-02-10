namespace Versenyzok;

class Program
{
    static void Main(string[] args)
    {
        // 1. & 2.
        List<Versenyzo> versenyzok = VersenyzoUtils.ListaFeltoltese("pilotak.csv");

        // 3.
        int letszam = versenyzok.Count();
        Console.WriteLine($"3. feladat: {letszam}");

        // 4.
        Versenyzo utolso = versenyzok[letszam - 1];
        Console.WriteLine($"4. feladat: {utolso.Nev}");

        // 5.
        List<Versenyzo> huszadikSzazadElott = VersenyzoUtils.HuszadikSzazadElott(versenyzok);
        Console.WriteLine($"5. feladat:");
        huszadikSzazadElott.ForEach(v => Console.WriteLine($"\t{v.Nev} ({v.SzuletesiDatum})"));

        // 6.
        string legalacsonyabbNemzetisege = VersenyzoUtils.LegalacsonyabbNemzetisege(versenyzok);
        Console.WriteLine($"6. feladat: {legalacsonyabbNemzetisege}");

        // 7.
        var kozosek = VersenyzoUtils.KozosRajtszamok(VersenyzoUtils.RajtszamokLista(versenyzok));
        Console.WriteLine(
            $"7. feladat: {String.Join(", ", kozosek.Select(k => k.ToString()))}"
        );
    }
}