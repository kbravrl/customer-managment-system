using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;


namespace customer.Pages
{
    public class Index : PageModel
    {
        public List<Customer> CustomerList { get; set;} = [];

        public void OnGet()
        {
            try
            {
                string connectionString = "Server=localhost; Database=customer; Uid=root; Pwd="; // pwd = Your key
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM customers;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer()
                                {
                                    Id = reader.GetInt32(0),
                                    Firstname = reader.GetString(1),
                                    Lastname = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Phone = reader.GetString(4),
                                    Address = reader.GetString(5),
                                    Company = reader.GetString(6),
                                    Notes = reader.GetString(7),
                                    CraetedAt = reader.GetDateTime(8).ToString("yyyy-MM-dd")
                                };
                                CustomerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("We have an error: " + ex.Message);
            }

        }
    }

    public class Customer {
        public int Id {get; set;}
        public string Firstname {get; set;} = "";
        public string Lastname {get; set;} = "";
        public string Email {get; set;} = "";
        public string Phone {get; set;} = "";
        public string Address {get; set;} = "";
        public string Company {get; set;} = "";
        public string Notes {get; set;} = "";
        public string CraetedAt {get; set;} = "";


    }
        
    
}

