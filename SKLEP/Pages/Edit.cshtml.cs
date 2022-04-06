using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKLEP.Models;

namespace SKLEP.Pages
{
    public class EditModel : MyPageModel
    {
        [FromQuery(Name="id")]
        public int id { get; set; }
        [BindProperty]
        public Product prod { get; set; }
        public Product Product { get; set; }
        public void OnGet()
        {
            LoadDB();
            prod = productDB.List()[id-1];
        }
        public IActionResult OnPost(Product prod)
        {
            LoadDB();
            prod.id = id;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            productDB.Edit(prod);
            SaveDB();
            return RedirectToPage("List");
        }

    }
}
