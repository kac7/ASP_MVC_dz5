using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_dz5.Models
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Add(T item);
        bool Delete(int id);
    }
}
