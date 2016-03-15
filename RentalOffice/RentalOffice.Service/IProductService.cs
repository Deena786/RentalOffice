using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Model;

namespace RentalOffice.Service
{
    public interface IProductService
    {
        IQueryable<ProductViewModel> GetAllProducts();
        ProductViewModel GetProduct(int id);
        IEnumerable<ProductViewModel> GetProductByName(string name);
        IEnumerable<ProductViewModel> GetProductByCategory(string category);
        void CreateProduct(ProductViewModel model);
        void UpdateProduct(ProductViewModel model);
        void DeleteProduct(int id);
    }
}
