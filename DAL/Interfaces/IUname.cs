using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUname<CLASS, ID, RET>
    {
        List<CLASS> Get();
        CLASS Get(ID id);
        CLASS Get(string uname);
        RET Create(CLASS obj);
        RET Update(CLASS obj);
        bool Delete(ID id);
    }
}
