namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomKhachHang")]
    public partial class NhomKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomKhachHang()
        {
            NhomKhachHangCuaKhachHangs = new HashSet<NhomKhachHangCuaKhachHang>();
        }

        [Key]
        public int IdNhomKhachHang { get; set; }

        [StringLength(50)]
        public string TenNhomKhachHang { get; set; }

        [StringLength(10)]
        public string Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomKhachHangCuaKhachHang> NhomKhachHangCuaKhachHangs { get; set; }
    }
}
