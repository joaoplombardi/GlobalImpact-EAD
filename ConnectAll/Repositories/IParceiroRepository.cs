using GlobalImpact.Models;
using System.Collections;
using System.Collections.Generic;

namespace ConnectAll.Repositories
{
    public interface IParceiroRepository
    {
        void Cadastrar(Parceiro parceiro);
        IList<Parceiro> Listar();
        void Salvar();

    }
}
