using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKLEP.Models;

namespace SKLEP.Pages
{
    public class DeleteModel : MyPageModel
    {
        [FromQuery(Name = "id")]
        public int id { get; set; }
        public Product prod { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        public IActionResult OnGet()
        {
            LoadDB();
            prod = productDB.List()[id - 1];
            productDB.Delete(prod);
            updatecook(id);
            SaveDB();
            return RedirectToPage("List");
        }
        public void updatecook(int id)
        {
            var cookieValue = Request.Cookies["Cart"];
            string newcook = "";
            var ilosci = new int[productDB.List().Count + 2];
            var pr = productDB.List();
            int i =0,j=0;
            if (cookieValue != null)
            {
                for (i = 0; i < cookieValue.Length; i++)
                {
                    ilosci[cookieValue[i] - 48]++;
                }
            }
            for(i=id; i<pr.Count+1;i++)
            {
                ilosci[i] = ilosci[i + 1];
            }
            ilosci[i] = 0;
            for (i = 1; i <= pr.Count; i++)
            {
                for ( j=0; j<ilosci[i]; j++)
                {
                    newcook += pr[i-1].id.ToString();
                }
            }
            Response.Cookies.Append("Cart", newcook);
        }
    }
}
