using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Model;
using RentalOffice.Data;
using RentalOffice.Data.Entities;

namespace RentalOffice.Service.Implementation
{
    public class SelectedItemService : ISelectedItemService
    {
        private RentalOfficeContext context = new RentalOfficeContext();

        public void AddItem(int productId, int userId)
        {
            var newItem = new SelectedItem
            {
                UserId = userId,
                ProductId = productId
            };
            context.SelectedItems.Add(newItem);
            context.SaveChanges();
        }

        public IEnumerable<SelectedItemShowModel> GetItemsByUserIdForShow(int id)
        {
            return context.SelectedItems.Where(it => it.UserId == id)
                .Select(it => new SelectedItemShowModel
                {
                    SelectedItemId = it.SelectedItemId,
                    UserId = it.UserId,
                    ProductId = it.ProductId,
                    ProductName = it.Product.Name,
                    Pledge = it.Product.Pledge,
                    Price = it.Product.Price
                }).ToList();
        }

        public IEnumerable<SelectedItemViewModel> GetItemsByUserId(int id)
        {
            return context.SelectedItems.Where(it => it.UserId == id)
                .Select(it => new SelectedItemViewModel
                {
                    SelectedItemId = it.SelectedItemId,
                    UserId = it.UserId,
                    ProductId = it.ProductId                    
                }).ToList();
        }

        public SelectedItemViewModel GetItem(int id)
        {
            return context.SelectedItems.Where(it => it.ProductId == id)
                .Select(it => new SelectedItemViewModel
                {
                    UserId = it.UserId,
                    ProductId = it.ProductId
                }).SingleOrDefault();
        }

        public void DeleteItem (int id)
        {
            var item = context.SelectedItems.Where(si => si.SelectedItemId == id)
                .SingleOrDefault();
            context.SelectedItems.Remove(item);
            context.SaveChanges();
        }
    }
}
