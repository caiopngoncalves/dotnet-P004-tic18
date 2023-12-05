namespace Namespace;
public class PagamentoPix
{
    public string Descricao { get; set; }
    public double ValorBruto { get; set; }
    public double Desconto { get; set; }
    public DateTime DataHora { get; set; } 
    public void pagar()
    {
        System.Console.WriteLine("Você pagou com o pix");
    }
}
