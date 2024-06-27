using System.Diagnostics.CodeAnalysis;

namespace Anjos.API.Utils;

[ExcludeFromCodeCoverage]
public static class Endpoints
{
    public static class Recursos
    {
        public const string Produto = "api/processo";
        public const string Venda = "api/certidao";
        public const string Categoria = "api/processo";
        public const string Parcela = "api/certidao";
        public const string Entrada = "api/processo";
        public const string Conta = "api/certidao";
    }

    public static class Produto
    {
        public const string ObterProduto = "obter-produto/{id:int}";
        public const string ObterPaginado = "Obter-paginado";

    }
}
