using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelView
{
  public  class CategoryModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}
