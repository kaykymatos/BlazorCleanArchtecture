using BlazorCleanArchtecture.Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCleanArchtecture.Livraria.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ObterLivros();
        Task<Livro?> ObterLivro(int id);
        Task<Livro> AdicionarLivro(Livro livro);
        Task DeletarLivro(int id);
        Task AtualizarLivro(Livro livro);
    }
}
