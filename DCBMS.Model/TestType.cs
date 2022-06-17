using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DCBMS.Model
{
   public class TestType
    {
        [Key]
        public int TypeId { get; set; }
        [Display(Name ="Type Name")]
        public string TypeName { get; set; }
    }
}
