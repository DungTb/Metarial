namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        public int IdChiTietDonHang { get; set; }

        public int? IdDonHang { get; set; }

        public int? IdSanPham { get; set; }

        [StringLength(50)]
        public string MaChiTietDonHang { get; set; }

        [StringLength(150)]
        public string TenSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? GiaBan { get; set; }

        public decimal? ThanhTien { get; set; }

        public int? IdVanChuyen { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual VanChuyen VanChuyen { get; set; }
    }
}
