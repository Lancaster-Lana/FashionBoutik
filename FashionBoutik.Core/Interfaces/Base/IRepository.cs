
using System.Linq;
using System.Threading.Tasks;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{

    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll();

        Task<bool> Insert(T entity);
        //Task<bool> Update(T entity);

        Task<bool> Delete(T entity);
        bool Remove(T entity);
        Task SaveChanges();
    }

    public interface IRepository<T, TKey> //: IRepository<T>
        where T : BaseEntity<TKey>
    {
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetAllIncluding(params string[] exprs);
            
        Task<T> GetById(TKey id);
        /// <summary>
        /// If related tables needed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exprs"></param>
        /// <returns></returns>
        Task<T> GetByIdIncluding(TKey id, params string[] exprs);

        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);

        Task<bool> Delete(TKey id);
        Task SaveChanges();
    }
}
