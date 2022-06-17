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
    public class TestTypeManager
    {
        TypeRepository typeRepository = new TypeRepository();
        public void Add(TestType testType)
        {
            if (testType !=null)
            {
                if (testType.TypeName !="")
                {
                    typeRepository.Add(testType);
                }
                else
                {
                    throw new Exception("Invalid Type Name");
                }

            }
            else
            {
                throw new Exception("Invalid Input");
            }
        }

        public bool checkTypeNameIsExistorNot(TestType testType)
        {
           bool IsChecked= typeRepository.checkTypeNameIsExistorNot(testType);
            return IsChecked;
        }

        public DataTable getAllTypeName()
        {
            DataTable dt = new DataTable();
            dt = typeRepository.getAllTypeName();
            return dt;
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            dt = typeRepository.getAll();
            return dt;
        }
    }
}
