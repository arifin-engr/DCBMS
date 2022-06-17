using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.Model
{
   public class TestRequestEntry
    {
        [Key]
        public int BillId { get; set; }
        public string PatientName { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNo { get; set; }
        [ForeignKey("TestSetup")]
        public int TestId { get; set; }
        public double Fee { get; set; }
        public double TotalAmount { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
