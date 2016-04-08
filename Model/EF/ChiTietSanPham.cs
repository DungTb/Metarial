namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        [Key]
        public int IdSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
