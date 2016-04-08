namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSanPhamCuaSanPham")]
    public partial class DanhMucSanPhamCuaSanPham
    {
        [Key]
        public int IdDMSPSP { get; set; }

        public int? IdDanhMucSanPham { get; set; }

        public int? IdSanPham { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
