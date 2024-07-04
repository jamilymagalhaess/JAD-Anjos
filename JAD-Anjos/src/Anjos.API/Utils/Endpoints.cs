using System.Diagnostics.CodeAnalysis;

namespace Anjos.API.Utils;

[ExcludeFromCodeCoverage]
public static class Endpoints
{
    public static class Recursos
    {
        public const string Produto = "api/produto";
        public const string Venda = "api/venda";
        public const string VendaProduto = "api/vendaproduto";
        public const string Categoria = "api/categoria";
        public const string Parcela = "api/parcela";
        public const string Entrada = "api/entrada";
        public const string EntradaProduto = "api/entradaproduto";
        public const string Conta = "api/conta";
        public const string ContaReceber = "api/contareceber";
    }

    public static class ProdutoApi
    {
        public const string ObterProduto = "obter-produto/{id:int}";
        public const string ObterPaginado = "obter-paginado";
        public const string CadastrarProduto = "cadastrar-produto";
        public const string AtualizarProduto = "atualizar-produto";
        public const string DeletarProduto = "deletar-produto/{id:int}";
    }

    public static class CategoriaApi
    {
        public const string ObterCategoria = "obter-categoria/{id:int}";
        public const string ObterPaginado = "obter-paginado";
        public const string CadastrarCategoria = "cadastrar-categoria";
        public const string AtualizarCategoria = "atualizar-categoria";
        public const string DeletarCategoria = "deletar-categoria/{id:int}";
    }

    public static class EntradaApi
    {
        public const string ObterEntrada = "obter-entrada/{id:int}";
        public const string ObterPaginado = "obter-paginado";
        public const string CadastrarEntrada = "cadastrar-entrada";
        public const string AtualizarEntrada = "atualizar-entrada";
        public const string DeletarEntrada = "deletar-entrada/{id:int}";
    }

    public static class ParcelaApi
    {
        public const string ObterParcela = "obter-parcela/{id:int}";
        public const string ObterPaginado = "obter-paginado";
        public const string CadastrarParcela = "cadastrar-parcela";
        public const string AtualizarParcela = "atualizar-parcela";
        public const string DeletarParcela = "deletar-parcela/{id:int}";
    }

    public static class VendaApi
    {
        public const string ObterVenda = "obter-venda/{id:int}";
        public const string ObterPaginado = "obter-paginado";
        public const string CadastrarVenda = "cadastrar-venda";
        public const string AtualizarVenda = "atualizar-venda";
        public const string DeletarVenda = "deletar-venda/{id:int}";
    }

    public static class ContaPagarApi
    {
        public const string ObterContaPagar = "obter-contapagar/{id:int}";
        public const string ObterPaginado = "obter-paginado";
        public const string CadastrarContaPagar = "cadastrar-contapagar";
        public const string AtualizarContaPagar = "atualizar-contapagar";
        public const string DeletarContaPagar = "deletar-contapagar/{id:int}";
    }

    public static class ContaReceberApi
    {
        public const string ObterContaReceber = "obter-contareceber/{id:int}";
        public const string ObterPaginado = "obter-paginado-contareceber";
        public const string CadastrarContaReceber = "cadastrar-contareceber";
        public const string AtualizarContaReceber = "atualizar-contareceber";
        public const string DeletarContaReceber = "deletar-contareceber/{id:int}";
    }

    public static class VendaProdutoApi
    {
        public const string ObterVendaProduto = "obter-vendaproduto/{id:int}";
        public const string ObterPorVenda = "obter-paginado";
        public const string AdicionarVendaProduto = "adicionar-vendaproduto";
        public const string AtualizarVendaProduto = "atualizar-vendaproduto";
        public const string DeletarVendaProduto = "deletar-vendaproduto/{id:int}";
    }

    public static class EntradaProdutoApi
    {
        public const string ObterEntradaProduto = "obter-entradaproduto/{id:int}";
        public const string ObterPorEntrada = "obter-paginado";
        public const string AdicionarEntradaProduto = "adicionar-entradaproduto";
        public const string AtualizarEntradaProduto = "atualizar-entradaproduto";
        public const string DeletarEntradaProduto = "deletar-entradaproduto/{id:int}";
    }
}
