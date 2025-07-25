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
        private readonly LoanEntry _loanEntry;

        public LoanService()
        {
            _loanEntry = new LoanEntry();
        }

        public async Task<bool> InsertLoanApplication(LoanDetails details)
        {
            return await _loanEntry.InsertLoanApplication(details);
        }

        public async Task<List<LoanType>> GetLoanTypes()
        {
            return await _loanEntry.SelectAllLoanTypes();
        }

        public async Task<List<LoanDetails>> GetAllLoanDetails()
        {
            return await _loanEntry.SelectAllLoanApplications();
        }
    }
}
