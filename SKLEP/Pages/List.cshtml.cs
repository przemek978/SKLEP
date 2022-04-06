using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKLEP.DAL;
using SKLEP.Models;
using System.Collections.Generic;

namespace SKLEP.Pages
{
    public class ListModel : MyPageModel
    {
        public List<Product> productList;
        public void OnGet()
        {
            LoadDB();
            productList = productDB.List();  
            SaveDB();
        }
    }
}
