namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaBanSanPham")]
    public partial class GiaBanSanPham
    {
        public int? idSanPham { get; set; }

        [Key]
        public int idGiaBanSanPham { get; set; }

        public decimal? GiaBan { get; set; }

        public decimal? GiaKhuyenMai { get; set; }
    }
}
