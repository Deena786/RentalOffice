using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Data;
using RentalOffice.Data.Entities;
using RentalOffice.Model;

namespace RentalOffice.Service.Implementation
{
    class OrderItemService : IOrderItemService
    {
        RentalOfficeContext context = new RentalOfficeContext();
        public void CreateOrderItem(List<SelectedItemViewModel> model)
        {
            throw new NotImplementedException();
        }
        
    }
}
