using System;
using System.Collections.Generic;
using System.Linq;
using RentalOffice.Model;

namespace RentalOffice.Service
{
    public interface IAddressService
    {
        IQueryable<AddressViewModel> GetAllAddresses();
        AddressViewModel GetAddress(int id);
        void CreateAddress(AddressViewModel model);
        void UpdateAddress(AddressViewModel model);
        void DeleteAddress(int id);
    }
}
