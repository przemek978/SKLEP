using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKLEP.DAL;
using System.Collections.Generic;

namespace SKLEP.Models
{
    public class MyPageModel:PageModel
    {
        public ProductDB productDB;
        public List<Product> productC;
        public string jsonProductDB { get; set; }
        public MyPageModel()
        {
            productDB = new ProductDB();          
        }
        public void LoadDB()
        {
            jsonProductDB = HttpContext.Session.GetString("jsonProductDB");
            productDB.Load(jsonProductDB);
            
        }
        public void SaveDB()
        {
            jsonProductDB = productDB.Save();
            HttpContext.Session.SetString("jsonProductDB", jsonProductDB);
        }
    }
}
