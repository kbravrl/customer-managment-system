using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace customer.Pages.Customers
{
    public class Delete : PageModel
    {

        public void OnPost(int id)
        {
            deleteCustomer(id);
            Response.Redirect("/Index");
        }

        private void deleteCustomer(int id) {
            try
            {
                string connectionString = "Server=localhost; Database=customer; Uid=root; Pwd="; // pwd = Your key
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM customers WHERE id = @id;";
                    ;
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot delete customer: " + ex.Message);
                
            }
        }
    }
}