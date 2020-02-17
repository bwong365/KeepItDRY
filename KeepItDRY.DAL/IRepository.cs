using System.Collections.Generic;

namespace KeepItDRY.DAL
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int Id);
        int Update(TEntity obj);
        void Delete(int Id);
        List<TEntity> GetListByAll();
    }
}
