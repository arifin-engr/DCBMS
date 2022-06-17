using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.Model
{
   public class TestSetup
    {
        [Key]
        public int TestSetupId { get; set; }
        public string TestName { get; set; }
        public double Fee { get; set; }
        public DateTime AddDate { get; set; }
        [ForeignKey("TestType")]
        public int TypeId { get; set; }
        public TestType TestType { get; set; }
    }
}
