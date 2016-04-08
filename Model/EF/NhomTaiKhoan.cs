namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomTaiKhoan")]
    public partial class NhomTaiKhoan
    {
        [Key]
        public int IdNhomTaiKhoan { get; set; }

        [StringLength(50)]
        public string TenNhomTaiKhoan { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public bool? Active { get; set; }
    }
}
