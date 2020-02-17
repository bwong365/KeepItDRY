using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Services
{
    public interface IService<TEntity>
    {
        TEntity Get(int Id);
        int Update(TEntity obj);
        void Delete(int Id);
        List<TEntity> GetListByAll();
        bool Exists(int Id);
    }
}
