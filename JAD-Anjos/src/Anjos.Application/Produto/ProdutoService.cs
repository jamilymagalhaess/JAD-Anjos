using Anjos.Database.Repositories.Produto;
using Anjos.Application.Interfaces;
using Anjos.Domain.Entities;
using System.Threading.Tasks;

namespace Anjos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto?> ObterByIdAsync(int id)
        {
            return await _produtoRepository.ObterByIdAsync(id);
        }
    }
}
