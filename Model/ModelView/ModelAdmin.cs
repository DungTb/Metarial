using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelView
{
 public class ModelAdmin
    {
        public bool? Status { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string EmailCustomer { get; set; }
        public int CountOders { get; set; }
        public decimal? Total { get; set; }
    }
}
