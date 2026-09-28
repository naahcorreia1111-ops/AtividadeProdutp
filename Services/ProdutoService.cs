using Atividade.Interfaces;
using Atividade.Models;

namespace Atividade.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            if (produto.Preco <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");

            await _repository.AdicionarAsync(produto);
        }

        public async Task AtualizarAsync(int id, Produto produto)
        {
            var produtoExistente = await _repository.ObterPorIdAsync(id);
            if (produtoExistente == null)
                throw new KeyNotFoundException("Produto não encontrado.");

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Marca = produto.Marca;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoExistente.Ativo = produto.Ativo;

            await _repository.AtualizarAsync(produtoExistente);
        }

        public async Task DeletarAsync(int id)
        {
            var produto = await _repository.ObterPorIdAsync(id);
            if (produto == null)
                throw new KeyNotFoundException("Produto não encontrado.");

            await _repository.DeletarAsync(id);
        }
    }
}