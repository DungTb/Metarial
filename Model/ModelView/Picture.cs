using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Model.ModelView
{
   public class Picture
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
