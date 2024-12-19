using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;

namespace customer.Pages.Customers
{
    public class Create : PageModel
    {
        [BindProperty, Required(ErrorMessage ="The First Name is required")]
        public string Firstname {get; set;} = "";
        [BindProperty, Required(ErrorMessage ="The Last Name is required")]
        public string Lastname {get; set;} = "";
        [BindProperty, Required(ErrorMessage ="The Email is required")]
        public string Email {get; set;} = "";
        [BindProperty]
        public string? Phone {get; set;}
        [BindProperty]
        public string? Address {get; set;}
        [BindProperty, Required(ErrorMessage ="The Company is required")]
        public string Company {get; set;} = "";
        [BindProperty]
        public string? Notes {get; set;}

        public string ErrorMessage {get; set;} = "";

        public void OnPost() {
            if (!ModelState.IsValid) {
                return;
            }
            if(Phone == null) Phone = "";
            if(Address == null) Address = "";
            if(Notes == null) Notes = "";

            try
            {
                string connectionString = "Server=localhost; Database=customer; Uid=root; Pwd=";  // pwd = Your key
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO customers " + 
                    "(firstname, lastname, email, phone, address, company, notes) VALUES " +
                    "(@firstname, @lastname, @email, @phone, @address, @company, @notes);"
                    ;
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@firstname", Firstname);
                        cmd.Parameters.AddWithValue("@lastname", Lastname);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@company", Company);
                        cmd.Parameters.AddWithValue("@notes", Notes);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                
                ErrorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Index");
        }


    }
}