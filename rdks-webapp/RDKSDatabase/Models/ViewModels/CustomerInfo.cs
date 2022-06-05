using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDKSDatabase.Models;
using Microsoft.EntityFrameworkCore;


namespace RDKSDatabase.ViewModels
{
    public class CustomerInfo
    {
        public Customer? SelectedCustomer { get; set; }
        public IEnumerable<Customer>? Results { get; set; }
        public IEnumerable<Customer>? Customers { get; set; }
        public IEnumerable<Address>? Addresses { get; set; }
        public IEnumerable<Permit>? Permits { get; set; }
        public IEnumerable<Vehicle>? Vehicles { get; set; }
    }
}
