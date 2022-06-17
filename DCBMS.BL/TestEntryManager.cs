using DCBMS.DAL;
using DCBMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.BL
{
   public class TestEntryManager
    {
        TestRequestEntryRepository entryRepository = new TestRequestEntryRepository();
        public DataTable getFeeByTestId(int id)
        {
            DataTable dt = new DataTable();
            if (id>0)
            {
                dt=entryRepository.findFeeByeId(id);
                
            }

            return dt;
        }
        public  List<TestRequestEntry> Add(List<TestRequestEntry> testRequestEntry)
        {
            //List<TestRequestEntry> testRequestEntries = new List<TestRequestEntry>();
            
            entryRepository.add(testRequestEntry);
            return testRequestEntry;
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable( );
            return dt;
        }

        public DataTable getTestinfo(string selectedValue)
        {
            int testId = Int32.Parse(selectedValue);

            DataTable dt = new DataTable();
            dt = entryRepository.getTestinfo(testId);
            return dt;
        }
    }
}
