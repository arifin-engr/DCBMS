using DCBMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.BL
{
   public class PaymentManager
    {
        PaymentRepository paymentRepository = new PaymentRepository();
        public DataTable findBillByMobileNo( string phnNo)
        {
            DataTable dt = new DataTable();
            dt = paymentRepository.findBillByMobile(phnNo);
            return dt;
        }
        public DataTable countTotall(string phnNo)
        {
            DataTable dt = new DataTable();
            dt = paymentRepository.countTotall(phnNo);
            return dt;
        }

        public DataTable SubmitTotall(string phnNo)
        {
            DataTable dataTable = new DataTable();
            dataTable = paymentRepository.SubmitTotall(phnNo);
            return dataTable;
        }
    }
}
