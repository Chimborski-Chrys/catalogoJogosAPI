using CatalogoJogosAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogosAPI.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> InserirJogo(JogoInputModel jogo);
        Task AtualizarJogo(Guid id, JogoInputModel jogo);
        Task AtualizarPrecoJogo(Guid id, double preco);
        Task Deletar(Guid id);
    }
}
