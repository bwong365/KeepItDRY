using System.Collections.Generic;

namespace KeepItDRY.DAL
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int Id);
        int Update(TEntity obj);
        void Delete(int Id);
        List<TEntity> GetListByAll();
        bool Exists(int Id);
    }
}
