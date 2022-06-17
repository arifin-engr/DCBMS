using DCBMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.DAL
{
    public interface ITestRequestEntryRepository
    {
        DataTable findFeeByeId(int id);
        void add(List<TestRequestEntry> testRequestEntry);
    }
}
