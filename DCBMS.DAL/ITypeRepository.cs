using DCBMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.DAL
{
   public interface ITypeRepository
    {
        void Add(TestType testType);
        DataTable getAll();
    }
}
