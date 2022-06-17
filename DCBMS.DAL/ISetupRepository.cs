using DCBMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.DAL
{
    public interface ISetupRepository
    {
        void Add(TestSetup testSetup);
        DataTable getAll();
    }
}
