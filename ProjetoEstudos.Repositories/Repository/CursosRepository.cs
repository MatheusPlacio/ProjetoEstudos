using ProjetoEstudos.Data.Contexto;
using ProjetoEstudos.Domain.Models;
using ProjetoEstudos.Repositories.Base;
using ProjetoEstudos.Repositories.Interface;

namespace ProjetoEstudos.Repositories.Repository
{
    public class CursosRepository : BaseRepository<Cursos>, ICursosRepository
    {
        public CursosRepository(DataContext context) : base(context)
        {

        }
    }
}
