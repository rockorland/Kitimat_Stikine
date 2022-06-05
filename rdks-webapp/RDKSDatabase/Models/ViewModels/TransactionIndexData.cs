using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDKSDatabase.Models.ViewModels
{
    public class TransactionIndexData
    {
        public Transaction Transaction { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
