using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelView
{
    public class ProductModel
    {
        public string NameCategory { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string VendorName{ get; set; }
        public string Size { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        public Nullable<int> CategoryId { get; set; }
        public int ManufacturerId { get; set; }


        public decimal? Price { get; set; }

        public decimal? SalePrice { get; set; }

        public bool? StockStatus { get; set; }

        public bool? AvailableStatus { get; set; }

        [StringLength(200)]
        public string Alias { get; set; }

        public string Content1 { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        [StringLength(50)]
        public string ProductSpecies { get; set; }
        public List<ManufacturerModel> ListManufacturers { get; set; }
        public List<CategoryModel> ListCategories { get; set; }
        public List<string> ListAllImg { get; set; }
        // public List<ManufacturerModels> ListManufacturer { get; set; }

    }
}
