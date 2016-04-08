using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;
using PagedList;
using System.Data.Entity.SqlServer;


namespace Model.Dao



{
    public class DonHangDao
    {
        private DemoASpDbContext db = null;
        public DonHangDao()
        {
            db = new DemoASpDbContext();
        }
        public long Isert(DonHang entity)
        {
            db.DonHangs.Add(entity);
            db.SaveChanges();
            return entity.IdDonHang;
        }
        public string kiemtra(bool ? b) { 
             string kq ;
            if (b.GetValueOrDefault() == true )
                kq = "T"; 
            else { kq = "f"; }

            return kq;

        }
      
        public IEnumerable<HoaDonViewModel> ListAll()
        {
            
            IQueryable<HoaDonViewModel> model = (from a in db.DonHangs
                                                 join b in db.KhachHangs
                                                 on a.IdKhachHang equals b.IdKhachHang
                                                 where 1 == 1
                                                 
                                                 select new HoaDonViewModel
                                                {
                                                   
                                                    MaDonHang = a.MaDonHang,
                                                    NgayTao =a.NgayTao,
                                                     Ten = b.Ten,
                                                     //TrangThaiGiaoHang = kiemtra(a.TrangThaiGiaoHang),
                                                     //kiemtra(a.TrangThaiGiaoHang),
                                                    //TrangThaiThanhToan = kiemtra(a.TrangThaiThanhToan),
                                                     //kiemtra(a.TrangThaiThanhToan),
                                                     
                                                     TongTien = a.TongTien
                                                });

            return model.ToList();
            }
       
    }
}
