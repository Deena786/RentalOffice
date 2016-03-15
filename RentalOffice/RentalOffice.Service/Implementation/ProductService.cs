using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Model;
using RentalOffice.Data;
using RentalOffice.Data.Entities;

namespace RentalOffice.Service.Implementation
{
    public class ProductService : IProductService
    {
        private RentalOfficeContext context = new RentalOfficeContext();
         
        public IQueryable<ProductViewModel> GetAllProducts()
        {
            return context.Products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Pledge = p.Pledge,
                Price = p.Price,
                Category = p.Category,
                Description = p.Description,
                Released = p.Released,
                Made = p.Made,
                Producer = p.Producer,
                FilmStars = p.FilmStars, 
                Quality = p.Quality,
                Image = p.Image,  
                Availability = p.Availability
            });
        }

        public IEnumerable<ProductViewModel> GetProductByName(string name)
        {
            return context.Products.Where(p => p.Name == name)
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Pledge = p.Pledge,
                    Price = p.Price,
                    Category = p.Category,
                    Description = p.Description,
                    Released = p.Released,
                    Made = p.Made,
                    Producer = p.Producer,
                    FilmStars = p.FilmStars,
                    Quality = p.Quality,
                    Availability = p.Availability,
                });
        }

        public IEnumerable<ProductViewModel> GetProductByCategory(string category)
        {
            return context.Products.Where(p => p.Category == category)
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Pledge = p.Pledge,
                    Price = p.Price,
                    Category = p.Category,
                    Description = p.Description,
                    Released = p.Released,
                    Made = p.Made,
                    Producer = p.Producer,
                    FilmStars = p.FilmStars,
                    Quality = p.Quality,
                    Availability = p.Availability
                });
        }

        public void CreateProduct(ProductViewModel model)
        {
            var newProduct = new Product
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Pledge = model.Pledge,
                Price = model.Price,
                Category = model.Category,
                Description = model.Description,
                Released = model.Released,
                Made = model.Made,
                Producer = model.Producer,
                FilmStars = model.FilmStars,
                Quality = model.Quality,
                Image = model.ProductId + ".jpg",
                Availability = "доступно"
            };
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public ProductViewModel GetProduct(int id)
        {
            return context.Products.Where(p => p.ProductId == id)
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Pledge = p.Pledge,
                    Price = p.Price,
                    Category = p.Category,
                    Description = p.Description,
                    Released = p.Released,
                    Made = p.Made,
                    Producer = p.Producer,
                    FilmStars = p.FilmStars,
                    Quality = p.Quality,
                    Image = p.Image,
                    Availability = p.Availability
                }).SingleOrDefault();
        }

        public void UpdateProduct(ProductViewModel model)
        {
            var product = context.Products.Find(model.ProductId);

            product.Name = model.Name;
            product.Pledge = model.Pledge;
            product.Price = model.Price;
            product.Category = model.Category;
            product.Description = model.Description;
            product.Released = model.Released;
            product.Made = model.Made;
            product.Producer = model.Producer;
            product.FilmStars = model.FilmStars;
            product.Quality = model.Quality;
            product.Availability = model.Availability;
            product.Image = model.Image;

            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = context.Products.Where(p => p.ProductId == id)
                .SingleOrDefault();
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
