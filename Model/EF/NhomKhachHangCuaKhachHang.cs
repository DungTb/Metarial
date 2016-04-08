namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomKhachHangCuaKhachHang")]
    public partial class NhomKhachHangCuaKhachHang
    {
        [Key]
        public int IdNhomKHKH { get; set; }

        public int? IdKhachHang { get; set; }

        public int? IdNhomKhachHang { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool? Active { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhomKhachHang NhomKhachHang { get; set; }
    }
}
