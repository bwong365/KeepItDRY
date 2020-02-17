using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Services
{
    public interface IService<T>
    {
        T Find(int id);
        T FindAll();
    }
}
