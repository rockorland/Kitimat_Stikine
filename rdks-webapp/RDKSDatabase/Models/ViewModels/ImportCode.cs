using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDKSDatabase.Models.ViewModels
{
    public class ImportCode
    {
        public IEnumerable<Validation> Validations { get; set; }
        public IEnumerable<Validation> Results { get; set; }
    }
}