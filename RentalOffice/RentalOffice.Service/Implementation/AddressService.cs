using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalOffice.Service.Implementation
{
    public class AddressService : IAddressService
    {
        public IQueryable<Model.AddressViewModel> GetAllAddresses()
        {
            throw new NotImplementedException();
        }

        public Model.AddressViewModel GetAddress(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateAddress(Model.AddressViewModel model)
        {
            
        }

        public void UpdateAddress(Model.AddressViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(int id)
        {
            throw new NotImplementedException();
        }
    }
}
