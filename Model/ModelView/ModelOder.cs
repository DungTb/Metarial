using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelView
{
  public  class ModelOder
    {
        public string Paid {
            get {
                if (ShippingStatus == true)
                    return "Đã Chuyển";
                else return "Chưa Chuyển";
            }

            set { this.Paid = Paid; }
        }


        
        public string Delivered {
            get {
                if (PaymetStatus == true)
                    return "Da Thanh Toan";
                else return "Chua Thanh Toan";
            }
           set { this.Delivered = Delivered; }
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Name { get; set; }
        public bool? ShippingStatus { get; set; }

        public bool? PaymetStatus { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
