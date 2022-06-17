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
   public class TestSetupManager
    {
        SetupRepository setupRepository = new SetupRepository();
        public void Add(TestSetup testSetup)

        { 
            if (testSetup != null)
            {
                if (testSetup.TestName != "" && testSetup.Fee >0 && testSetup.TypeId >0)
                {
                    setupRepository.Add(testSetup);
                    throw new Exception("Successfully Saved");
                }
                else
                {
                    throw new Exception("Invalid setup Details");
                }

            }
            else
            {
                throw new Exception("Invalid Input");
            }
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            dt = setupRepository.getAll();
            return dt;
        }

        public bool testNameChecked(string testName)
        {
            bool ischeckd = setupRepository.checkedTestName(testName);
            return ischeckd;
        }
    }
}
