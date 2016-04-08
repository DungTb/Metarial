using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
   public  class HoaDonViewModel
    {
        
        public string MaDonHang { get; set; }

        public DateTime? NgayTao { get; set; }

        public string Ten { get; set; }

        public string TrangThaiThanhToan { get; set; }

        public string TrangThaiGiaoHang { get; set; }
          
  
        
        public decimal? TongTien { get; set; }
    }
}
