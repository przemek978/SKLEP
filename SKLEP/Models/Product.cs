using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SKLEP.Models
{
    public class Product
    {
        [FromQuery(Name="id")]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public string name { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [DataType(DataType.Currency, ErrorMessage ="Cena musi przyjmować wartość ceny")]
        [Range(0.01,double.MaxValue,ErrorMessage="Cena musi być większa od 0")]
        //[RegularExpression(@"\d-\d+(,\d+)|\d+(.\d+)?",ErrorMessage = "Cena musi być liczbą")]
        public decimal price { get; set; }
        public static List<Product> GetProducts()
        {
            Product pilka = new Product
            {
                id = 1,
                name = "Piłka nożna",
                price = 25.30M
            };
            Product narty = new Product { id = 2, name = "Narty", price = 150.39M };
            Product rakieta = new Product { id = 3, name = "Rakieta ", price = 111.10M };
            return new List<Product> { pilka, narty, rakieta };
        }

    }
}
