namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoanKhachHang")]
    public partial class TaiKhoanKhachHang
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }

        public int? IdKhachHang { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool? Active { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
