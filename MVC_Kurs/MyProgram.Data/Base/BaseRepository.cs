using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgram.Data.Base
{
    public abstract class BaseRepository<T>  where T:class
    {
        public abstract void Insert(T Entity);
        public abstract List<T> GetAll();
        public abstract T GetById(int id);
    }
}
