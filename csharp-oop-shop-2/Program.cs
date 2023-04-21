public class Prodotto
{
    public string Nome { get; set; }
    public string Codice { get; set; }
    public double Prezzo { get; set; }
    public int Quantita { get; set; }

    public Prodotto(string nome, string codice, double prezzo, int quantita)
    {
        Nome = nome;
        Codice = codice;
        Prezzo = prezzo;
        Quantita = quantita;
    }

    public virtual void StampaProdotto()
    {
        Console.WriteLine($"{Codice} - {Nome}");
    }
}

public class Acqua : Prodotto
{
    private double _litri;
    private readonly double _maxLitri = 1.5;
    private readonly double _ph;
    private readonly string _sorgente;

    public Acqua(string nome, string codice, double prezzo, int quantita, double litri, double ph, string sorgente)
        : base(nome, codice, prezzo, quantita)
    {
        _litri = litri;
        _ph = ph;
        _sorgente = sorgente;
    }

    public void Bevi(double litriDaBere)
    {
        if (_litri >= litriDaBere)
        {
            _litri -= litriDaBere;
        }
        else
        {
            _litri = 0;
        }
    }

    public void Riempi(double litri)
    {
        if (_litri + litri <= _maxLitri)
        {
            _litri += litri;
        }
        else
        {
            _litri = _maxLitri;
        }
    }

    public void Svuota()
    {
        _litri = 0;
    }

    public override void StampaProdotto()
    {
        Console.WriteLine($"{Codice} - {Nome} ({_sorgente}, PH: {_ph}, {_litri}L)");
    }
}

public class SacchettoFrutta : Prodotto
{
    private readonly List<string> _frutta = new List<string>();
    private readonly int _maxPezzi = 5;

    public SacchettoFrutta(string nome, string codice, double prezzo, int quantita, List<string> frutta)
        : base(nome, codice, prezzo, quantita)
    {
        if (frutta.Count > _maxPezzi)
        {
            _frutta = frutta.Take(_maxPezzi).ToList();
        }
        else
        {
            _frutta = frutta;
        }
    }

    public override void StampaProdotto()
    {
        Console.WriteLine($"{Codice} - {Nome} ({string.Join(", ", _frutta)})");
    }
}