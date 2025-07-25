using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain
{
    public class LoanType
    {
        public int Id { get; set; }
        public string Type { get; set; }       
        public decimal Rate { get; set; }     
    }
}
