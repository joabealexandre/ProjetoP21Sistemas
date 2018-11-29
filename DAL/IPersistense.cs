using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPersistense<T>
    {
        void Save(T entity);
        List<T> GetAll();
        T GetByNome(string s);
    }
}
