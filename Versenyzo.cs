namespace CA24110402;

internal class Versenyzo
{
    public string Nev { get; set; }
    public int Szul { get; set; }
    public string RSzam { get; set; }
    public bool Nem { get; set; }
    public string Kategoria { get; set; }
    public Dictionary<string, TimeSpan> VersenyIdok { get; set; }

    public override string ToString() => 
        $"[{RSzam}] {Nev} ({Kategoria})";

    public int OsszIdo =>
        (int)VersenyIdok.Values.Sum(x => x.TotalSeconds);

    public Versenyzo(string sor)
    {
        string[] v = sor.Split(';');
        Nev = v[0];
        Szul = int.Parse(v[1]);
        RSzam = v[2];
        Nem = v[3] == "f";
        Kategoria = v[4];

        VersenyIdok = new()
        {
            {"úszás",        TimeSpan.Parse(v[5])},
            {"I. depó",      TimeSpan.Parse(v[6])},
            {"kerékpározás", TimeSpan.Parse(v[7])},
            {"II. depó",     TimeSpan.Parse(v[8])},
            {"futás",        TimeSpan.Parse(v[9])},
        };
    }
}
