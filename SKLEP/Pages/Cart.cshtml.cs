using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKLEP.Models;
using System;
using System.Collections.Generic;

namespace SKLEP.Pages
{
    public class CartModel : MyPageModel
    {
        public List<Product> products;
        //public List<Product> productList;
        public int[] ilosci;
        public decimal? suma=0;
        public void OnGet()
        {
            LoadDB();
            products = productDB.List();
            var cookieValue = Request.Cookies["Cart"];
            ilosci = new int[productDB.List().Count + 1];
            if (cookieValue != null)
            {
                for (int i = 0; i < cookieValue.Length; i++)
                {
                    ilosci[cookieValue[i] - 48]++;
                }
            }
            productC = new List<Product>();
            for (int i = 1; i <= products.Count; i++)
            {
                if (ilosci[i] != 0)
                    productC.Add(products[i - 1]);
            }
            foreach (var p in productC)
            {
                suma += p.price * ilosci[p.id];
            }
            SaveDB();
        }
        public IActionResult OnPost()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Append("Cart", "", cookieOptions);
            return RedirectToPage("Cart");
        }

    }
}
