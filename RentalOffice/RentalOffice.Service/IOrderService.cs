using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Data;
using RentalOffice.Data.Entities;
using RentalOffice.Model;

namespace RentalOffice.Service
{
    public interface IOrderService
    {
        OrderViewModel GetNewOrder(int userId);
        IQueryable<OrderViewModel> GetAllOrders();
        IQueryable<OrderViewModel> GetUserOrder(int id);
        IEnumerable<OrderViewModel> GetUserOrders(int id);
        IQueryable<OrderViewModel> GetOrderDate(DateTime date);
        IQueryable<OrderViewModel> GetDeliveryTodayOrder();
        IQueryable<OrderViewModel> GetNotReturnOrder();
        OrderViewModel GetOrder(int id);
        void CreateOrder(OrderViewModel model);
        //List<OrderItem> GetOrderItems(List<OrderItemViewModel> model);
        void UpdateOrder(OrderViewModel model);
        void DeleteOrder(int id);

    }
}
