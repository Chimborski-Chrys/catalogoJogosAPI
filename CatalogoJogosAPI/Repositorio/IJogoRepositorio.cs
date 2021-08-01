using CatalogoJogosAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogosAPI.Repositorio
{
    public interface IJogoRepositorio : IDisposable
    {
        Task<List<Jogo>> Obter(int pagina, int quantidade);
        Task<Jogo> Obter(Guid id);
        Task<List<Jogo>> Obter(string nome, string produtora);

        Task InserirJogo(Jogo jogo);
        Task AtualizarJogo(Jogo jogo);
        Task Deletar(Guid id);
        void Dispose();
    }
}
