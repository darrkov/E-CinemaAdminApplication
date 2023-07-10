using E_CinemaAdminApplication.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace E_CinemaAdminApplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportUsers(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fs = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            List<User> users = getAllUsersFromFile(file.FileName);

            HttpClient client = new HttpClient();

            string url = "https://localhost:44386/api/Admin/ImportAllUsers";

           

        HttpContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");

        HttpResponseMessage response = client.PostAsync(url, content).Result;

        var data = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Order");
        }



        private List<User> getAllUsersFromFile(string file)
        {
            List<User> users = new List<User>();

            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using(var stream = System.IO.File.Open(pathToUpload, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new Models.User
                        {
                            Email = reader.GetValue(0).ToString(),
                            Password = reader.GetValue(1).ToString(),
                            ConfirmPassword = reader.GetValue(2).ToString(),
                        });
                    }
                }
                    
            }
            return users;
        }
    }
}
