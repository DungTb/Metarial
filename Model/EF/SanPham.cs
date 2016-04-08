namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            DanhMucSanPhamCuaSanPhams = new HashSet<DanhMucSanPhamCuaSanPham>();
        }

        [Key]
        public int IdSanPham { get; set; }

        public int? IdDanhMucSanPham { get; set; }

        [StringLength(50)]
        public string TenSanPham { get; set; }

        public decimal? Gia { get; set; }

        public decimal? GiaKhuyenMai { get; set; }

        public bool? TrangThai { get; set; }

        [Required]
        [StringLength(50)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucSanPhamCuaSanPham> DanhMucSanPhamCuaSanPhams { get; set; }
    }
}
