namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            DiaChiGiaoHangs = new HashSet<DiaChiGiaoHang>();
        }

        [Key]
        public int IdDonHang { get; set; }

        [StringLength(50)]
        public string MaDonHang { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? IdKhachHang { get; set; }

        [StringLength(50)]
        public string TenNguoiDatHang { get; set; }

        public bool? TrangThaiThanhToan { get; set; }

        public bool? TrangThaiGiaoHang { get; set; }
        public decimal? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiaChiGiaoHang> DiaChiGiaoHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
