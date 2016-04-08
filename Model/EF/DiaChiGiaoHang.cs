namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaChiGiaoHang")]
    public partial class DiaChiGiaoHang
    {
        public int? IdDonHang { get; set; }

        [Key]
        public int IdDiaChiGiaoHang { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string TenDiaChi { get; set; }

        [StringLength(50)]
        public string ThanhPho { get; set; }

        [StringLength(50)]
        public string QuocGia { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
