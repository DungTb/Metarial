using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Model.Dao
{
   public class ProductImageDao
    {
        private DemoASpDbContext1 db = null;

        public ProductImageDao()
        {
            db = new DemoASpDbContext1();
        }
        public void Isert(ProductImage productimage, string image)
        {
            ProductImage createImage = new ProductImage();
            

            createImage.Image = image;
            createImage.ProductId = 2;
             db.ProductImages.Add(productimage);

            db.SaveChanges();
          
        }

    }
}
