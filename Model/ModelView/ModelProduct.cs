using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelView
{
   public class ModelProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string NameNCC{ get; set; }

        [StringLength(50)]
        public string ProductSpecies { get; set; }

    }
}
