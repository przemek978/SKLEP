using SKLEP.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace SKLEP.DAL
{
    public class ProductDB
    {
        private List<Product> products;
        public void Load(string jsonProducts)
        {
            if (jsonProducts == null)
            {
                products = Product.GetProducts();
            }
            else
            {
                // products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
                products = JsonSerializer.Deserialize<List<Product>>(jsonProducts);
            }
        }
        private int GetNextId()
        {
            int lastID = products[products.Count-1].id;
            int newID = ++lastID;
            return newID;
        }
        public void Create(Product p)
        {
            p.id = GetNextId();
            products.Add(p);
        }
        public string Save()
        {
            //return JsonConvert.SerializeObject(products);
            return JsonSerializer.Serialize(products);
        }
        public void Edit(Product prod)
        {
            products[prod.id-1].name= prod.name;  
            products[prod.id-1].price = prod.price;
        }
        public void Delete(Product prod)
        {
            products.Remove(prod);
            int i = 1;
            foreach(var p in products)
            {
                p.id = i;
                i++;
            }
        }
        public List<Product> List()
        {
            return products;
        }
    }
}
