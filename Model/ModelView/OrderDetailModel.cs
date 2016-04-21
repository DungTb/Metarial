using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelView
{
  public class OrderDetailModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? Number { get; set; }
        public decimal? PriceItem { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public decimal? Total { get; set; }
       
    }
}
