using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                _configuration = builder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Configuration Error]: {ex.Message}");
                throw;
            }
        }

        private string GetConnectionString()
        {
            try
            {
                return _configuration.GetConnectionString("DefaultConnection");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ConnectionString Error]: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> InsertLoanApplication(LoanDetails details)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
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
                    cmd.Parameters.AddWithValue("@MonthlyPayment", details.MonthlyPayment);

                    await con.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[InsertLoanApplication Error]: {ex.Message}");
                return false;
            }
        }

        public async Task<List<LoanType>> SelectAllLoanTypes()
        {
            var loanTypes = new List<LoanType>();

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand("SelectLoanType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            loanTypes.Add(new LoanType
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Type = reader["Type"].ToString(),
                                Rate = Convert.ToDecimal(reader["Rate"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SelectAllLoanTypes Error]: {ex.Message}");
            }

            return loanTypes;
        }

        public async Task<List<LoanDetails>> SelectAllLoanApplications()
        {
            var loanList = new List<LoanDetails>();

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                using (var cmd = new SqlCommand("SelectLoanApplications", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var loan = new LoanDetails
                            {
                                FullName = reader["CustomerName"]?.ToString(),
                                NIC = reader["NIC_PassportNumber"]?.ToString(),
                                InterestRate = reader["InterestRate"] != DBNull.Value ? Convert.ToDecimal(reader["InterestRate"]) : 0,
                                FacilityAmount = reader["LoanAmount"] != DBNull.Value ? Convert.ToDecimal(reader["LoanAmount"]) : 0,
                                Terms = reader["DurationMonths"] != DBNull.Value ? Convert.ToInt32(reader["DurationMonths"]) : 0,
                                MonthlyPayment = reader["MonthlyPayment"] != DBNull.Value ? Convert.ToDecimal(reader["MonthlyPayment"]) : 0,
                                LoanTypeName = reader["LoanType"]?.ToString(),
                            };

                            loanList.Add(loan);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SelectAllLoanApplications Error]: {ex.Message}");
            }

            return loanList;
        }
    }
}
