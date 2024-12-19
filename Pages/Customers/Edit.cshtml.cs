using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace customer.Pages.Customers
{
    public class Edit : PageModel
    {
        [BindProperty]
        public int Id {get; set;}

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
        public void OnGet(int id)
        {
            try
            {
                string connectionString = "Server=localhost; Database=customer; Uid=root; Pwd="; // pwd = Your key
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM customer WHERE id = @id"; 
                
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                {
                                    Id = reader.GetInt32(0);
                                    Firstname = reader.GetString(1);
                                    Lastname = reader.GetString(2);
                                    Email = reader.GetString(3);
                                    Phone = reader.GetString(4);
                                    Address = reader.GetString(5);
                                    Company = reader.GetString(6);
                                    Notes = reader.GetString(7);
                                }
                        
                            } else {
                                Response.Redirect("/Index");
                            }
                        }
                    
                        
                    }
                }
            }
            catch (Exception ex)
            {
                
                ErrorMessage = ex.Message;
                return;
            }
        }

        public void OnPost() {
            if (!ModelState.IsValid) {
                return;
            }
            if(Phone == null) Phone = "";
            if(Address == null) Address = "";
            if(Notes == null) Notes = "";

            try
            {
                string connectionString = "Server=localhost; Database=customer; Uid=root; Pwd=K0645499b%"; 
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = " UPDATE customers SET firstname = @firstname, lastname= @lastname," + 
                    " email = @email, phone= @phone, address= @address, company = @company,  notes= @notes WHERE id = @id;";   
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@firstname", Firstname);
                        cmd.Parameters.AddWithValue("@lastname", Lastname);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@company", Company);
                        cmd.Parameters.AddWithValue("@notes", Notes);
                        cmd.Parameters.AddWithValue("@id", Id);

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