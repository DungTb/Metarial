namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSanPham")]
    public partial class DanhMucSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucSanPham()
        {
            DanhMucSanPhamCuaSanPhams = new HashSet<DanhMucSanPhamCuaSanPham>();
        }

        [Key]
        public int IdDanhMucSanPham { get; set; }

        [StringLength(50)]
        public string TenDanhMucSanPham { get; set; }

        [StringLength(50)]
        public string MaDanhMucSanPham { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string ĐieuKien { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucSanPhamCuaSanPham> DanhMucSanPhamCuaSanPhams { get; set; }
    }
}
