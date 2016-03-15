using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Data;
using RentalOffice.Data.Entities;
using RentalOffice.Model;

namespace RentalOffice.Service.Implementation
{
    public class OrderService : IOrderService
    {
        RentalOfficeContext context = new RentalOfficeContext();

        public OrderViewModel GetNewOrder(int userId)
        {
            var user = context.Users.Find(userId);
            return new OrderViewModel
            {
                OrderDate = DateTime.Now,                
                UserName = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                OrderItems = context.SelectedItems.Where(i => i.UserId == userId)
                    .Select(i => new OrderItemViewModel
                    {                        
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        Pledge = i.Product.Pledge,
                        Price = i.Product.Price,        
                    }).ToList(),
            };
        }
       
        public IQueryable<OrderViewModel> GetAllOrders()
        {
            return context.Orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                UserId = o.UserId,
                UserName = o.User.Name,
                Phone = o.User.Phone,
                Email = o.User.Email,                
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                AddressId = o.Address.AddressId,
                ReturnDate = o.ReturnDate,
                Payment = o.Payment,
                Execution = o.Execution
            });
        }

        public OrderViewModel GetOrder(int id)
        {
            return context.Orders.Where(o => o.OrderId == id)
               .Select(o => new OrderViewModel
               {
                   OrderId = o.OrderId,
                   UserId = o.UserId,
                   UserName = o.User.Name,
                   Phone = o.User.Phone,
                   Email = o.User.Email,         
                   OrderDate = o.OrderDate,
                   DeliveryDate = o.DeliveryDate,
                   AddressId = o.Address.AddressId,
                   ReturnDate = o.ReturnDate,
                   Payment = o.Payment,
                   Execution = o.Execution
               }).SingleOrDefault();
        }

        public IEnumerable<OrderViewModel> GetUserOrders(int id)
        {            
            return context.Orders.Where(o => o.UserId == id)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.OrderId,
                    UserName = o.User.Name,
                    Phone = o.User.Phone,
                    Email = o.User.Email,
                    OrderItems = context.OrderItems.Where(oi => oi.OrderId == o.OrderId)
                    .Select(oi => new OrderItemViewModel
                    {
                        ProductName = oi.ProductName,
                        Pledge = oi.Pledge,
                        Price = oi.Price
                    }).ToList(),
                    OrderDate = o.OrderDate,
                    DeliveryDate = o.DeliveryDate,
                    AddressId = o.Address.AddressId,                    
                    ReturnDate = o.ReturnDate,
                    Payment = o.Payment,
                    Execution = o.Execution
                }).ToList();
        }

        public IQueryable<OrderViewModel> GetUserOrder(int id)
        {
            return context.Orders.Where(o => o.User.UserId == id)
                .Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                UserName = o.User.Name,
                Phone = o.User.Phone,
                Email = o.User.Email,
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                AddressId = o.Address.AddressId,
                ReturnDate = o.ReturnDate,
                Payment = o.Payment,
                Execution = o.Execution
            });
        }

        public IQueryable<OrderViewModel> GetOrderDate(DateTime date)
        {
            return context.Orders.Where(o => o.OrderDate == date)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.OrderId,
                    UserId = o.UserId,
                    UserName = o.User.Name,
                    Phone = o.User.Phone,
                    Email = o.User.Email,         
                    OrderDate = o.OrderDate,
                    DeliveryDate = o.DeliveryDate,
                    AddressId = o.Address.AddressId,
                    ReturnDate = o.ReturnDate,
                    Payment = o.Payment,
                    Execution = o.Execution
                });
        }

        public IQueryable<OrderViewModel> GetDeliveryTodayOrder()
        {
            return context.Orders.Where(o => o.DeliveryDate == DateTime.Now)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.OrderId,
                    UserName = o.User.Name,
                    Phone = o.User.Phone,
                    Email = o.User.Email,
                    OrderDate = o.OrderDate,
                    DeliveryDate = o.DeliveryDate,
                    AddressId = o.Address.AddressId,
                    ReturnDate = o.ReturnDate,
                    Payment = o.Payment,
                    Execution = o.Execution                    
                });
        }

        public IQueryable<OrderViewModel> GetNotReturnOrder()
        {
            return context.Orders.Where(o => o.ReturnDate == null)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.OrderId,
                    UserName = o.User.Name,
                    Phone = o.User.Phone,
                    Email = o.User.Email,
                    OrderDate = o.OrderDate,
                    DeliveryDate = o.DeliveryDate,                    
                    AddressId = o.Address.AddressId,
                    ReturnDate = o.ReturnDate,
                    Payment = o.Payment,
                    Execution = o.Execution 
                });
        }

        

        public void CreateOrder(OrderViewModel model)
        {
            var newOrder = new Order
            {
                UserId = model.UserId,                
                OrderDate = DateTime.Now,
                DeliveryDate = model.DeliveryDate,
                Address = new Address
                {
                    Region = model.Address.Region,
                    Postcode = model.Address.Postcode,
                    City = model.Address.City,
                    Street = model.Address.Street,
                    Building = model.Address.Building,
                    Apartment = model.Address.Apartment
                },
                OrderItems = GetOrderItems(model.OrderItems),               
                ReturnDate = model.ReturnDate,
                Payment = model.Payment,
                Execution = false
            };

            context.Orders.Add(newOrder);

            var selectedItems = context.SelectedItems
                .Where(si => si.UserId == model.UserId);

            foreach(var si in selectedItems)
            {
                context.SelectedItems.Remove(si);
            }

            context.SaveChanges();

        }

        private List<OrderItem> GetOrderItems(List<OrderItemViewModel> model)
        {
            var newOrderItems = new List<OrderItem>();
            foreach (var oivm in model)
            {
                var orderItem = new OrderItem
                {
                    OrderId = oivm.OrderId,
                    ProductId = oivm.ProductId,
                    ProductName = oivm.ProductName,
                    Pledge = oivm.Pledge,
                    Price = oivm.Price
                };
                newOrderItems.Add(orderItem);
            }
            return newOrderItems;
        }


        public void UpdateOrder(OrderViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }
    }
}
