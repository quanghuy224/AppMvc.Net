using App.Models;

namespace App.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel(){Id=1, Name="Iphone", Price=1000},
                new ProductModel(){Id=2, Name="SamSUng", Price=500},
                new ProductModel(){Id=3, Name="Sony", Price=800},
                new ProductModel(){Id=4, Name="Nokia", Price=100},
            });
        }
    }
}