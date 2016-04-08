namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaChi")]
    public partial class DiaChi
    {
        [Key]
        public int IdDiaChi { get; set; }

        public int? IdKhachHang { get; set; }

        [StringLength(50)]
        public string CongTy { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string ThanhPho { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string MaQuocGia { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
