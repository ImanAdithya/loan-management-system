using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanSystem.Entry;
using LoanSystem.Domain;

namespace LoanSystem.Service
{
    public class LoanService
    {
        public async Task<bool> InsertLoanApplication(LoanDetails details)
        {
            return await new LoanEntry().InsertLoanApplication(details);
        }
    }
}
