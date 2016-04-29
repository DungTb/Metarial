namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
            ProductImages = new HashSet<ProductImage>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        public int? GroupProductId { get; set; }

        public int? CategoryId { get; set; }

        public int? ManufacturerId { get; set; }

        [StringLength(50)]
        public string BarCode { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(50)]
        public string ProductSpecies { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

        public decimal? SalePrice { get; set; }

        public bool? StockStatus { get; set; }

        public bool? AvailableStatus { get; set; }

        [StringLength(200)]
        public string Alias { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "ConTen1 is required")]
        public string Content1 { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public virtual Category Category { get; set; }

        public virtual GroupProduct GroupProduct { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
