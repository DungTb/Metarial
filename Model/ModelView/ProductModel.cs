using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(50)]
        public string ProductSpecies { get; set; }
       // public List<ManufacturerModels> ListManufacturer { get; set; }

    }
}
