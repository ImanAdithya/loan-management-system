using System;
using System.ComponentModel.DataAnnotations;

namespace LoanSystem.Domain
{
    public class LoanDetails
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string NIC { get; set; }

        [Required]
        public string LoanType { get; set; }

        [Required]
        [Range(0.1, 100)]
        public decimal InterestRate { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal FacilityAmount { get; set; }

        [Required]
        [Range(1, 360)]
        public int Terms { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal MonthlyPayment { get; set; }

        public string LoanTypeName { get; set; } = "Not Set";
    }

}
