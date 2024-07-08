using System.Diagnostics.CodeAnalysis;

namespace Anjos.API.Utils;

[ExcludeFromCodeCoverage]
public static class Endpoints
{
    public static class Recursos
    {
        public const string Produto = "api/produtos";
        public const string Venda = "api/vendas";
        public const string VendaProduto = "api/vendas-produtos";
        public const string Categoria = "api/categorias";
        public const string Parcela = "api/parcelas";
        public const string Entrada = "api/entradas";
        public const string EntradaProduto = "api/entradas-produtos";
        public const string Conta = "api/contas";
        public const string ContaReceber = "api/contas-receber";
    }

    public static class Api
    {
        public const string Id= "{id:int}";
        public const string V1 = "";
    }
}
