using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKLEP.DAL;
using SKLEP.Models;

namespace SKLEP.Pages
{
    public class CreateModel : MyPageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            LoadDB();
            productDB.Create(newProduct);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SaveDB();
            return RedirectToPage("List");
        }

    }
}
