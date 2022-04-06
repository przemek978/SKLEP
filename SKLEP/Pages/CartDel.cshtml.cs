using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKLEP.Models;
using System.Collections.Generic;

namespace SKLEP.Pages
{
    public class CartDelModel : MyPageModel
    {
        [FromQuery(Name = "id")]
        public int id { get; set; }
        public List<Product> products;
        public Product prod { get; set; }
        public int[] ilosci;
        public decimal suma = 0;
        public IActionResult OnGet()
        {
            LoadDB();
            products = productDB.List();
            var cookieValue = Request.Cookies["Cart"];
            string newcook="";
            ilosci = new int[productDB.List().Count + 1];
            if (cookieValue != null)
            {
                for (int i = 0; i < cookieValue.Length; i++)
                {
                    ilosci[cookieValue[i] - 48]++;
                }
            }
            ilosci[id]--;
            productC = new List<Product>();
            for (int i = 1; i <= products.Count; i++)
            {
                if (ilosci[i] != 0)
                    productC.Add(products[i - 1]);
            }
            for (int i = 1; i <=products.Count; i++)
            {
                for (int j = 0; j < ilosci[i]; j++)
                {
                    newcook += products[i - 1].id.ToString();
                }
            }
            Response.Cookies.Append("Cart",newcook);
            SaveDB();
            return RedirectToPage("Cart");
        }
    }
}
