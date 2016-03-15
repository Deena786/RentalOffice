using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace RentalOffice.Data.Entities
{    
    public enum Roles
    {
        Admin = 1,
        Employee = 2,
        Customer = 3       
    }
}
