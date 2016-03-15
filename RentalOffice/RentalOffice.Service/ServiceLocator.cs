using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Service.Implementation;


namespace RentalOffice.Service
{
    public class ServiceLocator
    {
        public static IUserService GetUserService()
        {
            return new UserService();
        } 
      
        public static IProductService GetProductService()
        {
            return new ProductService();
        }

        public static IOrderService GetOrderService()
        {
            return new OrderService();
        }       

        public static ISelectedItemService GetSelectedItemService()
        {
            return new SelectedItemService();
        }

        public static IAddressService GetAddressService()
        {
            return new AddressService();
        }
    }
}
