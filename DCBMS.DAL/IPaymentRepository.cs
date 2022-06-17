using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.DAL
{
   public interface IPaymentRepository
    {
        DataTable findBillByMobile(string mobileNo);
        DataTable countTotall(string mobileNo);

    }
}
