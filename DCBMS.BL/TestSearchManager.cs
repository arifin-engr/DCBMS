using DCBMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.BL
{
  public  class TestSearchManager
    {
        TestSearchRepository searchRepository = new TestSearchRepository();
        public DataTable getTestReport(string fromDate,string toDate)
        {
            DataTable dt = new DataTable();
            dt = searchRepository.getReport(fromDate, toDate);

            return dt;
        }
        public DataTable getTotalByDate(string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            dt = searchRepository.geTotall(fromDate, toDate);

            return dt;
        }
        public DataTable getUnpaidTotalByDate(string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            dt = searchRepository.geUnpaidTotall(fromDate, toDate);

            return dt;
        }
        public DataTable getTypewiseReport(string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            dt = searchRepository.getTypewiseReport(fromDate, toDate);

            return dt;
        }
       
        public DataTable getTypewiseTotalByDate(string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            dt = searchRepository.geTypewiseTotall(fromDate, toDate);

            return dt;
        }

        public DataTable getUnpaidTestReport(string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            dt = searchRepository.getUnpaidReport(fromDate, toDate);

            return dt;
        }
    }
}
