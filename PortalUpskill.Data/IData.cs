using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data
{
    /// <summary>
    /// Interface base para todos os repositórios
    /// </summary>
    public interface IData<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(int id);
    }
}
