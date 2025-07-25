using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LoanSystem.Domain;

namespace LoanSystem.Entry
{
    public class LoanEntry
    {
        private readonly IConfiguration _configuration;

        public LoanEntry()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }
        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> InsertLoanApplication(LoanDetails details)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("InsertApplicationLoanDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerName", details.FullName);
                    cmd.Parameters.AddWithValue("@NIC_PassportNumber", details.NIC);
                    cmd.Parameters.AddWithValue("@LoanTypeId", details.LoanType);
                    cmd.Parameters.AddWithValue("@InterestRate", details.InterestRate);
                    cmd.Parameters.AddWithValue("@LoanAmount", details.FacilityAmount);
                    cmd.Parameters.AddWithValue("@DurationMonths", details.Terms);
                    cmd.Parameters.AddWithValue("@Status", "New");

                    await con.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }
    }
}
