namespace Anjos.Model.Produto;

public class ProdutoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public bool ExibeNoSite { get; set; }
    public int CategoriaId { get; set; }

}