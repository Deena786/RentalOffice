using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Model;

namespace RentalOffice.Service
{
    interface IOrderItemService
    {
        void CreateOrderItem(List<SelectedItemViewModel> model);
    }
}
