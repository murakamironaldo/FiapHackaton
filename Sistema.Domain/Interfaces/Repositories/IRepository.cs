using System.Linq.Expressions;

namespace Sistema.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T? CarregarPorId(Guid id);
        T? Carregar(Expression<Func<T, bool>> predicate);
        void Inserir(T entity);
        void Alterar(T entity);
        void Excluir(Guid id);
        IEnumerable<T> ListarTodos();
        IEnumerable<T> ListarWhere(Expression<Func<T, bool>> predicate);
        int QuantidadeRegistros();
        int QuantidadeRegistrosWhre(Expression<Func<T, bool>> predicate);
        ICollection<T> Get(params Expression<Func<T, object>>[] includes);

    }
}
