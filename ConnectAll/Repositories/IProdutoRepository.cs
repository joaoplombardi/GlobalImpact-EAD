using GlobalImpact.Models;
using System.Collections.Generic;

namespace ConnectAll.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(int id);
        IList<Produto> Listar();
        Produto BuscarPorId(int id);
        void Salvar();
    }
}
