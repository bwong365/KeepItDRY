using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Services
{
    public class Service<T> : IService<T>
    {
        public T Find(int id) => throw new NotImplementedException();
        public T FindAll() => throw new NotImplementedException();
    }
}
