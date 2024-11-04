using CA24110402;
using System.Text;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyzok szama: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "elit junior");
Console.WriteLine($"elit junior versenyzok szama: {f1} fo");

var f2 = versenyzok
    .Where(v => v.Nem)
    .Average(v => 2014 - v.Szul);
Console.WriteLine($"ferfiak atlegeletkora: {f2:0.00} ev");

var f3 = versenyzok.Sum(v => v.VersenyIdok["futás"].TotalHours);
Console.WriteLine($"futassal toltott osszido: {f3:0.00} ora");

var f4 = versenyzok
    .Where(v => v.Kategoria == "20-24")
    .Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"20-24 k.ban az atlagos uszas ido: {f4:0.00} perc");

var f5 = versenyzok
    .Where(v => !v.Nem)
    .MinBy(v => v.OsszIdo);
Console.WriteLine($"noi gyoztes: {f5}");

var f6 = versenyzok.GroupBy(v => v.Nem);
Console.WriteLine("a versenyt befejezok nemek szerint:");
foreach (var grp in f6)
    Console.WriteLine($"\t{(grp.Key ? "ferfi" : "no"),5}: {grp.Count()} fo");

var f7 = versenyzok
    .GroupBy(v => v.Kategoria)
    .OrderBy(g => g.Key)
    .ToDictionary(
    g => g.Key,
    g => g.Average(v => v.VersenyIdok["I. depó"].TotalMinutes + v.VersenyIdok["II. depó"].TotalMinutes));
Console.WriteLine("kategoriankent atlag depoban toltott ido");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");
}