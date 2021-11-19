using GlobalImpact.Models;
using System.Collections.Generic;

namespace ConnectAll.Repositories
{
    public interface IPontoDeDistribuicaoRepository
    {
        void Cadastrar(PontoDeDistribuicao pdd);
        IList<PontoDeDistribuicao> Listar();
        void Salvar();
    }
}
