using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Model;

namespace RentalOffice.Service
{
    public interface ISelectedItemService
    {
        void AddItem(int productId, int userId);
        SelectedItemViewModel GetItem(int id);
        IEnumerable<SelectedItemShowModel> GetItemsByUserIdForShow(int id);
        IEnumerable<SelectedItemViewModel> GetItemsByUserId(int id);
        void DeleteItem(int id);
    }
}
