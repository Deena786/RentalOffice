
namespace RentalOffice.Data
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using RentalOffice.Data.Entities;


    public class RentalOfficeContext : DbContext
    {        
        public RentalOfficeContext()
            : base("name=RentalOfficeContext")
        {
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Product> Products { get; set; }        
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<SelectedItem> SelectedItems { get; set; }
        public IDbSet<OrderItem> OrderItems { get; set; }      
    }   
}
