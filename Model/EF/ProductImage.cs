namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImage
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
