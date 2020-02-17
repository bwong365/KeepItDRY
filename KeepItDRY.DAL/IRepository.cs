using System.Collections.Generic;

namespace KeepItDRY.DAL
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity Get(int Id);
        void Update(TEntity obj);
        void Delete(int Id);
        List<TEntity> GetListByAll();
    }
}
